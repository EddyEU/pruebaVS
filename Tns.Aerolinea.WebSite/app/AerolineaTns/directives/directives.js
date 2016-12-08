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
            }
        };
        return directive;
    }
})();