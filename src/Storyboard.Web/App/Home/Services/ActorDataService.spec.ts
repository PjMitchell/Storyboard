/// <reference path="../../../node_modules/angular2/typings/jasmine/jasmine.d.ts" />
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
    });
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
            promise = Promise.resolve<IPostResult<ICreateActorCommand>>(apiResponse);
        httpAdaptor.post = (input: string, data: any) => {
            return promise;
        };

        spyOn(httpAdaptor, 'post');
        target.add(data)
        expect(httpAdaptor.post).toHaveBeenCalledWith(route, data);
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
        result.then(i => id = i);
        
        expect(id).toEqual(apiResponse.value.ActorCommand.Id);
    });
        
});
