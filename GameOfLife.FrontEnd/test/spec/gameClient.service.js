/*
    <copyright file="gameClient.service.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    var gameClient;

    describe('Factory: gameClient', function() {

        beforeEach(module('gameOfLife'));

        beforeEach(inject(fixtureSetup));

        it('should be defined and accessible through the DI system.', function() {
            expect(gameClient).toBeDefined();
        });

    });

    function fixtureSetup(_gameClient_) {
        gameClient = _gameClient_;
    }
})();
