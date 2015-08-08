/*
    <copyright file="gameClient.service.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    var gameClient;

    describe('Service: gameClient', function() {

        beforeEach(module('gameOfLife'));

        beforeEach(inject(fixtureSetup));

        it('should be defined and accessible through the DI system.', function() {
            expect(gameClient).toBeDefined();
        });

        it('should have a function for retrieving initial game settings.', function() {
            var settings = gameClient.getInitialSettings();

            expect(settings.numberOfGenerations).toBe(30);
            expect(settings.selectedRule).toEqual({value: 0, name: 'Standard'});
            expect(settings.selectedLifeForm).toEqual({value: 4, name: 'RandomPattern'});
            expect(settings.lifeForms.length).toBe(5);
            expect(settings.rules.length).toBe(2);
        });

    });

    function fixtureSetup(_gameClient_) {
        gameClient = _gameClient_;
    }
})();
