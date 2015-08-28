/*
    <copyright file="swGameStartDialog.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    var gameClient,
        element,
        scope;

    describe('Directive: swGameStartDialog', function() {

        beforeEach(module('gameOfLife.startDialog', 'gameOfLife.test.templates', setupMock));

        beforeEach(inject(buildElement));

        it('should be defined and accessible.', function() {
            expect(element).toBeDefined();
        });

        describe('Function: runGame', function() {

            it('should call the runGame function on the gameClient.', function() {
                scope.vm.runGame();
                expect(gameClient.runGame.calledOnce).toBeTruthy();
            });

        });

    });

    function buildElement($compile, $rootScope) {
        element = $compile(
            '<sw-game-start-dialog></sw-game-start-dialog>')($rootScope);
        $rootScope.$digest();
        scope = element.scope();
    }

    function setupMock($provide) {
        gameClient = mockGameClient();
        sinon.spy(gameClient, 'runGame');

        $provide.value('gameClient', gameClient);
    }

    function mockGameClient() {
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
            },
            runGame: function () {}
        };
    }
})();
