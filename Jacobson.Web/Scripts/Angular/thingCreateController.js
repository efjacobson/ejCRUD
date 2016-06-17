(function () {
    'use strict';

    angular
        .module('thingCreateApp')
        .controller('thingCreateController', thingCreateController);

    thingCreateController.$inject = ['$location']; 

    function thingCreateController($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'thingCreateController';

        vm.submit = _submit;

        activate();

        function activate() { }

        function _submit() {
            console.log(vm.Name);
            console.log(vm.Description);
        }
    }
})();