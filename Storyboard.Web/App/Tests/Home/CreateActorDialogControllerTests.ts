/// <reference path="../../home/models/addupdatestorycommand.ts" />
/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/createactordialogcontroller.ts" />
/// <reference path="../../home/homemodule.ts" />

describe('CreateActorDialogController', (): void => {
    var target: Home.CreateActorDialogController;
    var modalInstance: ui.IModalServiceInstance;
    var actorDataService : Home.IActorDataService;
    beforeEach(function () {
        modalInstance = <ui.IModalServiceInstance> {};
        modalInstance.dismiss = arg => { };
        actorDataService = <Home.IActorDataService> {};
        target = new Home.CreateActorDialogController(modalInstance, actorDataService);
    });
    it('Can cancel', () => {
        spyOn(modalInstance, 'dismiss');
        target.cancel();
        expect(modalInstance.dismiss).toHaveBeenCalled();
    })
}); 