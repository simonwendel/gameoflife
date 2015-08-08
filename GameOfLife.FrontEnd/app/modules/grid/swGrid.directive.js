/*
    <copyright file="swGrid.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    angular
        .module('gameOfLife.grid')
        .directive('swGrid', grid);

    /** @ngInject */
    function grid() {
        return {
            templateUrl: 'modules/grid/swGrid.directive.html',
            restrict: 'E',
            controller: GridController,
            controllerAs: 'vm'
        };
    }

    /** @ngInject */
    function GridController() {
    }
})();
