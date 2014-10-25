/// <reference path="../../../scripts/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../home/services/storyoverviewdataservice.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
describe('StoryOverviewDataService', function () {
    var fakeHttpService;
    var apiRoute;
    var service;

    beforeEach(function () {
        fakeHttpService = {};
        fakeHttpService.get = function (input) {
            return {};
        };
        fakeHttpService.post = function (input, data) {
            return {};
        };
        fakeHttpService.delete = function (input) {
            return {};
        };
        apiRoute = '/api/StoryOverview';
        service = new Home.StoryOverviewDataService(fakeHttpService);
    });

    it('Gets calls StoryOverview api', function () {
        spyOn(fakeHttpService, 'get');
        service.getAll();
        expect(fakeHttpService.get).toHaveBeenCalledWith(apiRoute);
    });

    it('Add call StoryOverview api', function () {
        spyOn(fakeHttpService, 'post');
        var command = new Home.AddUpdateStoryCommand();
        command.Id = 1;
        service.add(command);
        expect(fakeHttpService.post).toHaveBeenCalledWith(apiRoute, command);
    });

    it('Delete call StoryOverview api', function () {
        spyOn(fakeHttpService, 'delete');
        var id = 1;
        service.delete(id);
        expect(fakeHttpService.delete).toHaveBeenCalledWith(apiRoute + '/' + id);
    });
});
//# sourceMappingURL=StoryOverviewDataServiceTests.js.map
