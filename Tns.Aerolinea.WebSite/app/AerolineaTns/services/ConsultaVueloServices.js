(function () {
    'use strict';

    angular
        .module('aerolineaApp')
        .service('ConsultaVueloServices', ConsultaVueloServices);

    ConsultaVueloServices.$inject = ['$http', 'ConstantesApp'];

    var urlApi = "http://localhost:5000/api/";

    function ConsultaVueloServices($http, ConstantesApp) {
        var service = {
            getCiudadesOrigen: getCiudadesOrigen,
            getCiudadesDestino: getCiudadesDestino,
            getVuelosHorario: getVuelosHorario,
            getVuelosTarifas: getVuelosTarifas,
            getVuelosEstados: getVuelosEstados
        };

        return service;

        function getCiudadesOrigen() {
            return $http({
                method: 'GET',
                url: urlApi + ConstantesApp.controladorDatosMaestros + ConstantesApp.servicioCiudadesOrigen
            });
        }

        function getCiudadesDestino() {
            return $http({
                method: 'GET',
                url: urlApi + ConstantesApp.controladorDatosMaestros + ConstantesApp.servicioCiudadesDestino
            });
        }

        function getVuelosHorario(filtros) {
            return $http({
                method: 'GET',
                url: urlApi + ConstantesApp.controladorVuelo + ConstantesApp.servicioConsultarVuelosHorarios,
                params: filtros
            });
        }

        function getVuelosTarifas(filtros) {
            return $http({
                method: 'GET',
                url: urlApi + ConstantesApp.controladorVuelo + ConstantesApp.servicioConsultarVuelosTarifas,
                params: filtros
            });
        }

        function getVuelosEstados(filtros) {
            return $http({
                method: 'GET',
                url: urlApi + ConstantesApp.controladorVuelo + ConstantesApp.servicioConsultarEstadosVuelos,
                params: filtros
            });
        }
    }
})();