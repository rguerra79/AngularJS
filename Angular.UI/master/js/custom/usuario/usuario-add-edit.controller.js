(function () {
    'use strict';

    angular
        .module('angle')
        .controller('UsuarioAddEditController', UsuarioAddEditController);

    UsuarioAddEditController.$inject = ['$state', '$stateParams', '$filter', 'ngTableParams', '$resource', '$timeout', 'ngTableDataService', 'UsuarioService', 'toaster'];
    function UsuarioAddEditController($state, $stateParams, $filter, ngTableParams, $resource, $timeout, ngTableDataService, UsuarioService, toaster) {
        var vm = this;

        //Variables
        vm.isAdd = true;
        vm.username = '';
        vm.name = '';
        vm.lastName = '';

        activate();

        //Methods
        vm.goBack = goBack;
        vm.save = save;

        //Method definitions
        function activate() {

            if ($stateParams.id) {
                vm.isAdd = false;
            }

            if (!vm.isAdd) {
                UsuarioService.getUsuario($stateParams.id)
                    .success(function (response) {
                        fillForm(response);
                    });
            }
        }

        function goBack() {
            $state.go('app.usuario-list');
        }

        function save() {
            var usuario = {
                NombreDeUsuario: vm.username,
                Nombre: vm.name,
                Apellido:vm.lastName
            };

            if (vm.isAdd) {
                UsuarioService.add(usuario)
                    .success(function (response) {
                        toaster.success('Guardado', 'Guardado exitosamente.');
                        $state.go('app.usuario-list');
                    });
            }
            else {
                usuario.Id = $stateParams.id;
                UsuarioService.edit(usuario)
                    .success(function (response) {
                        toaster.success('Guardado', 'Guardado exitosamente.');
                        $state.go('app.usuario-list');
                    });
            }
        }

        //Functions
        function fillForm(usuario) {
            vm.username = usuario.NombreDeUsuario;
            vm.name = usuario.Nombre;
            vm.lastName = usuario.Apellido;
        }
    }
})();
