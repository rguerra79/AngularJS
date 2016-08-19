(function () {
    'use strict';

    angular
        .module('angle')
        .factory('UsuarioService', UsuarioService);

    UsuarioService.$inject = ['$http', 'GLOBAL'];
    function UsuarioService($http, GLOBAL) {
        var service = {
            getUsuarios: getUsuarios,
            getUsuario: getUsuario,
            add: add,
            edit: edit,
            remove: remove
        };

        return service;

        //Method definitions
        function getUsuarios(campo) {
            return $http
              .get(GLOBAL.api + 'Usuario/GetAll', { params: {orderby: campo}});
        }

        function getUsuario(id) {
            return $http
              .get(GLOBAL.api + 'Usuario/Get', { params: { id: id } });
        }

        function add(usuario) {
            return $http
              .post(GLOBAL.api + 'Usuario/Add', usuario);
        }

        function edit(usuario) {
            return $http
              .post(GLOBAL.api + 'Usuario/Edit', usuario);
        }

        function remove(id) {
            return $http
              .post(GLOBAL.api + 'Usuario/Remove', { usuarioId: id });
        }
    }
})();