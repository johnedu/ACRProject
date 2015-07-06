(function () {
    angular.module('app').controller('modalEditarPreguntasFrecuentesController', ['$scope', '$modalInstance', 'preguntaEditar', 'abp.services.app.zonificacion',
        function ($scope, $modalInstance, preguntaEditar, zonificacionService) {

            $scope.codigoPregunta = preguntaEditar;

            zonificacionService.getPreguntaFrecuente({ id: preguntaEditar })
                .success(function (data) {
                    $scope.preguntaFrecuente = data;
                });

            $scope.okModal = function () {
                zonificacionService.updatePreguntaFrecuente({ id: preguntaEditar, pregunta: $scope.preguntaFrecuente.pregunta, respuesta: $scope.preguntaFrecuente.respuesta })
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