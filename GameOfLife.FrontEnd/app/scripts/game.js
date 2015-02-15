// <copyright file="game.js" company="N/A">
//      Copyright (C) Simon Wendel 2013-2015.
// </copyright>

;(function() {
    'use strict';

    angular.module('gameOfLife.app')
        .factory('game', game);

    /** @ngInject */
    function game() {
        return {
            getInitialSettings: initialSettings,
            runGame: runGame
        };
    }

    function initialSettings() {
        var availableRules = [
                {value: 0, name: 'Standard'},
                {value: 1, name: 'Sierpinskish'}],
            availableLifeForms = [
                {value: 0, name: 'Empty'},
                {value: 1, name: 'Acorn'},
                {value: 2, name: 'AircraftCarrier'},
                {value: 3, name: 'FivePoint'},
                {value: 4, name: 'RandomPattern'}];

        return {
            numberOfGenerations: 30,
            rules: availableRules,
            selectedRule: availableRules[0],
            lifeForms: availableLifeForms,
            selectedLifeForm: availableLifeForms[4]
        };
    }

    function runGame(options) {
        return jQuery.post(
            '/Home/RunGame',
            options);
    }
})();
