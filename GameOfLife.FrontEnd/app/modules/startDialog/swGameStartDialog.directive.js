/*
    <copyright file="swGameStartDialog.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    angular
        .module('gameOfLife.startDialog')
        .directive('swGameStartDialog', gameStartDialog);

    /** @ngInject */
    function gameStartDialog(gameClient) {
        game = gameClient;

        return {
            templateUrl: 'modules/startDialog/swGameStartDialog.directive.html',
            restrict: 'E',
            controller: DialogController,
            controllerAs: 'vm'
        };
    }

    var game,
        vm,
        scope;

    /** @ngInject */
    function DialogController($scope) {
        var initSettings = game.getInitialSettings();

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
        game.init(displayResults, displayError);
    }

    function displayError(message) {
        vm.error.failed = true;
        vm.failed.message = message;
        scope.$apply();
    }

    function displayResults(results) {
        vm.results.success = true;
        vm.results.population = results.Population;
        vm.results.generation = results.Generation;
        vm.results.lastRuntime = results.LastRuntime;
        scope.$apply();
    }

    function runGame() {
        var options = {
            numberOfGenerations: vm.numberOfGenerations,
            rules: vm.selectedRule.value,
            lifeForm: vm.selectedLifeForm.value
        };

        vm.results.success = false;
        vm.error.failed = false;

        game
            .runGame(options);
    }
})();
