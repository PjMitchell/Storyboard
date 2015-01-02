﻿/// <reference path="../homemodule.ts" />
/// <reference path="../models/storymodels.ts" />

module Home {
    export interface IStoryOverviewDataService {
        getAll(): ng.IHttpPromise<Home.IStorySummary[]>;
        get(id: number): ng.IHttpPromise<Home.StoryOverview>;
        add(command: Home.AddUpdateStoryCommand): ng.IHttpPromise<{}>;
        delete(id: number): ng.IHttpPromise<{}>;
    }

    export class StoryOverviewDataService implements IStoryOverviewDataService {
        private http: ng.IHttpService;
        private apiRoute = '/api/StoryOverview';
        constructor($http: ng.IHttpService) {
            this.http = $http;
        }

        public getAll() {
            return this.http.get<Home.IStorySummary[]>(this.apiRoute);
        }
        public get(id: number) {
            return this.http.get(this.apiRoute + '/' + id);
        }

        public add(command: Home.AddUpdateStoryCommand) {
            return this.http.post(this.apiRoute, command);
        }

        public delete(id: number) {
            return this.http.delete(this.apiRoute + '/' + id);
        }
    };
} 