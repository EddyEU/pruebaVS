(function () {
    'use strict';

    angular
        .module('aerolineaApp')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$scope', 'LoginServices', 'ConstantesApp', '$uibModal'];

    function LoginController($scope, LoginServices, ConstantesApp, $uibModal) {
        $scope.Usuario = {};
        $scope.UsuarioLogueado = false;

        $scope.validarUsuario = function () {
            var filtros = {
                Login: $scope.Usuario.Login,
                Clave: $scope.Usuario.Clave
            };
            $scope.UsuarioService = {};
            return LoginServices.getUsuario(filtros).then(function successCallback(usuario) {
                $scope.UsuarioService = usuario.data;
                $scope.UsuarioLogueado = true;
                $scope.limpiar();
            }, function errorCallback(usuario) {
                $scope.MostrarAlerta(usuario.data);
                $scope.UsuarioLogueado = false;
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

        ///Limpiar filtros
        $scope.limpiar = function () {
            $scope.Usuario.Login = "";
            $scope.Usuario.Clave = "";
        };
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