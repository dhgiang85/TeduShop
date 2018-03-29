(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
      
        $scope.getProoductCategories = getProoductCategories;

        $scope.keyword = '';

        $scope.search = search;

        function search() {
            getProoductCategories();
        }

        function getProoductCategories(page) {
            page = page || 0;
            var config= {
                params: {
                    page: page,
                    pageSize: 2,
                    keyword: $scope.keyword 
                }
            }


            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount === 0) {
                    notificationService.displayWarning('Không có bản ghi được tìm thấy.');
                } else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                }

                $scope.productCategories = result.data.Items;

                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.TotalCount = result.data.TotalCount;

  
            },function() {
                console.log('Load productcategory failed.');
            });
        }

        $scope.getProoductCategories();
    }
})(angular.module('tedushop.product_categories'));