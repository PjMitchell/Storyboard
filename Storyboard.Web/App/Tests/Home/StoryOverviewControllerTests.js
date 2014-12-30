/// <reference path="../../home/models/addupdatestorycommand.ts" />
/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/storyoverviewcontroller.ts" />
/// <reference path="../../home/models/storyModels.ts" />
describe('StoryOverviewController', function () {
    var target;
    var route;
    var dataService;
    var returnedOverview;
    var modalService;
    beforeEach(function () {
        dataService = {};
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
    });
    it('OnConstruction Overview is populated', function () {
        target = new Home.StoryOverviewController(route, modalService, dataService);
        expect(target.Overview.Summary.Id).toEqual(returnedOverview.Summary.Id);
        expect(target.Overview.Summary.Title).toEqual(returnedOverview.Summary.Title);
    });
});
//# sourceMappingURL=StoryOverviewControllerTests.js.map