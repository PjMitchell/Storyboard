import {Injectable, Inject} from 'angular2/core';
import * as models from '../models/storymodels';
import {OverviewDataService, IOverviewDataService} from './overviewdataservice';
import {IHttpAdaptor} from '../../core/httpadaptor';
/// <reference path="../../../node_modules/angular2/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../typings/jasmine-es6-promise-matchers/jasmine-es6-promise-matchers.d.ts" />
describe('Overview data service', () => {
    var target: IOverviewDataService,
        httpAdaptor: IHttpAdaptor;
    beforeEach(() => {
        httpAdaptor = <IHttpAdaptor>{}
        target = new OverviewDataService(httpAdaptor);
        JasminePromiseMatchers.install();
    });
    afterEach(JasminePromiseMatchers.uninstall)


    it('Get by Id calls correct route', () => {
        var id = 23,
            route = '/api/Overview/23'

        httpAdaptor.get = (input: string) => {
            return new Promise<models.IStory>(() => { });
        }

        spyOn(httpAdaptor, 'get');
        target.getStoryOverview(id)
        expect(httpAdaptor.get).toHaveBeenCalledWith(route);
    });

    it('Get by Id Returns Promise from adaptor', () => {
        var id = 23,
            promise = new Promise<models.IStoryOverview>(() => { });

        httpAdaptor.get = (input: string) => {
            return promise;
        }

        var result = target.getStoryOverview(id);
        expect(result).toEqual(promise);
    });
})