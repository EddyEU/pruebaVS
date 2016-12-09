(function () {
    'use strict';

    angular
        .module('aerolineaApp')
        .controller('ConsultaVueloController', ConsultaVueloController);

    ConsultaVueloController.$inject = ['$scope', 'ConsultaVueloServices', 'ConstantesApp', '$uibModal'];

    function ConsultaVueloController($scope, ConsultaVueloServices, ConstantesApp, $uibModal) {
        $scope.CiudadesOrigen = [];
        $scope.CiudadesDestino = [];
        $scope.Vuelos = [];

        $scope.consultarCiudadesOrigen = function () {
            return ConsultaVueloServices.getCiudadesOrigen().then(function successCallback(ciudades) {
                $scope.CiudadesOrigen = ciudades.data;
            }, function errorCallback(ciudades) {
                $scope.MostrarAlerta(ConstantesApp.ErrorConsultaCiudadesOrigen);
            });
        };

        $scope.consultarCiudadesDestino = function () {
            return ConsultaVueloServices.getCiudadesDestino().then(function successCallback(ciudades) {
                $scope.CiudadesDestino = ciudades.data;
            }, function errorCallback(ciudades) {
                $scope.MostrarAlerta(ConstantesApp.ErrorConsultaCiudadesDestino);
            });
        };

        $scope.consultarVuelosHorario = function () {
            return ConsultaVueloServices.getVuelosHorario().then(function successCallback(vuelos) {
                $scope.Vuelos = vuelos.data;
            }, function errorCallback(vuelos) {
                $scope.MostrarAlerta(ConstantesApp.ErrorConsultaVuelos);
            });
        };

        $scope.consultarVuelosTarifas = function () {
            return ConsultaVueloServices.getVuelosTarifas().then(function successCallback(vuelos) {
                $scope.Vuelos = vuelos.data;
            }, function errorCallback(vuelos) {
                $scope.MostrarAlerta(ConstantesApp.ErrorConsultaVuelos);
            });
        };

        $scope.consultarEstadosVuelos = function () {
            return ConsultaVueloServices.getVuelosEstados().then(function successCallback(vuelos) {
                $scope.Vuelos = vuelos.data;
            }, function errorCallback(vuelos) {
                $scope.MostrarAlerta(ConstantesApp.ErrorConsultaVuelos);
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
    }

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