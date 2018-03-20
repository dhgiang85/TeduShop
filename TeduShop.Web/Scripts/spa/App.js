/// <reference path="TeduShopDirective.html" />
/// <reference path="TeduShopDirective.html" />
/// <reference path="TeduShopDirective.html" />
/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module("myModule", []);

myApp.controller("myController", schoolController);

myApp.service("ValidatorService", ValidatorService);

myApp.directive("teduShopDirective", teduShopDirective);

schoolController.$inject = ['$scope', 'ValidatorService'];

//delare
function schoolController($scope, ValidatorService)
{
    //$scope.message = Validator.checkNumber(1);
    $scope.checkNumber = function () {
        $scope.message = ValidatorService.checkNumber($scope.num);
    }
    $scope.num = 1;
}

function ValidatorService($window) {
    return {
        checkNumber : checkNumber
    }
    function checkNumber(input) {
        if (input % 2 == 0) {
            return "this is even";
        } else {
            return "this is odd";
        }
    }
}

function teduShopDirective() {
    return {
        //template:"<h1> This is my first custom directive"
        restrict:"A",
        templateUrl: "/Scripts/spa/teduShopDirective.html"
    }
}