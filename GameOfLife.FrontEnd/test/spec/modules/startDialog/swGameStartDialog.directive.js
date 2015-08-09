/*
    <copyright file="swGameStartDialog.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    describe('Directive: swGameStartDialog', function() {

        beforeEach(module(
            'gameOfLife.startDialog',
            'gameOfLife.templates',
            function($provide) {
                $provide.factory('gameClient', gameClientMock);
            }));

        it('should be defined and accessible.', inject(function($compile, $rootScope) {
            var element = $compile(
                '<sw-game-start-dialog></sw-game-start-dialog>')($rootScope);
            $rootScope.$digest();

            expect(element).toBeDefined();
        }));

    });

    function gameClientMock() {
        return {
            init: function() {},
            getInitialSettings: function() {
                return {
                    numberOfGenerations: 0,
                    rules: [],
                    selectedRule: 0,
                    lifeForms: [],
                    selectedLifeForm: 0
                };
            }
        };
    }
})();
