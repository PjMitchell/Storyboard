/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/summaryController.ts" />
/// <reference path="../../home/models/storyModels.ts" />
describe('SummaryController', function () {
    var target;
    var scope;
    var dataService;
    var initialStories;
    beforeEach(function () {
        dataService = {};
        scope = {};
        initialStories = new Array();
        var storyOne = new Home.StorySummary();
        storyOne.Id = 1;
        storyOne.Title = 'Story 1';
        storyOne.Synopsis = 'Story 1 Overview';
        initialStories[0] = storyOne;
        dataService = {};
        dataService.getAll = function () {
            var promise = {};
            promise.success = function (callback) {
                callback(initialStories, 1, {}, {});
                return {};
            };
            return promise;
        };
    });
    it('OnConstruction Summaries are populated', function () {
        target = new Home.SummaryController(scope, dataService);
        expect(target.Summaries.length).toEqual(1);
        expect(target.Summaries[0].Id).toEqual(1);
    });
});
//# sourceMappingURL=SummaryControllerTests.js.map