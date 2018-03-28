(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope','apiService'];

    function productCategoryListController($scope, apiService) {
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