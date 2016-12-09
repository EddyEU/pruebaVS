(function () {
    'use strict';

    angular
        .module('aerolineaApp')
        .service('LoginServices', LoginServices);

    LoginServices.$inject = ['$http', 'ConstantesApp'];

    var urlApi = "http://localhost:5000/api/";

    function LoginServices($http, ConstantesApp) {
        var service = {
            getUsuario: getUsuario
        };

        return service;

        function getUsuario(filtros) {
            return $http({
                method: 'GET',
                url: urlApi + ConstantesApp.controladorLoginUsuario + ConstantesApp.servicioLoginUsuario,
                params: filtros
            });
        }
    }
})();