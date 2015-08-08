/*
    <copyright file="gridApi.service.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    var gridApi;

    describe('Service: gridApi', function() {

        beforeEach(module('gameOfLife.grid'));

        beforeEach(inject(fixtureSetup));

        it('should be defined and accessible through DI.', function() {
            expect(gridApi).toBeDefined();
        });

    });

    function fixtureSetup(_gridApi_) {
        gridApi = _gridApi_;
    }
})();
