(function () {
    'use strict';

    angular
        .module('thingIndexApp')
        .controller('thingIndexController', thingIndexController);

    thingIndexController.$inject = ['$log', 'thingIndexFactory'];

    function thingIndexController($log, thingIndexFactory) {
        /* jshint validthis:true */
        var vm = this;

        activate();

        function activate() {
            _getAllThings();
        }

        function _getAllThings() {
            thingIndexFactory.getAll()
                .then(
                    _setThings,
                    _logError
                );
        }

        function _setThings(response) {
            vm.things = response.data;
        }

        function _logError(response) {
            $log.error(response);
        }
    }
})();