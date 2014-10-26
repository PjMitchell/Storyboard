﻿/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
describe('StoryOverviewDataService', function () {
    var fakeHttpService;
    var apiRoute;
    var service;

    beforeEach(function () {
        fakeHttpService = {};
        apiRoute = '/api/StoryOverview';
        service = new Home.StoryOverviewDataService(fakeHttpService);
    });

    describe('Get', function () {
        var httpResult;

        beforeEach(function () {
            httpResult = {};
            fakeHttpService.get = function (input) {
                return httpResult;
            };
        });

        it('Calls StoryOverview api', function () {
            spyOn(fakeHttpService, 'get');
            service.getAll();
            expect(fakeHttpService.get).toHaveBeenCalledWith(apiRoute);
        });

        it('Returns HttpResult', function () {
            var result = service.getAll();
            expect(result).toEqual(httpResult);
        });
    });

    describe('Add', function () {
        var httpResult;
        var command;

        beforeEach(function () {
            httpResult = {};
            fakeHttpService.post = function (input, data) {
                return httpResult;
            };
            command = new Home.AddUpdateStoryCommand();
            command.Id = 1;
        });

        it('Call StoryOverview api', function () {
            spyOn(fakeHttpService, 'post');
            service.add(command);
            expect(fakeHttpService.post).toHaveBeenCalledWith(apiRoute, command);
        });

        it('Returns HttpResult', function () {
            var result = service.add(command);
            expect(result).toEqual(httpResult);
        });
    });

    describe('Delete', function () {
        var httpResult;

        beforeEach(function () {
            httpResult = {};
            fakeHttpService.delete = function (input) {
                return httpResult;
            };
        });

        it('Call StoryOverview api', function () {
            spyOn(fakeHttpService, 'delete');
            var id = 1;
            service.delete(id);
            expect(fakeHttpService.delete).toHaveBeenCalledWith(apiRoute + '/' + id);
        });

        it('Returns HttpResult', function () {
            var result = service.delete(1);
            expect(result).toEqual(httpResult);
        });
    });
});
//# sourceMappingURL=StoryOverviewDataServiceTests.js.map
