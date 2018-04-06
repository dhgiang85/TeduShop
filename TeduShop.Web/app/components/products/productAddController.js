(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$state', '$scope', 'apiService', 'notificationService'];

    function productAddController($state, $scope, apiService, notificationService) {
        $scope.product = {
            CreateDate: new Date(),
            Status: true
        }
        $scope.ckeditorOptions= {
            language: 'vi',
            height:'200px'
        }
        $scope.AddProduct = AddProduct;
        $scope.ChooseImage = function  ChooseImage(){
            var finder = new CKFinder();
            finder.selectActionFunction = function(fileUrl) {
                $scope.product.Image = fileUrl;
            }
            finder.popup();
        };


        function AddProduct() {
            apiService.post('/api/product/create', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('Thêm mới không thành công');
                });
        }

        function getListProductCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;

            }, function () {
                console.log('Cannot get list product category');
            });
        }

        getListProductCategory();
    }
})(angular.module('tedushop.products'));