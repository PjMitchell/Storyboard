/// <reference path="../models/addupdatestorycommand.ts" />
/// <reference path="../models/storymodels.ts" />

module Home {
    export interface IStoryOverviewDataService {
        getAll(): ng.IHttpPromise<IStorySummary[]>;
        get(id: number): ng.IHttpPromise<StoryOverview>;
        add(command: AddUpdateStoryCommand): ng.IHttpPromise<{}>;
        put(command: AddUpdateStoryCommand): ng.IHttpPromise<{}>;
        delete(id: number): ng.IHttpPromise<{}>;
    }

    export class StoryOverviewDataService implements IStoryOverviewDataService {
        private http: ng.IHttpService;
        private apiRoute = '/api/StoryOverview';

        constructor($http: ng.IHttpService) {
            this.http = $http;
        }

        public getAll() {
            return this.http.get<IStorySummary[]>(this.apiRoute);
        }
        public get(id: number) {
            return this.http.get(this.apiRoute + '/' + id);
        }

        public add(command: AddUpdateStoryCommand) {
            return this.http.post(this.apiRoute, command);
        }

        public put(command: AddUpdateStoryCommand) {
            return this.http.put(this.apiRoute + '/' + command.Id, command);
        }

        public delete(id: number) {
            return this.http.delete(this.apiRoute + '/' + id);
        }
    };
} 