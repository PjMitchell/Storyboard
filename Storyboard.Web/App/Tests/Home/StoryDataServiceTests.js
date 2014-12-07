/// <reference path="../../home/services/storydataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" /> 
describe('StoryOverviewDataService', function () {
    var fakeHttpService, apiRoute, service;
    beforeEach(function () {
        fakeHttpService = {};
        apiRoute = '/api/Story';
        service = new Home.StoryDataService(fakeHttpService);
    });
    //describe('Add new actor',() => {
    //    var httpResult: ng.IHttpPromise<any>;
    //    beforeEach(() => {
    //        httpResult = <ng.IHttpPromise<any>>{};
    //        fakeHttpService.get = (input: string) => { return httpResult; };
    //    });
    //    it('Calls StoryOverview api', () => {
    //        spyOn(fakeHttpService, 'get');
    //        service.getAll();
    //        expect(fakeHttpService.get).toHaveBeenCalledWith(apiRoute);
    //    });
    //    it('Returns HttpResult', () => {
    //        var result = service.getAll();
    //        expect(result).toEqual(httpResult);
    //    });
    //});
});
//# sourceMappingURL=StoryDataServiceTests.js.map