// <copyright file="gamecontroller.js" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

;(function($) {
    'use strict';

    angular
        .module('gameOfLife.app')
        .controller('GameController', GameController);

    /** @ngInject */
    function GameController() {
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
    }

    function runGame(options, outputSelector) {
        $.post(
            'Home/RunGame',
            options,
            function(data) {
                var output = $(outputSelector).empty();
                output.append(data);
            });
    }

    $(function() {
        $('#dialog').dialog({
            modal: true,
            title: 'Game Of Life',
            closeOnEscape: false,
            dialogClass: 'no-close',
            buttons: [{
                text: 'Run game',
                click: function() {
                    var options = $('#options :input').serialize();
                    runGame(options, '#output');
                }
            }]
        });
    });
})(jQuery);
