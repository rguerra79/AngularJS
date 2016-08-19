(function() {
    'use strict';

    angular
        .module('angle')
        .controller('UsuarioListController', UsuarioListController);

    UsuarioListController.$inject = ['$state', '$filter', 'ngTableParams', '$resource', '$timeout', 'ngTableDataService', 'UsuarioService', 'ngDialog', 'toaster'];
    function UsuarioListController($state, $filter, ngTableParams, $resource, $timeout, ngTableDataService, UsuarioService, ngDialog, toaster) {
        var vm = this;

        //Variables
        vm.title = 'Controller';

        activate();

        //Methods
        vm.add = add;
        vm.edit = edit;
        vm.remove = remove;
        
        //Method definitions
        function activate() {
            fillGrid();
        }

        function add() {
            $state.go('app.usuario-add');
        }

        function edit(id) {
            $state.go('app.usuario-edit', { id: id });
        }

        function remove(user) {
            
            ngDialog.openConfirm({
                template: 'app/views/custom/ngdialog-template.html',
                controller: 'ngDialogController',
                data: {
                    title: 'Eliminar usuario',
                    message: 'Esta seguro de eliminar al usuario "' + user.NombreDeUsuario + '"?'
                }
            }).then(function (value) {
                UsuarioService.remove(user.Id)
                        .success(function (result) {
                            toaster.success('Eliminacion', 'Eliminado exitosamente.');
                            fillGrid();
                        });
            }, function (reason) {
                console.log('Se cancelo la eliminacion del usuario: ', reason);
            });
        }

        //Functions
        function fillGrid() {
            // SORTING
            // ----------------------------------- 
            vm.tableParams = new ngTableParams({
                page: 1,            // show first page
                count: 10,          // count per page
                sorting: {
                    name: 'asc'     // initial sorting
                }
            }, {
                //total: data.length, // length of data
                getData: function ($defer, params) {
                    // use build-in angular filter
                    var orderedData = params.sorting() ?
                            $filter('orderBy')(data, params.orderBy()) :
                            data;

                    $defer.resolve(orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count()));
                }
            });


            // AJAX
            vm.tableParams5 = new ngTableParams({
                page: 1,            // show first page
                count: 10,           // count per page
                sorting: {
                    Id: 'asc'     // initial sorting
                }
            }, {
                total: 0,           // length of data
                counts: [],         // hide page counts control
                getData: function ($defer, params) {

                    var filter = params.filter();
                    var sorting = params.sorting();
                    var count = params.count();
                    var page = params.page();
                    UsuarioService.getUsuarios(params.orderBy())
                        .success(function (result) {
                            vm.tableParams5.total(result.total);
                            $defer.resolve(result);
                        });
                }
            });
        }
    }
})();
