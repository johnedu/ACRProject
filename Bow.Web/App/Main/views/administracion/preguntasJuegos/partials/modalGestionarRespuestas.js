(function () {
    angular.module('app').controller('modalGestionarOpcionesController', ['$scope', '$modalInstance', 'infoTributariaId', 'infoTributariaNombre', 'abp.services.app.empresas',
        function ($scope, $modalInstance, infoTributariaId, infoTributariaNombre, empresasService) {

            ////Inicializando modelos

            $scope.mensajeEliminar = [];
            $scope.opcionesInfoTributaria = [];
            $scope.nombreInfoTributaria = infoTributariaNombre;
            $scope.mostrarFormulario = false;
            $scope.accionFormulario = "Agregar";

            $scope.opcionInfoTributaria = {
                nombre: '',
                infoTributariaId: ''
            };

            /********************************************************************
             * Funcion para cargar las opciones de la información tributaria seleccionada
             ********************************************************************/
            function cargarOpcionesInfoTributaria() {
                empresasService.getInfoTributariaOpciones({ infoTributariaId: infoTributariaId })
                    .success(function (data) {
                        $scope.opcionesInfoTributaria = bow.tablas.paginar(data.infoTributariaOpciones, 5);
                    });
            }

            cargarOpcionesInfoTributaria();

            /********************************************************************
             * Funcion para crear una nueva opción de información tributaria
             ********************************************************************/
            function crearOpcionInfoTributaria() {
                $scope.opcionInfoTributaria.infoTributariaId = infoTributariaId;
                empresasService.saveInfoTributariaOpcion($scope.opcionInfoTributaria)
                    .success(function () {
                        abp.notify.info(abp.localization.localize('empresas_infoTributaria_opciones_notificacionInsertado', 'Bow'), abp.localization.localize('empresas_infoTributaria_opciones_mensaje_informacion', 'Bow'));
                        cargarOpcionesInfoTributaria();
                        $scope.mostrarFormulario = false;
                    }).error(function (error) {
                        $scope.mensajeError = error.message;
                    });
            }

            /********************************************************************
             * Funcion para editar una opción de información tributaria
             ********************************************************************/
            function editarOpcionInfoTributaria() {
                $scope.opcionInfoTributaria.InfoTributariaId = infoTributariaId;
                empresasService.updateInfoTributariaOpcion($scope.opcionInfoTributaria)
                    .success(function () {
                        abp.notify.info(abp.localization.localize('empresas_infoTributaria_opciones_notificacionModificado', 'Bow'), abp.localization.localize('empresas_infoTributaria_opciones_mensaje_informacion', 'Bow'));
                        cargarOpcionesInfoTributaria();
                        $scope.mostrarFormulario = false;
                    }).error(function (error) {
                        $scope.mensajeError = error.message;
                    });
            }

            /********************************************************************
             * Funciones para eliminar una opción de Información Tributaria
             ********************************************************************/
            $scope.eliminarOpcionInfoTributaria = function (infoTributariaId, $index) {
                empresasService.puedeEliminarInfoTributariaOpcion({ id: infoTributariaId })
                   .success(function (data) {
                       if (data.puedeEliminar) {
                           $scope.mensajeEliminar[$index] = true;
                       }
                       else {
                           abp.notify.info(abp.localization.localize('empresas_infoTributaria_opciones_notificacion_nosePuedeEliminar', 'Bow'), abp.localization.localize('empresas_infoTributaria_opciones_mensaje_informacion', 'Bow'));
                       }
                   }).error(function (error) {
                       $scope.mensajeError = error.message;
                   });

            };

            $scope.eliminarOpcionInfoTributariaOk = function (infoTributariaId, $index) {
                empresasService.deleteInfoTributariaOpcion({ id: infoTributariaId })
                   .success(function (data) {
                       $scope.mensajeEliminar[$index] = false;
                       abp.notify.info(abp.localization.localize('empresas_infoTributaria_opciones_notificacionEliminado', 'Bow'), abp.localization.localize('empresas_infoTributaria_opciones_mensaje_informacion', 'Bow'));
                       cargarOpcionesInfoTributaria();
                   }).error(function (error) {
                       $scope.mensajeError = error.message;
                   });
            }

            $scope.eliminarCancel = function ($index) {
                $scope.mensajeEliminar[$index] = false;
            }

            $scope.mostrarFormularioNuevaInfoTributaria = function () {
                $scope.opcionInfoTributaria = {
                    nombre: '',
                    infoTributariaId: ''
                };
                $scope.mensajeError = null;
                $scope.mostrarFormulario = true;
                $scope.accionFormulario = "Agregar";
                //  Limpiamos el formulario para que no se muestren las clases 'has-error'
                $scope.formNuevaOpcionInfoTributaria.$setPristine();
            }

            $scope.mostrarFormularioEditarInfoTributaria = function (opcionInfoTributariaId) {
                $scope.mensajeError = null;
                empresasService.getInfoTributariaOpcion({ id: opcionInfoTributariaId }).success(function (data) {
                    $scope.opcionInfoTributaria = data;
                });
                $scope.mostrarFormulario = true;
                $scope.accionFormulario = "Editar";
            }

            $scope.cancelFormulario = function () {
                $scope.mostrarFormulario = false;
            }

            $scope.guardarModificarOpcionInfoTributaria = function () {
                $scope.mensajeError = null;
                if ($scope.accionFormulario == "Agregar") {
                    crearOpcionInfoTributaria();
                }
                else {
                    editarOpcionInfoTributaria();
                }
            }

            $scope.cancelModal = function () {
                $modalInstance.dismiss('cancel');
            }

        }]);
})();