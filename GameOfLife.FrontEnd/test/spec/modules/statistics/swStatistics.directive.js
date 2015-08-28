/*
    <copyright file="swStatistics.directive.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
*/

;(function() {
    'use strict';

    var element;

    describe('Directive: statistics', function() {

        beforeEach(module('gameOfLife.statistics', 'gameOfLife.test.templates'));

        beforeEach(inject(fixtureSetup));

        it('should be defined and accessible.', function() {
            expect(element.text()).not.toBe('');
        });

    });

    function fixtureSetup($compile, $rootScope) {
        element = $compile('<sw-statistics></sw-statistics>')($rootScope);
        $rootScope.$digest();
    }
})();
