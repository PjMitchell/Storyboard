import {Injectable, Inject} from 'angular2/core';
import * as models from '../models/storymodels';
import {ICreateActorCommand} from '../models/createactorcommand';
import {HttpAdaptor, IHttpAdaptor} from '../../core/httpadaptor';

export interface IActorDataService {
    //getAll(): Promise<models.IStory[]>;
    get(id: number): Promise<models.IActor>;
    add(command: ICreateActorCommand): Promise<number>;
    update(command: models.IActor): Promise<void>;
    delete(id: number): Promise<void>;
}
@Injectable()
export class ActorDataService implements IActorDataService {
    private apiRoute = '/api/Actor';

    constructor(@Inject(HttpAdaptor) private http: IHttpAdaptor) {
    }

    //public getAll() {
    //    return this.http.get<models.IActor[]>(this.apiRoute)
    //}
    public get(id: number) {
        return this.http.get<models.IActor>(this.apiRoute + '/' + id)
    }

    public add(command: ICreateActorCommand) {
        return this.http.post<ICreateActorCommand>(this.apiRoute, command)
            .then(value => value.value.ActorCommand.Id);
    }

    public update(command: models.IActor) {
        return this.http.put(this.apiRoute + '/' + command.Id, command);
    }

    public delete(id: number) {
        return this.http.delete(this.apiRoute + '/' + id);           
    }
};
 