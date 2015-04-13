(function () {
    //Nombre del controlador   
    var controllerId = 'app.views.administracion.preguntasJuegos';

    /*****************************************************************
    * 
    * CONTROLADOR DE PREGUNTAS FRECUENTES
    * 
    *****************************************************************/

    angular.module('app').controller(controllerId, ['$scope', '$modal', 'abp.services.app.administracion',
       function ($scope, $modal, administracionService) {
           var vm = this;

           //Inicializando Modelos

           vm.preguntasFrecuentes = [];

           vm.preguntaFrecuente = {
               id: '',
               pregunta: '',
               respuesta: ''
           };

           //Funcion encargada de consultar las preguntas frecuentes en la base de datos
           function cargarPreguntasFrecuentes() {
               administracionService.getAllPreguntasFrecuentes().success(function (data) {
                   vm.preguntasFrecuentes = data.preguntasFrecuentes;
               });
           }
           cargarPreguntasFrecuentes();

           /************************************************************************
            * Llamado para abrir Modal para Nueva Pregunta Frecuente
            ************************************************************************/

           vm.abrirModalNueva= function () {
               var modalInstance = $modal.open({
                   templateUrl: '/App/Main/views/administracion/preguntasFrecuentes/partials/modalNuevoPreguntasFrecuentes.cshtml',
                   controller: 'modalNuevoPreguntasFrecuentesController',
                   size: 'md'
               });

               modalInstance.result.then(function (pregunta) {
                   cargarPreguntasFrecuentes();
                   abp.notify.success(abp.localization.localize('', 'Bow') + 'Se guardó correctamente la pregunta: ' + pregunta, abp.localization.localize('', 'Bow') + 'Información');
               }, function () {
                   vm.resultado = abp.localization.localize('', 'Bow') + 'Ocurrió un problema al guardar la pregunta frecuente'
               });
           }

           /************************************************************************
           * Llamado para abrir Modal para Editar Pregunta Frecuente
           ************************************************************************/
           vm.abrirModalEditar = function (preguntaId) {
               var modalInstance = $modal.open({
                   templateUrl: '/App/Main/views/administracion/preguntasFrecuentes/partials/modalEditarPreguntasFrecuentes.cshtml',
                   controller: 'modalEditarPreguntasFrecuentesController',
                   size: 'md',
                   resolve: {
                       preguntaEditar: function () {
                           return preguntaId;
                       }
                   }
               });

               modalInstance.result.then(function (pregunta) {
                   abp.notify.success(abp.localization.localize('', 'Bow') + 'Se actualizó correctamente la pregunta: ' + pregunta, abp.localization.localize('', 'Bow') + 'Información');
                   cargarPreguntasFrecuentes();

               }, function () {
                   vm.resultado = abp.localization.localize('', 'Bow') + 'Ocurrió un problema al actualizar la pregunta frecuente'
               });
           }

           /************************************************************************
           * Llamado para abrir Modal para Eliminar Pregunta Frecuente
           ************************************************************************/
           vm.abrirModalEliminar = function (preguntaId) {
                var modalInstance = $modal.open({
                    templateUrl: '/App/Main/views/administracion/preguntasFrecuentes/partials/modalEliminarPreguntasFrecuentes.cshtml',
                    controller: 'modalEliminarPreguntasFrecuentesController',
                    size: 'md',
                    resolve: {
                        preguntaEliminar: function () {
                            return preguntaId;
                        }
                    }
                });

                modalInstance.result.then(function (dptoNombre) {
                    cargarPreguntasFrecuentes();
                    abp.notify.success(abp.localization.localize('', 'Bow') + 'Se eliminó correctamente la pregunta: ' + dptoNombre, abp.localization.localize('', 'Bow') + 'Información');
                }, function () {
                    vm.resultado = abp.localization.localize('', 'Bow') + 'Ocurrió un problema al actualizar la pregunta frecuente'
                });
           }
       }]);
})();