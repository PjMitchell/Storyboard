/// <reference path="../../../node_modules/angular2/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../typings/jasmine-es6-promise-matchers/jasmine-es6-promise-matchers.d.ts" />

import {StoryDataService, IStoryDataService} from './storydataservice'
import {IHttpAdaptor, IPostResult} from '../../core/httpadaptor'
import {IAddUpdateStoryCommand} from '../models/addupdatestoryCommand';
import * as models from '../models/storymodels'

describe('StoryDataService', () => {
    var target: IStoryDataService,
        httpAdaptor: IHttpAdaptor;
    beforeEach(() => {
        httpAdaptor = <IHttpAdaptor>{}
        target = new StoryDataService(httpAdaptor);
        JasminePromiseMatchers.install();
    });
    afterEach(JasminePromiseMatchers.uninstall)

    it('GetAll calls correct route', () => {
        var route = '/api/Story'

        httpAdaptor.get = (input: string) => {
            return new Promise<models.IStory>(() => { });
        }

        spyOn(httpAdaptor, 'get');
        target.getAll();
        expect(httpAdaptor.get).toHaveBeenCalledWith(route);
    });

    it('GetAll Returns Promise from adaptor', () => {
        var promise = new Promise<models.IStory[]>(() => { });

        httpAdaptor.get = (input: string) => {
            return promise;
        }

        var result = target.getAll();
        expect(result).toEqual(promise);
    });

    it('Get by Id calls correct route', () => {
        var id = 23,
            route = '/api/Story/23'

        httpAdaptor.get = (input: string) => {
            return new Promise<models.IStory>(() => { });
        }

        spyOn(httpAdaptor, 'get');
        target.get(id)
        expect(httpAdaptor.get).toHaveBeenCalledWith(route);
    });       

    it('Get by Id Returns Promise from adaptor', () => {
        var id = 23,
            promise = new Promise<models.IStory>(() => { });

        httpAdaptor.get = (input: string) => {
            return promise;
        }

        var result = target.get(id);
        expect(result).toEqual(promise);
    });

    it('add calls correct params', () => {
        var route = '/api/Story',
            data = <IAddUpdateStoryCommand>{},
            apiResponse: IPostResult<IAddUpdateStoryCommand> = {
                location: '',
                value: { Id: 23, Title: '', Synopsis: '' }
            },
            promise = Promise.resolve<IPostResult<IAddUpdateStoryCommand>>(apiResponse),
            routeParam: string,
            dataParam: IAddUpdateStoryCommand;
        httpAdaptor.post = (input: string, dataInput: any) => {
            routeParam = input;
            dataParam = dataInput;
            return promise;
        };

        var result = target.add(data)
        expect(routeParam).toEqual(route);
        expect(dataParam).toBe(data);
    });

    it('add Returns Id', () => {
        var apiResponse: IPostResult<IAddUpdateStoryCommand> = {
            location: '',
            value: { Id: 23, Title: '', Synopsis: '' }
            },
            id: number,
            promise = Promise.resolve<IPostResult<IAddUpdateStoryCommand>>(apiResponse);


        httpAdaptor.post = (input: string, data: any) => {
            return promise;
        };

        var result = target.add(<IAddUpdateStoryCommand>{});
        expect(result).toBeResolvedWith(apiResponse.value.Id);
    });
    
    it('update calls correct params', () => {
        var route = '/api/Story/23',
            data = new models.Story(),
            promise = Promise.resolve(),
            routeParam: string,
            dataParam: models.IStory;
        httpAdaptor.put = (input: string, dataInput: any) => {
            routeParam = input;
            dataParam = dataInput;
            return promise;
        };
        data.Id = 23;
        var result = target.update(data)
        expect(routeParam).toEqual(route);
        expect(dataParam).toBe(data);
    });

    it('update Returns Promise', () => {
        var promise = Promise.resolve();


        httpAdaptor.put = (input: string, data: any) => {
            return promise;
        };

        var result = target.update(<models.IStory>{});
        expect(result).toBe(promise);
    });

    it('delete calls correct params', () => {
        var route = '/api/Story/23',
            data = new models.Story(),
            promise = Promise.resolve(),
            routeParam: string,
            dataParam: models.IStory;
        httpAdaptor.delete = (input: string) => {
            routeParam = input;
            return promise;
        };
        var result = target.delete(23)
        expect(routeParam).toEqual(route);
    });

    it('delete Returns Promise', () => {
        var promise = Promise.resolve();


        httpAdaptor.delete = (input: string) => {
            return promise;
        };

        var result = target.delete(23);
        expect(result).toBe(promise);
    });
});
