/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />


describe('StoryOverviewDataService', () => {
    var fakeHttpService: ng.IHttpService;
    var apiRoute: string;
    var service: Home.IStoryOverviewDataService;

    beforeEach(() =>
    {
        fakeHttpService = <ng.IHttpService>{};
        apiRoute = '/api/StoryOverview';
        service = new Home.StoryOverviewDataService(fakeHttpService);
    });

    describe('Get', () => {
        var httpResult: ng.IHttpPromise<any>

        beforeEach(() => {
            httpResult = <ng.IHttpPromise<any>>{};
            fakeHttpService.get = (input: string) => { return httpResult };
        });

        it('Calls StoryOverview api', () => {
            spyOn(fakeHttpService, 'get');
            service.getAll();
            expect(fakeHttpService.get).toHaveBeenCalledWith(apiRoute);
        })

        it('Returns HttpResult', () => {
            var result = service.getAll();
            expect(result).toEqual(httpResult);
        })
    })

    describe('Add', () => {
        var httpResult: ng.IHttpPromise<any>
        var command: Home.AddUpdateStoryCommand

        beforeEach(() => {
            httpResult = <ng.IHttpPromise<any>>{};
            fakeHttpService.post = (input: string, data: any) => { return httpResult };
            command = new Home.AddUpdateStoryCommand()
            command.Id = 1;
        });

        it('Call StoryOverview api', () => {
            spyOn(fakeHttpService, 'post');
            service.add(command);
            expect(fakeHttpService.post).toHaveBeenCalledWith(apiRoute, command);
        })

        it('Returns HttpResult', () => {
            var result = service.add(command);
            expect(result).toEqual(httpResult);
        })
    })

    describe('Delete', () => {
        var httpResult: ng.IHttpPromise<any>

        beforeEach(() => {
            httpResult = <ng.IHttpPromise<any>>{};
            fakeHttpService.delete = (input: string) => { return httpResult };
        });

        it('Call StoryOverview api', () => {
            spyOn(fakeHttpService, 'delete');
            var id = 1;
            service.delete(id);
            expect(fakeHttpService.delete).toHaveBeenCalledWith(apiRoute + '/' + id);
        })

        it('Returns HttpResult', () => {
            var result = service.delete(1);
            expect(result).toEqual(httpResult);
        })
    })

})



