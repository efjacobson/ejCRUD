(function () {
    'use strict';

    angular
        .module('thingCrudApp')
        .controller('thingCrudController', thingCrudController);

    thingCrudController.$inject = ['thingCrudFactory'];

    function thingCrudController(thingCrudFactory) {
        /* jshint validthis:true */
        var vm = this;

        vm.create = _create;

        activate();

        function activate() { }

        function _create() {
            vm.thing = {
                name: vm.name || null,
                description: vm.description || null
            };

            thingCrudFactory.create(vm.thing)
                .then(
                    _onSuccess,
                    _onError
                );
        }

        function _onSuccess(response) {
            console.log(response);
        }

        function _onError(jqXhr) {
            console.log(jqXhr);
        }
    }
})();