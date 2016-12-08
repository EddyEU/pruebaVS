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

            ///Servicios REST

            ///Mensajes de error y alerta

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
                templateUrl: ConstantesApp.controladorRuta + 'Bienvenida.html',
                resolve: {
                    loadMyService: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([
                            '/app/AerolineaTns/controllers/BienvenidaController.js'
                        ]);
                    }]
                }
            })
            .state('RegistrarUsuario', {
                url: '/RegistrarUsuario',
                templateUrl: ConstantesApp.controladorRuta + 'RegistrarUsuario.html',
                resolve: {
                    loadMyService: ['$ocLazyLoad', function ($ocLazyLoad) {
                        return $ocLazyLoad.load([
                            '/app/AerolineaTns/controllers/UsuarioControllers.js',
                        ]);
                    }]
                }
            })
        }]);
})();