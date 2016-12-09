(function () {
    'use strict';

    angular
        .module('aerolineaApp')
        .service('UsuarioServices', UsuarioServices);

    UsuarioServices.$inject = ['$http', 'ConstantesApp'];

    var urlApi = "http://localhost:5000/api/";

    function UsuarioServices($http, ConstantesApp) {
        var service = {
            putRegistrarUsuario: putRegistrarUsuario
        };

        return service;

        function putRegistrarUsuario(usuario) {
            return $http({
                method: 'PUT',
                url: urlApiServer + ConstantesApp.controladorLoginUsuario + ConstantesApp.servicioRegistrarUsuario,
                data: JSON.stringify(usuario)
            });
        }
    }
})();