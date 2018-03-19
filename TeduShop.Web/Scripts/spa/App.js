/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module("myModule", []);

myApp.controller("myController", schoolController);
myApp.service('Validator', Validator);
schoolController.$inject = ['$scope', 'Validator'];

//delare
function schoolController($scope, Validator)
{
    //$scope.message = Validator.checkNumber(1);
    $scope.checkNumber = function () {
        $scope.message = Validator.checkNumber($scope.num);
    }
    $scope.num = 1;
}

function Validator($window) {
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