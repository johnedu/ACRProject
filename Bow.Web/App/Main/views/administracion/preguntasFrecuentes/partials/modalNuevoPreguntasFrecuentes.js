﻿(function () {
    angular.module('app').controller('modalNuevoPreguntasFrecuentesController', ['$scope', '$modalInstance', 'abp.services.app.zonificacion',
        function ($scope, $modalInstance, zonificacionService) {

            $scope.preguntaFrecuente = {
                pregunta: '',
                respuesta: ''
            };

            $scope.okModal = function () {

                zonificacionService.savePreguntaFrecuente($scope.preguntaFrecuente)
                    .success(function () {
                        $modalInstance.close($scope.preguntaFrecuente.pregunta);
                    }).error(function (error) {
                        $scope.mensajeError = error.message;
                    });
            }

            $scope.cancelModal = function () {
                $modalInstance.dismiss('cancel');
            }
        }]);
})();