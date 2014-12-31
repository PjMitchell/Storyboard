module Home {
    export interface ILinkDataService {
        add(command: Home.CreateLinkRequest): ng.IHttpPromise<{}>;
        //delete(id: number): ng.IHttpPromise<{}>;
    }

    export class LinkDataService implements ILinkDataService {
        private http: ng.IHttpService;
        private apiRoute = '/api/Link';
        constructor($http: ng.IHttpService) {
            this.http = $http;
        }

        public add(command: Home.CreateLinkRequest) {
            return this.http.post(this.apiRoute, command);
        }

        //public delete(id: number) {
        //    return this.http.delete(this.apiRoute + '/' + id);
        //}
    };
}   