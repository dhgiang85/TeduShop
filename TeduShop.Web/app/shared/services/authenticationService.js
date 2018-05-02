(function (app) {
    'use strict';
    app.service('authenticationService', ['$http', '$q', '$window', 'authData',
    function ($http, $q, $window,  authData) {
        var tokenInfo;

        this.setTokenInfo = function (data) {
            tokenInfo = data;
  
            $window.sessionStorage["TokenInfo"] = JSON.stringify(tokenInfo);
        }

        this.getTokenInfo = function () {
            return tokenInfo;
        }

        this.removeToken = function () {
            tokenInfo = null;
   
            $window.sessionStorage["TokenInfo"] = null;
        }

        this.init = function () {
  
            var tokenInfo = $window.sessionStorage["TokenInfo"];
            if (tokenInfo) {
                tokenInfo = JSON.parse(tokenInfo);
            }
        }

        this.setHeader = function () {
            delete $http.defaults.headers.common['X-Requested-With'];
            if ((tokenInfo != undefined) && (authData.accessToken != undefined) && (authData.accessToken != null) && (authData.accessToken != "")) {
                $http.defaults.headers.common['Authorization'] = 'Bearer ' + authData.accessToken;
                $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
            }
        }

        this.validateRequest = function () {
            var url = 'api/home/TestMethod';
            var deferred = $q.defer();
            $http.get(url).then(function () {
                deferred.resolve(null);
            }, function (error) {
                deferred.reject(error);
            });
            return deferred.promise;
        }

        this.init();
    }
    ]);
})(angular.module('tedushop.common'));