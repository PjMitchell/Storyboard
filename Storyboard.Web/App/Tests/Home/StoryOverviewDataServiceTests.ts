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
        fakeHttpService.get = (input: string) => { return <ng.IHttpPromise<any>>{} };
        fakeHttpService.post = (input: string, data: any) => { return <ng.IHttpPromise<any>>{} };
        fakeHttpService.delete = (input: string) => { return <ng.IHttpPromise<any>>{}  };
        apiRoute = '/api/StoryOverview';
        service = new Home.StoryOverviewDataService(fakeHttpService);
    });

    it('Gets calls StoryOverview api', () => {
        
        
        spyOn(fakeHttpService, 'get');
        service.getAll();
        expect(fakeHttpService.get).toHaveBeenCalledWith(apiRoute);
    })

    it('Add call StoryOverview api', () => {
        
        spyOn(fakeHttpService, 'post');
        var command = new Home.AddUpdateStoryCommand()
        command.Id = 1;
        service.add(command);
        expect(fakeHttpService.post).toHaveBeenCalledWith(apiRoute, command);
    })

    it('Delete call StoryOverview api', () => {

        spyOn(fakeHttpService, 'delete');
        var id = 1;
        service.delete(id);
        expect(fakeHttpService.delete).toHaveBeenCalledWith(apiRoute+'/'+id);
    })

})



