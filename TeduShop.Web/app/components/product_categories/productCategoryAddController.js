(function(app) {
    app.controller('productCategoryAddController', productCategoryAddController);

    productCategoryAddController.$inject = ['$state','$scope', 'apiService','notificationService'];

    function productCategoryAddController($state, $scope, apiService, notificationService) {
        $scope.productCategory = {
            CreateDate: new Date(),
            Status:true
        }

        $scope.AddProductCategory = AddProductCategory;

        function AddProductCategory() {
            apiService.post('/api/productcategory/create', $scope.productCategory,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('product_categories');
                }, function(error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }
        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
      
            },function() {
                console.log('Cannot get list parent');
            });
        }

        loadParentCategory();
    }

})(angular.module('tedushop.product_categories'));