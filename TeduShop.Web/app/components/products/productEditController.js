﻿(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$state', '$scope', '$stateParams', 'apiService', 'commonService', 'notificationService'];

    function productEditController($state, $scope, $stateParams, apiService, commonService, notificationService) {
        $scope.product = {}
        $scope.moreImages = [];
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }
        $scope.UpdateProduct = UpdateProduct;
        $scope.ChooseImage = function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function() {
                    $scope.product.Image = fileUrl;
                })  
            }
            finder.popup();
        };
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function loadProductDetail() {
            apiService.get('/api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImage);
            }, function (error) {
                notificationService.displayError(result.data);
            });
        }

        function UpdateProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);
            apiService.put('/api/product/update', $scope.product,
                function (result) {
                    notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                    $state.go('products');
                }, function (error) {
                    notificationService.displayError('cập nhật không thành công');
                });
        }

        function getListProductCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;

            }, function () {
                console.log('Cannot get list product category');
            });
        }
        $scope.ChooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }
        getListProductCategory();
        loadProductDetail();
    }
})(angular.module('tedushop.products'));