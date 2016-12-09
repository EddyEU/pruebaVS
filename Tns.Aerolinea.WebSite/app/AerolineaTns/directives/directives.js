(function () {
    'use strict';

    angular
        .module('aerolineaApp')
        .directive('menu', menu);

    function menu() {
        var directive = {
            restrict: 'E',
            templateUrl: '/app/AerolineaTns/partials/Menu.html',
            controller: function ($scope) {
                $scope.tab = 1;

                $scope.selectTab = function (tab) {
                    $scope.tab = tab;
                };

                $scope.isActive = function (tab) {
                    return tab === $scope.tab;
                };

                $scope.isLogin = function () {
                    //TODO: cambiar el label Inicar sesion por el nombre de la persona logueada
                    return 'Inicar Sesion';
                }
            }
        };
        return directive;
    }
})();