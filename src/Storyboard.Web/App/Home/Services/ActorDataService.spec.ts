/// <reference path="../../../node_modules/angular2/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../typings/jasmine-es6-promise-matchers/jasmine-es6-promise-matchers.d.ts" />

import {ActorDataService, IActorDataService} from './actordataservice'
import {IHttpAdaptor, IPostResult} from '../../core/httpadaptor'
import {ICreateActorCommand} from '../models/createactorCommand';
import * as models from '../models/storymodels'

describe('ActorDataService', () => {
    var target: IActorDataService,
        httpAdaptor: IHttpAdaptor;
    beforeEach(() => {
        httpAdaptor = <IHttpAdaptor>{}
        target = new ActorDataService(httpAdaptor);
        JasminePromiseMatchers.install();
    });
    afterEach(JasminePromiseMatchers.uninstall)
    it('Get by Id calls correct route', () => {
        var id = 23,
            route = '/api/Actor/23'

        httpAdaptor.get = (input: string) => {
            return new Promise<models.IActor>(() => { });
        }

        spyOn(httpAdaptor, 'get');
        target.get(id)
        expect(httpAdaptor.get).toHaveBeenCalledWith(route);
    });       

    it('Get by Id Returns Promise from adaptor', () => {
        var id = 23,
            promise = new Promise<models.IActor>(() => { });

        httpAdaptor.get = (input: string) => {
            return promise;
        }

        var result = target.get(id);
        expect(result).toEqual(promise);
    });

    it('add calls correct params', () => {
        var route = '/api/Actor',
            data = <ICreateActorCommand>{},
            apiResponse: IPostResult<ICreateActorCommand> = {
            location: '',
            value: {
                ActorCommand: { Id: 23, Name: '', Description: '' },
                Links: []
            }
            },
            promise = Promise.resolve<IPostResult<ICreateActorCommand>>(apiResponse),
            routeParam: string,
            dataParam: ICreateActorCommand;
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
        var apiResponse: IPostResult<ICreateActorCommand> = {
            location: '',
            value: {
                ActorCommand: { Id: 23, Name: '', Description: '' },
                Links: []
            }
        },
            id: number,
            promise = Promise.resolve<IPostResult<ICreateActorCommand>>(apiResponse);


        httpAdaptor.post = (input: string, data: any) => {
            return promise;
        };

        var result = target.add(<ICreateActorCommand>{});
        expect(result).toBeResolvedWith(apiResponse.value.ActorCommand.Id);
    });
    
    it('update calls correct params', () => {
        var route = '/api/Actor/23',
            data = new models.Actor(),
            promise = Promise.resolve(),
            routeParam: string,
            dataParam: models.IActor;
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

        var result = target.update(<models.IActor>{});
        expect(result).toBe(promise);
    });

    it('delete calls correct params', () => {
        var route = '/api/Actor/23',
            data = new models.Actor(),
            promise = Promise.resolve(),
            routeParam: string,
            dataParam: models.IActor;
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
