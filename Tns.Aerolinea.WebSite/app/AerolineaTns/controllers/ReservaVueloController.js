(function () {
    'use strict';

    angular
        .module('app')
        .controller('ReservaVueloController', ReservaVueloController);

    ReservaVueloController.$inject = ['$scope']; 

    function ReservaVueloController($scope) {
        $scope.title = 'ReservaVueloController';

        activate();

        function activate() { }
    }
})();
