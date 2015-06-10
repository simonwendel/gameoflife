'use strict';

describe('Directive: swGameStartDialog', function () {

  // load the directive's module
  beforeEach(module('gameOfLifeApp'));

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
