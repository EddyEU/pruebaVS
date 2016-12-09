(function () {
    'use strict';

    angular.module('aerolineaApp', [
        // Angular modules
        'ui.router',
        'ngAnimate',
        'ui.bootstrap',
        'ui.grid',
        'ui.grid.treeView',
        'ui.grid.edit',
        'ui.grid.resizeColumns',
        'ui.grid.cellNav',
        'ui.grid.autoResize',
        'oc.lazyLoad',
        'chieffancypants.loadingBar'
    ]);

    angular
        .module('aerolineaApp').constant("ConstantesApp", {
            ///Controladoras
            controladorLoginUsuario: 'Login/',
            controladorVuelo: 'Vuelo/',
            controladorDatosMaestros: 'DatosMaestros/',

            ///Servicios REST
            servicioLoginUsuario: 'ValidarUsuario',
            servicioConsultarVuelosHorarios: 'ConsultarVuelosHorarios',
            servicioConsultarVuelosTarifas: 'ConsultarVuelosTarifas',
            servicioConsultarEstadosVuelos: 'ConsultarEstadosVuelos',
            servicioReservaVuelo: 'ReservaVuelo',
            servicioConsultarReservas: 'ConsultarReservas',
            servicioRegistrarUsuario: 'RegistrarUsuario',
            servicioCiudadesOrigen: 'ConsultarOrigenes',
            servicioCiudadesDestino: 'ConsultarDestinos',

            ///Mensajes de error y alerta
            ErrorConsultaCiudadesOrigen: 'Error al consultar la lista de ciudades origen.',
            ErrorConsultaCiudadesDestino: 'Error al consultar la lista de ciudades destino.',
            ErrorConsultaVuelos: 'Error al consultar la lista de vuelos solicitrada.',
            mensajeUsuarioRegistrado: 'Usuario Registrado exitosamente.',
            mensajeErrorUsuarioRegistrado: 'Se ha presentado un error registrando el usuario, por favor intente nuevamente.',

            ///Control de URL - Redireccionamiento
            controladorRuta: '/app/AerolineaTns/views/'
        });

    angular
        .module('aerolineaApp').config(['$httpProvider', '$stateProvider', '$urlRouterProvider', 'ConstantesApp', function ($httpProvider, $stateProvider, $urlRouterProvider, ConstantesApp) {
            //Configuracion para que IE no cachee los request
            //initialize get if not there
            if (!$httpProvider.defaults.headers.get) {
                $httpProvider.defaults.headers.get = {};
            }

            $urlRouterProvider.otherwise('/Bienvenida');

            // Answer edited to include suggestions from comments
            // because previous version of code introduced browser-related errors

            //disable IE ajax request caching
            $httpProvider.defaults.headers.get['If-Modified-Since'] = 'Mon, 26 Jul 1997 05:00:00 GMT';
            // extra
            $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
            $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';

            $stateProvider
            .state('Bienvenida', {
                url: '/Bienvenida',
                templateUrl: ConstantesApp.controladorRuta + 'Bienvenida.html'
            })
            .state('RegistrarUsuario', {
                url: '/RegistrarUsuario',
                templateUrl: ConstantesApp.controladorRuta + 'RegistrarUsuario.html',
                resolve: {
                    loadMyService: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([
                            '/app/AerolineaTns/services/UsuarioServices.js',
                            '/app/AerolineaTns/controllers/UsuarioController.js',
                        ]);
                    }]
                }
            })
            .state('Login', {
                url: '/Login',
                templateUrl: ConstantesApp.controladorRuta + 'Login.html',
                resolve: {
                    loadMyService: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([
                            '/app/AerolineaTns/services/LoginServices.js',
                            '/app/AerolineaTns/controllers/LoginController.js',
                        ]);
                    }]
                }
            })
            .state('ConsultaVuelo', {
                url: '/ConsultaVuelo',
                templateUrl: ConstantesApp.controladorRuta + 'ConsultaVuelo.html',
                resolve: {
                    loadMyService: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([
                            '/app/AerolineaTns/services/ConsultaVueloServices.js',
                            '/app/AerolineaTns/controllers/ConsultaVueloController.js',
                        ]);
                    }]
                }
            })
            .state('ReservaVuelo', {
                url: '/ReservaVuelo',
                templateUrl: ConstantesApp.controladorRuta + 'ReservaVuelo.html',
                resolve: {
                    loadMyService: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([
                            //'/app/AerolineaTns/services/ReservaVueloServices.js',
                            //'/app/AerolineaTns/controllers/ReservaVueloController.js',
                        ]);
                    }]
                }
            })
        }]);
})();