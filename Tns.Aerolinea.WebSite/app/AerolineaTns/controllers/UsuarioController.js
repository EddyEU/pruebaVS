(function () {
    'use strict';

    angular
        .module('aerolineaApp')
        .controller('UsuarioController', UsuarioController);

    UsuarioController.$inject = ['$scope', 'UsuarioServices', 'ConstantesApp', '$uibModal'];

    function UsuarioController($scope, UsuarioServices, ConstantesApp, $uibModal) {
        $scope.registrarUsuario = function () {
            var usuario = {
                Nombre: $scope.Usuario.Nombre,
                Apellido: $scope.Usuario.Apellido,
                Cedula: $scope.Usuario.Cedula,
                Login: $scope.Usuario.Login,
                Clave: $scope.Usuario.Clave
            }

            SolicitudReversionServices.putRegistrarUsuario(usuario).then(function successCallback(response) {
                $scope.MostrarAlerta(ConstantesApp.mensajeUsuarioRegistrado);
            }, function errorCallback(response) {
                $scope.MostrarAlerta(ConstantesApp.mensajeErrorUsuarioRegistrado);
            });
        };

        ///Mostrar el mensaje entregado como parámetro en una ventana emergente
        $scope.MostrarAlerta = function (mensaje) {
            var modalInstance = $uibModal.open({
                animation: true,
                templateUrl: ConstantesApp.controladorRuta + 'ModalAlert.html',
                controller: 'alertasController',
                size: '',
                resolve: {
                    message: function () {
                        return mensaje;
                    }
                }
            });
        }
    };

    ///Controlador modal alerta
    angular
       .module('aerolineaApp')
       .controller('alertasController', alertasController);

    alertasController.$inject = ['$scope', '$uibModalInstance', 'message'];

    function alertasController($scope, $uibModalInstance, message) {
        $scope.mensaje = message;
        $scope.ok = function () {
            $uibModalInstance.close();
        };
    }
})();