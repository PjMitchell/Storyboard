/// <reference path="../../home/models/addupdatestorycommand.ts" />
/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/storyoverviewcontroller.ts" />
/// <reference path="../../home/models/storyModels.ts" />

describe('StoryOverviewController', (): void => {
    var target: Home.StoryOverviewController;
    var scope: ng.IScope;
    var route: Home.IIdRouteParam;
    var dataService: Home.IStoryOverviewDataService;
    var returnedOverview: Home.StoryOverview;

    beforeEach((): void=> {
        dataService = <Home.IStoryOverviewDataService>{};
        scope = <ng.IScope>{};
        returnedOverview = new Home.StoryOverview();
        returnedOverview.Summary = new Home.StorySummary();

        var storyOne = new Home.StorySummary();
        storyOne.Id = 23;
        storyOne.Title = 'Story 1';
        storyOne.Synopsis = 'Story 1 Overview';
        returnedOverview.Summary = storyOne;

        route = { id: returnedOverview.Summary.Id };

        dataService = <Home.IStoryOverviewDataService>{};

        dataService.get = (id:number) => {
            var promise = <ng.IHttpPromise<Home.StoryOverview>>{};
            promise.success = (callback: ng.IHttpPromiseCallback<Home.StoryOverview>) => {
                if (id === returnedOverview.Summary.Id) {
                    callback(returnedOverview, 1, <ng.IHttpHeadersGetter>{}, <ng.IRequestConfig>{});
                } else {
                    callback(new Home.StoryOverview, 1, <ng.IHttpHeadersGetter>{}, <ng.IRequestConfig>{});
                }

                return <ng.IHttpPromise<Home.StoryOverview>>{};
            };
            return promise;
        };
    });

    it('OnConstruction Overview is populated', (): void => {

        target = new Home.StoryOverviewController(scope, route, dataService);
        expect(target.Overview.Summary.Id).toEqual(returnedOverview.Summary.Id);
        expect(target.Overview.Summary.Title).toEqual(returnedOverview.Summary.Title);
    });

}); 