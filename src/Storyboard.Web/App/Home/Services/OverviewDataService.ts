import {Injectable, Inject} from 'angular2/core';
import * as models from '../models/storymodels';
import {IAddUpdateStoryCommand} from '../models/addupdatestorycommand';
import {HttpAdaptor, IHttpAdaptor} from '../../core/httpadaptor';

export interface IOverviewDataService {
    getStoryOverview(id: number): Promise<models.IStoryOverview>;
}
@Injectable()
export class OverviewDataService implements IOverviewDataService {
    private apiRoute = '/api/Overview';

    constructor(@Inject(HttpAdaptor) private http: IHttpAdaptor) {
    }

    public getStoryOverview(id: number) {
        return this.http.get<models.IStoryOverview>(this.apiRoute + '/' + id)
    }
  
};
 