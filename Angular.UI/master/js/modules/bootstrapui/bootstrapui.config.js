(function() {
    'use strict';

    angular
        .module('app.bootstrapui')
        .config(bootstrapuiConfig);

    bootstrapuiConfig.$inject = ['$uibTooltipProvider', 'uibDatepickerConfig', 'uibDatepickerPopupConfig'];
    function bootstrapuiConfig($uibTooltipProvider, uibDatepickerConfig, uibDatepickerPopupConfig) {
        $uibTooltipProvider.options({ appendToBody: true });

        uibDatepickerConfig.showWeeks = false;
        uibDatepickerPopupConfig.showButtonBar = false;
        uibDatepickerPopupConfig.datepickerPopup = 'dd-MM-yyyy';
    }
})();