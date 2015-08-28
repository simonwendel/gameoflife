/*
    <copyright file="swGrid.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
 */

;(function() {
    'use strict';

    var element;

    describe('Directive: swGrid', function() {

        beforeEach(module('gameOfLife.grid', 'gameOfLife.test.templates'));

        beforeEach(inject(fixtureSetup));

        it('should be defined and accessible.', function() {
            expect(element).toBeDefined();
        });

    });

    function fixtureSetup($compile, $rootScope) {
        element = $compile('<sw-grid></sw-grid>')($rootScope);
        $rootScope.$digest();
    }
})();
