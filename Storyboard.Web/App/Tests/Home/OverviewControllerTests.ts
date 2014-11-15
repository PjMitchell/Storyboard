/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/overviewcontroller.ts" />
/// <reference path="../../home/models/storyoverviewsummary.ts" />

describe('OverviewController', (): void => {
    var target: Home.OverviewController;
    var scope: ng.IScope;
    var dataService: Home.IStoryOverviewDataService;
    var initialStories: Home.IStoryOverviewSummary[];

    beforeEach((): void=> {
        dataService = <Home.IStoryOverviewDataService>{};
        scope = <ng.IScope>{};
        initialStories = new Array<Home.IStoryOverviewSummary>();
        var storyOne = new Home.StoryOverviewSummary();
        storyOne.Id = 1;
        storyOne.Title = 'Story 1';
        storyOne.Synopsis = 'Story 1 Overview';
        initialStories[0] = storyOne;
        dataService = <Home.IStoryOverviewDataService>{};

        dataService.getAll = () => {
            var promise = <ng.IHttpPromise<Home.StoryOverviewSummary[]>>{};
            promise.success = (callback: ng.IHttpPromiseCallback<Home.StoryOverviewSummary[]>) => {
                callback(initialStories, 1, <ng.IHttpHeadersGetter>{}, <ng.IRequestConfig>{});
                return <ng.IHttpPromise<Home.IStoryOverviewSummary[]>>{};
            };
            return promise;
        };
    });

    it('OnConstruction Summaries are populated', (): void => {
        target = new Home.OverviewController(scope, dataService);
        expect(target.Summaries.length).toEqual(1);
        expect(target.Summaries[0].Id).toEqual(1);
    });

});