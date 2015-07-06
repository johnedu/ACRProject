(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',

        'ui.router',
        'ui.bootstrap',
        'ui.jq',

        'abp'
    ]);

    //Configuración de parámetros de paginación por defecto
    app.run(function (paginationConfig) {
        paginationConfig.maxSize = 3;
        paginationConfig.rotate = false;
        paginationConfig.boundaryLinks = true;
        paginationConfig.firstText = "<<";
        paginationConfig.previousText = "<";
        paginationConfig.nextText = ">";
        paginationConfig.lastText = ">>";
    });

    //Configuración de parámetros de datepicker por defecto
    app.run(function (datepickerConfig) {
        datepickerConfig.startingDay = 1;
        datepickerConfig.showWeeks = false;
    });
    app.run(function (datepickerPopupConfig) {
        datepickerPopupConfig.showButtonBar = false;
    });

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in BowNavigationProvider
                })
                .state('zonificacionPais', {
                    url: '/administracion/zonificacion/:paisId',
                    templateUrl: '/App/Main/views/zonificacion/departamento/departamento.cshtml',
                    menu: 'menu_administracion_zonificacion'
                })
                .state('preguntasFrecuentes', {
                    url: '/administracion/preguntasFrecuentes',
                    templateUrl: '/App/Main/views/administracion/preguntasFrecuentes/preguntasFrecuentes.cshtml',
                    menu: 'menu_administracion_preguntasFrecuentes'
                })
                .state('preguntasJuegos', {
                    url: '/administracion/preguntasJuegos',
                    templateUrl: '/App/Main/views/administracion/preguntasJuegos/preguntasJuegos.cshtml',
                    menu: 'menu_administracion_preguntasJuegos'
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in BowNavigationProvider
                })

            /*$stateProvider.when('departamentos', {
                url: '/zonificacion/pais/:paisId'
            });*/


        }
    ]);
})();

