﻿/// <reference path="../homemodule.ts" />
module Home {
    export class StoryOverviewDataService {
        private http: ng.IHttpService;
        constructor($http: ng.IHttpService) {
            this.http = $http;
        }

        public getAll() {
            return this.http.get<Home.IStoryOverviewSummary[]>('/api/StoryOverview'); 
        }
    }
} 