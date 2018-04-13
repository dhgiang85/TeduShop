(function (app) {
    app.controller('productAddController', productAddController);

    productAddController.$inject = ['$state', '$scope', 'apiService', 'commonService', 'notificationService'];

    function productAddController($state, $scope, apiService, commonService, notificationService)
    {
        $scope.product = {
            CreateDate: new Date(),
            Status: true
        }
        $scope.ckeditorOptions= {
            language: 'vi',
            height:'200px'
        }
        $scope.AddProduct = AddProduct;
        $scope.ChooseImage = function ChooseImage(){
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Image = fileUrl;
                })
            }
            finder.popup();
        };
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function AddProduct() {
            $scope.product.MoreImage = JSON.stringify($scope.moreImages);
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
        
        $scope.moreImages = [];

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
    }
})(angular.module('tedushop.products'));