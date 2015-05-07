/// <reference path="../../home/models/addupdatestorycommand.ts" />
/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../home/controllers/summaryController.ts" />
/// <reference path="../../home/models/storyModels.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
describe('SummaryController', (): void => {
    var target: Home.SummaryController;
    var modalService: ng.ui.bootstrap.IModalService;
    var dataService: Home.IStoryOverviewDataService;
    var initialStories: Home.IStorySummary[];

    beforeEach((): void=> {
        dataService = <Home.IStoryOverviewDataService>{};
        modalService = <ng.ui.bootstrap.IModalService>{};
        initialStories = new Array<Home.IStorySummary>();
        var storyOne = new Home.StorySummary();
        storyOne.Id = 1;
        storyOne.Title = 'Story 1';
        storyOne.Synopsis = 'Story 1 Overview';
        initialStories[0] = storyOne;
        dataService = <Home.IStoryOverviewDataService>{};

        dataService.getAll = () => {
            var promise = <ng.IHttpPromise<Home.StorySummary[]>>{};
            promise.success = (callback: ng.IHttpPromiseCallback<Home.StorySummary[]>) => {
                callback(initialStories, 1, <ng.IHttpHeadersGetter>{}, <ng.IRequestConfig>{});
                return <ng.IHttpPromise<Home.IStorySummary[]>>{};
            };
            return promise;
        };

    });

    it('OnConstruction Summaries are populated', (): void => {
        target = new Home.SummaryController(modalService, dataService);
        expect(target.Summaries.length).toEqual(1);
        expect(target.Summaries[0].Id).toEqual(1);
    });

});