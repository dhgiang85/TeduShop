(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope','apiService'];

    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];

        $scope.getProoductCategories = getProoductCategories;

        function getProoductCategories() {
            apiService.get('/api/productcategory/getall',null, function(result) {
                $scope.productCategories = result.data;
                console.log(result.data);
            },function() {
                console.log('Load productcategory failed.');
            });
        }

        $scope.getProoductCategories();
    }
})(angular.module('tedushop.product_categories'));