/*
    <copyright file="swStatistics.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    angular
        .module('gameOfLife.statistics')
        .directive('swStatistics', statistics);

    /** @ngInject */
    function statistics() {
        return {
            templateUrl: 'modules/statistics/swStatistics.directive.html',
            restrict: 'E',
            controller: StatisticsController,
            controllerAs: 'vm'
        };
    }

    /** @ngInject */
    function StatisticsController() {
    }
})();
