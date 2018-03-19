/// <reference path="../plugins/angular/angular.js" />

var myApp = angular.module("myModule", []);

myApp.controller("myController", myController);

myController.$inject = ['$scope'];

//delare
function myController($scope)
{
    $scope.message = "this is my message from controller";
}