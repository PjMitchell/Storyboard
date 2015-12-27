import {Injectable, Inject} from 'angular2/core';
import * as models from '../models/storymodels';
import {IAddUpdateStoryCommand} from '../models/addupdatestorycommand';
import {HttpAdaptor, IHttpAdaptor} from '../../core/httpadaptor';

export interface IStoryDataService {
    getAll(): Promise<models.IStory[]>;
    get(id: number): Promise<models.IStory>;
    add(command: IAddUpdateStoryCommand): Promise<number>;
    put(command: IAddUpdateStoryCommand): Promise<void>;
    delete(id: number): Promise<void>;
}
@Injectable()
export class StoryDataService implements IStoryDataService {
    private apiRoute = '/api/Story';

    constructor(@Inject(HttpAdaptor) private http: IHttpAdaptor) {
    }

    public getAll() {
        return this.http.get<models.IStory[]>(this.apiRoute)
    }
    public get(id: number) {
        return this.http.get<models.IStory>(this.apiRoute + '/' + id)
    }

    public add(command: IAddUpdateStoryCommand) {
        return this.http.post<IAddUpdateStoryCommand>(this.apiRoute, command)
            .then(value => value.value.Id);
    }

    public put(command: IAddUpdateStoryCommand) {
        return this.http.put(this.apiRoute + '/' + command.Id, command);
    }

    public delete(id: number) {
        return this.http.delete(this.apiRoute + '/' + id);           
    }
};
 