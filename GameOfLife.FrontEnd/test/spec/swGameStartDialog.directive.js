/*
    <copyright file="game.js" company="N/A">
        Copyright (C) Simon Wendel 2013-2015.
    </copyright>
 */

'use strict';

describe('Directive: swGameStartDialog', function () {

  // load the directive's module
  beforeEach(module('gameOfLife.app'));

  var element,
    scope;

  beforeEach(inject(function ($rootScope) {
    scope = $rootScope.$new();
  }));

  it('should make hidden element visible', inject(function ($compile) {
    element = angular.element('<sw-game-start-dialog></sw-game-start-dialog>');
    element = $compile(element)(scope);
    expect(element.text()).toBe('this is the swGameStartDialog directive');
  }));
});
