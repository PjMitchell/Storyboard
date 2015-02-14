module Home {
    export interface IActorDataService {
        get(id:number): ng.IHttpPromise<Actor>;
        add(command: AddUpdateActorCommand): ng.IHttpPromise<number>;
        put(command: AddUpdateActorCommand): ng.IHttpPromise<{}>;
        delete(id: number): ng.IHttpPromise<{}>;
    }

    export class ActorDataService implements IActorDataService {
        private http: ng.IHttpService;
        private apiRoute = '/api/Actor';
        constructor($http: ng.IHttpService) {
            this.http = $http;
        }

        public get(id: number) {
            return this.http.get(this.apiRoute + '/' + id);
        }

        public add(command: AddUpdateActorCommand) {
            return this.http.post(this.apiRoute, command);
        }

        public put(command: AddUpdateActorCommand) {
            return this.http.put(this.apiRoute + '/' + command.Id, command);
        }


        public delete(id: number) {
            return this.http.delete(this.apiRoute + '/' + id);
        }
    };
}  