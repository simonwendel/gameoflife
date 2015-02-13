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
            templateUrl: '../partials/sw-game-start-dialog.html',
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
    function DialogController() {
        var vm = this;

        vm.numberOfGenerations = 30;

        vm.rules = [
            {value: 0, name: 'Standard'},
            {value: 1, name: 'Sierpinskish'}
        ];

        vm.selectedRule = vm.rules[0];

        vm.lifeForms = [
            {value: 0, name: 'Empty'},
            {value: 1, name: 'Acorn'},
            {value: 2, name: 'AircraftCarrier'},
            {value: 3, name: 'FivePoint'},
            {value: 4, name: 'RandomPattern'}
        ];

        vm.selectedLifeForm =
            vm.lifeForms[vm.lifeForms.length - 1];

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
