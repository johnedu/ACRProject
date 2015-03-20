(function () {
    angular.module('app').controller('app.views.home.modalPruebaController', ['$scope',
        function ($scope) {
            $scope.selected = undefined;
            $scope.personas = [
                {id:1, nombre:'Patrick', documento:'16073832', apellido:'Llano',nacionalidad:'Pakistan', oficina: 'Manizales'},
                { id: 2, nombre: 'Darwin', documento: '16073850', apellido: 'RC', nacionalidad: 'Inglaterra', oficina: 'Ibague' },
                {id:3, nombre: 'Harold', documento:'123123123', apellido: 'Giraldo', nacionalidad: 'Irlanda', oficina: 'Villavicencio'},
                {id:4, nombre:'Jonathan', documento: '456456456', apellido: 'Quintero', nacionalidad:'Colombia', oficina: 'Manizales'}
            ];

            

            $scope.mostrarSeleccionado = function () {
                console.log("Selected: ", $scope.selected);
                alert("Id de la persona seleccionada: " + $scope.selected.id);
            };
            
            $scope.filterByNombreAndDocumento = function (personas, typedValue) {
                return personas.filter(function (persona) {
                    var nombre = persona.nombre.toLowerCase();
                    var documento = persona.documento.toLowerCase();
                    var busqueda = typedValue.toLowerCase();

                    matches_nombre = nombre.indexOf(busqueda) !== -1;
                    matches_documento = documento.indexOf(busqueda) !== -1;

                    return matches_nombre || matches_documento;
                });
            };
        }]);

})();
