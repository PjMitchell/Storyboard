/// <reference path="../../home/models/addupdatestorycommand.ts" />
/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/createactordialogcontroller.ts" />
/// <reference path="../../home/homemodule.ts" />
/// <reference path="../../home/models/addupdateactorcommand.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
describe('CreateActorDialogController', function () {
    var target;
    var modalInstance;
    var actorDataService;
    beforeEach(function () {
        modalInstance = {};
        modalInstance.dismiss = function (arg) {
        };
        actorDataService = {};
        target = new Home.CreateActorDialogController(modalInstance, actorDataService);
    });
    it('Can cancel', function () {
        spyOn(modalInstance, 'dismiss');
        target.cancel();
        expect(modalInstance.dismiss).toHaveBeenCalled();
    });
});
//# sourceMappingURL=CreateActorDialogControllerTests.js.map