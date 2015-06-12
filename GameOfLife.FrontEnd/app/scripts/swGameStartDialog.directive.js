/*
    <copyright file="swGameStartDialog.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
 */

;(function() {
    'use strict';

    angular
        .module('gameOfLife')
        .directive('swGameStartDialog', gameStartDialog);

    /** @ngInject */
    function gameStartDialog(game) {
        gameService = game;

        return {
            templateUrl: 'views/sw-game-start-dialog.html',
            restrict: 'E',
            controller: DialogController,
            controllerAs: 'vm'
        };
    }

    var gameService,
        vm,
        scope;

    /** @ngInject */
    function DialogController($scope) {
        var initSettings = gameService.getInitialSettings();

        vm = this;
        scope = $scope;

        vm.numberOfGenerations = initSettings.numberOfGenerations;
        vm.rules = initSettings.rules;
        vm.selectedRule = initSettings.selectedRule;
        vm.lifeForms = initSettings.lifeForms;
        vm.selectedLifeForm = initSettings.selectedLifeForm;

        vm.results = {success: false};
        vm.error = {failed: false};

        vm.runGame = runGame;
    }

    function runGame() {
        var options = {
            numberOfGenerations: vm.numberOfGenerations,
            rules: vm.selectedRule,
            lifeForm: vm.selectedLifeForm
        };

        vm.results.success = false;
        vm.error.failed = false;

        gameService
            .runGame(options)
            .done(function(data) {
                vm.results.success = true;
                vm.results.population = data.Population;
                vm.results.generation = data.Generation;
                vm.results.lastRuntime = data.LastRuntime;
                scope.$apply();
            }).fail(function(data) {
                vm.error.failed = true;
                vm.error.message = data.Message;
                scope.$apply();
            });
    }
})();
