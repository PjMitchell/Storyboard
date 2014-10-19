/// <reference path="../homemodule.ts" />
module Home {
    export interface IStoryOverviewDataService {
        getAll(): ng.IHttpPromise<Home.IStoryOverviewSummary[]>
        add(command: Home.AddUpdateStoryCommand): ng.IHttpPromise<{}>
        delete(id: number): ng.IHttpPromise<{}>
    }

    export class StoryOverviewDataService implements IStoryOverviewDataService {
        private http: ng.IHttpService;
        private apiRoute = '/api/StoryOverview';
        constructor($http: ng.IHttpService) {
            this.http = $http;
        }

        public getAll() {
            return this.http.get<Home.IStoryOverviewSummary[]>(this.apiRoute); 
        }

        public add(command: Home.AddUpdateStoryCommand) {
            return this.http.post(this.apiRoute, command)
        }

        public delete(id: number) {
            return this.http.delete(this.apiRoute + '/' + id)
        }
    }
} 