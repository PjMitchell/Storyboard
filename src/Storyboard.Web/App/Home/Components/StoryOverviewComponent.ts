import {Component, Inject, OnInit} from 'angular2/core';
import {Router, RouteParams, ROUTER_DIRECTIVES} from 'angular2/router';
import {StoryDataService, IStoryDataService } from '../services/storydataservice';
import {ActorDataService, IActorDataService } from '../services/actordataservice';
import {OverviewDataService, IOverviewDataService } from '../services/overviewdataservice';
import * as models from '../models/storymodels';
import {EditTextBoxComponent, EditTextAreaComponent, IEditFieldEventArg} from './editfieldcomponents'

@Component({
    templateUrl: '/Templates/Home/StoryOverviewTemplate.html',
    directives: [ROUTER_DIRECTIVES, EditTextBoxComponent, EditTextAreaComponent]
})
export class StoryOverviewController implements OnInit {

    constructor( @Inject(StoryDataService) private storyDataService: IStoryDataService, @Inject(OverviewDataService) private overviewDataService: IOverviewDataService, @Inject(ActorDataService) private actorDataService: IActorDataService, private routeParams: RouteParams, private router: Router) {
    }

    Overview: models.IStoryOverview;
    IsLoaded: boolean;

    ngOnInit() {
        this.getOverview(+this.routeParams.get('id'));
    };

    openCreateActorDialog() {
        this.router.navigate(['CreateActor', { storyId: this.Overview.Summary.Id }]);
    }

    deleteActorCommand(id: number) {
        this.actorDataService.delete(id)
            .then(arg=> this.removeActor(id))
    }

    private getOverview(id: number) {
        this.overviewDataService.getStoryOverview(id)
            .then(value => this.onOverviewReturned(value));
    }

    private onOverviewReturned(story: models.IStoryOverview){
        this.Overview = story;
        this.IsLoaded = true;
    };
    
    private removeActor(id: number){
        this.Overview.Actors = this.Overview.Actors.filter((actor, index, actors) => {
            return actor.Id !== id;
        })
    };

    private updateTitle(arg: IEditFieldEventArg) {
        this.Overview.Summary.Title = arg.NewValue;
        this.storyDataService.put(this.Overview.Summary)
            .catch(reason => { this.Overview.Summary.Title = arg.OldValue; });
    }
    private updateSynopsis(arg: IEditFieldEventArg) {
        this.Overview.Summary.Synopsis = arg.NewValue;
        this.storyDataService.put(this.Overview.Summary)
            .catch(reason => { this.Overview.Summary.Synopsis = arg.OldValue; });
    }
};

