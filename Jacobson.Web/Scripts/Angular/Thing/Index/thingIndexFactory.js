(function () {
    'use strict';

    angular
        .module('thingIndexApp')
        .factory('thingIndexFactory', thingIndexFactory);

    thingIndexFactory.$inject = ['$http', '$q'];

    function thingIndexFactory($http, $q) {
        var service = {
            getAll: _getAll
        };

        return service;

        function _getAll() {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: '/api/thing'
            }).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });

            return deferred.promise;
        }
    }
})();