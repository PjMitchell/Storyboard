module Home {
    export interface IActorDataService {
        add(command: Home.AddUpdateActorCommand): ng.IHttpPromise<number>;
        delete(id: number): ng.IHttpPromise<{}>;
    }

    export class ActorDataService implements IActorDataService {
        private http: ng.IHttpService;
        private apiRoute = '/api/Actor';
        constructor($http: ng.IHttpService) {
            this.http = $http;
        }
        
        public add(command: Home.AddUpdateActorCommand) {
            return this.http.post(this.apiRoute, command);
        }

        public delete(id: number) {
            return this.http.delete(this.apiRoute + '/' + id);
        }
    };
}  