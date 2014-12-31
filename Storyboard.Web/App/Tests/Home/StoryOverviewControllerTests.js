/// <reference path="../../home/models/addupdatestorycommand.ts" />
/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/storyoverviewcontroller.ts" />
/// <reference path="../../home/models/storyModels.ts" />
/// <reference path="../../home/homemodule.ts" />
describe('StoryOverviewController', function () {
    var target;
    var route;
    var dataService;
    var returnedOverview;
    var modalService;
    var linkDataService;
    var actorDataService;
    beforeEach(function () {
        dataService = {};
        linkDataService = {};
        actorDataService = {};
        modalService = {};
        returnedOverview = new Home.StoryOverview();
        returnedOverview.Summary = new Home.StorySummary();
        var storyOne = new Home.StorySummary();
        storyOne.Id = 23;
        storyOne.Title = 'Story 1';
        storyOne.Synopsis = 'Story 1 Overview';
        returnedOverview.Summary = storyOne;
        route = { id: returnedOverview.Summary.Id };
        dataService = {};
        dataService.get = function (id) {
            var promise = {};
            promise.success = function (callback) {
                if (id === returnedOverview.Summary.Id) {
                    callback(returnedOverview, 1, {}, {});
                }
                else {
                    callback(new Home.StoryOverview, 1, {}, {});
                }
                return {};
            };
            return promise;
        };
        target = new Home.StoryOverviewController(route, modalService, dataService, linkDataService, actorDataService);
    });
    it('OnConstruction Overview is populated', function () {
        expect(target.Overview.Summary.Id).toEqual(returnedOverview.Summary.Id);
        expect(target.Overview.Summary.Title).toEqual(returnedOverview.Summary.Title);
    });
    describe('OpenCreateActorDialog', function () {
        var modalPayload;
        beforeEach(function () {
            modalService.open = function (option) {
                modalPayload = option;
                return {};
            };
        });
        it('OpensDialog', function () {
            spyOn(modalService, 'open');
            target.openCreateActorDialog();
            expect(modalService.open).toHaveBeenCalled();
        });
    });
});
//# sourceMappingURL=StoryOverviewControllerTests.js.map