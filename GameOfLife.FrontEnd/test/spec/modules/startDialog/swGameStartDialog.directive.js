/*
    <copyright file="swGameStartDialog.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    var element,
        provide;

    describe('Directive: swGameStartDialog', function() {

        beforeEach(
            module('gameOfLife', 'gameOfLife.startDialog', 'gameOfLife.templates',
                function($provide) {
                    provide = $provide;
                }));

        beforeEach(inject(fixtureSetup));

        it('should be defined and accessible.', function() {
            expect(element).toBeDefined();
        });

    });

    function fixtureSetup($compile, $rootScope) {
        provide.factory('gameClient', gameClientMock);
        element = $compile('<sw-game-start-dialog></sw-game-start-dialog>')($rootScope);
        $rootScope.$digest();
    }

    function gameClientMock() {
        return {
            init: function() {},
            getInitialSettings: function() {
                return {
                    numberOfGenerations: 30,
                    rules: [],
                    selectedRule: 1,
                    lifeForms: [],
                    selectedLifeForm: 1
                };
            }
        };
    }
})();
