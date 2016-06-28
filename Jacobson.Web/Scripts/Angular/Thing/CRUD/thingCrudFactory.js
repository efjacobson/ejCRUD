(function () {
    'use strict';

    angular
        .module('thingCrudApp')
        .factory('thingCrudFactory', thingCrudFactory);

    thingCrudFactory.$inject = ['$http', '$q'];

    function thingCrudFactory($http, $q) {
        var service = {
            create: _create
        };

        return service;

        function _create(thing) {
            var deferred = $q.defer();

            $http({
                method: 'POST',
                url: '/api/thing',
                data: thing
            }).then(function (response) {
                deferred.resolve(response);
            }, function (response) {
                deferred.reject(response);
            });

            return deferred.promise;
        }
    }
})();