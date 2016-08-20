(function () {
    'use strict';

    angular
        .module('angle')
        .controller('UsuarioAddEditController', UsuarioAddEditController);

    UsuarioAddEditController.$inject = ['$state', '$stateParams', 'UsuarioService', 'toaster'];
    function UsuarioAddEditController($state, $stateParams, UsuarioService, toaster) {
        var vm = this;

        //Variables
        vm.isAdd = true;
        vm.nombreUsuario = '';
        vm.nombre = '';
        vm.apellido = '';
        vm.fechaNacimiento = null;

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
                NombreDeUsuario: vm.nombreUsuario,
                Nombre: vm.nombre,
                Apellido: vm.apellido,
                FechaNacimiento: vm.fechaNacimiento
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
            vm.nombreUsuario = usuario.NombreDeUsuario;
            vm.nombre = usuario.Nombre;
            vm.apellido = usuario.Apellido;
            vm.fechaNacimiento = new Date(usuario.FechaNacimiento);
        }
    }
})();
