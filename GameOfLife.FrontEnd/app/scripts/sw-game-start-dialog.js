// <copyright file="sw-game-start-dialog.js" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

;(function() {
    'use strict';

    angular
        .module('gameOfLife.app')
        .directive('swGameStartDialog', gameStartDialog);

    function gameStartDialog() {
        return {
            templateUrl: 'partials/sw-game-start-dialog.html',
            restrict: 'E',
            link: postLink,
            controller: DialogController,
            controllerAs: 'vm'
        };
    }

    function postLink() {
        jQuery('.sw-dialog').dialog({
            modal: true,
            title: 'Game Of Life',
            closeOnEscape: false,
            dialogClass: 'no-close',
            buttons: [{
                text: 'Run game',
                click: function() {
                    var options = jQuery('.sw-dialog :input').serialize();
                    runGame(options);
                }
            }]
        });
    }

    /** @ngInject */
    function DialogController(game) {
        var vm = this,
            initSettings = game.getInitialSettings();

        vm.numberOfGenerations = initSettings.numberOfGenerations;
        vm.rules = initSettings.rules;
        vm.selectedRule = initSettings.selectedRule;
        vm.lifeForms = initSettings.lifeForms;
        vm.selectedLifeForm = initSettings.selectedLifeForm;
        vm.runGame = runGame;
    }

    function runGame(options) {
        jQuery.post(
            'Home/RunGame',
            options,
            function(data) {
                var output = jQuery('#output').empty();
                output.append(data);
            });
    }
})();
