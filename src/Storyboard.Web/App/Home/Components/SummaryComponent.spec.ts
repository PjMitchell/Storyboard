/// <reference path="../../../node_modules/angular2/typings/jasmine/jasmine.d.ts" />
/// <reference path="../../../typings/jasmine-es6-promise-matchers/jasmine-es6-promise-matchers.d.ts" />

import {Component, Inject, OnInit} from 'angular2/core';
import {Router, ROUTER_DIRECTIVES} from 'angular2/router';
import {StoryDataService, IStoryDataService} from '../services/storydataservice';
import {SummaryComponent} from './summarycomponent'
import * as model from '../Models/StoryModels';

describe('Summary Component', () => {
    var dataService: IStoryDataService,
        router: Router,
        target: SummaryComponent,
        stories: model.IStory[];
    beforeEach(() => {
        dataService = <IStoryDataService>{};
        router = <Router>{};
        router.navigate = (args: any[]) => { return Promise.resolve() };
        target = new SummaryComponent(dataService, router);
    })


    it('Summaries is an empty array on construction', () => {
        expect(target.Summaries).toBeDefined();
        expect(target.Summaries.length).toBe(0);
    })

    it('openCreateStoryDialog navigates to correct page', () => {
        spyOn(router, 'navigate');
        target.openCreateStoryDialog();
        expect(router.navigate).toHaveBeenCalledWith(['CreateStory']);

    })
    describe('init', () => {
        beforeEach((done) => {
            stories = [new model.Story()]
            dataService.getAll = () => {
                return new Promise(success => {
                    success(stories);
                });
            };
            target.ngOnInit();
            setTimeout(() => {done() }, 10)
            },6000)

        it('populates Summaries', () => {
            expect(target.Summaries).toBe(stories);
        })
        
    });

    //describe('delete story command', () => {
    //    beforeEach((done) => {
    //        stories = [new model.Story()]
    //        dataService.delete = (id:number) => {
    //            return Promise.resolve();
    //        }
    //        dataService.getAll = () => {
    //            return Promise.resolve(stories);                
    //        };
    //        spyOn(dataService, 'delete');
    //        spyOn(dataService, 'getAll');
    //        target.deleteStoryCommand(2);
    //        setTimeout(() => { done() }, 10)
    //    }, 6000);
    //    it('calls data service with id', () => {
    //        expect(dataService.delete).toHaveBeenCalledWith(2)
    //    });
    //    it('calls get all', () => {
    //        expect(dataService.getAll).toHaveBeenCalled()
    //    });
    //});
})