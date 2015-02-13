;(function() {
    'use strict';

    angular
        .module('gameOfLife.app')
        .controller('GameController', GameController);

    /** @ngInject */
    function GameController() {
        var vm = this;

        vm.numberOfGenerations = 30;

        vm.rules = [
            { value: 0, name: 'Standard'},
            { value: 1, name: 'Sierpinskish'}
        ];

        vm.selectedRule = vm.rules[0];

        vm.lifeForms = [
            { value: 0, name: 'Empty' },
            { value: 1, name: 'Acorn' },
            { value: 2, name: 'AircraftCarrier' },
            { value: 3, name: 'FivePoint' },
            { value: 4, name: 'RandomPattern' }
        ];

        vm.selectedLifeForm =
            vm.lifeForms[vm.lifeForms.length - 1];
    }
})();
