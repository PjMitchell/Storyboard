import {Component, Inject, OnInit} from 'angular2/core';
import {Router, RouteParams, ROUTER_DIRECTIVES} from 'angular2/router';
import * as models from '../models/storymodels';
import {EditTextBoxComponent, EditTextAreaComponent, IEditFieldEventArg} from './editfieldcomponents'
import {SideBarComponent} from './sidebarcomponent';
import {ActorDataService, IActorDataService} from '../services/actordataservice';
@Component({
    templateUrl: '/Templates/Home/ActorOverviewTemplate.html',
    directives: [ROUTER_DIRECTIVES, EditTextBoxComponent, EditTextAreaComponent, SideBarComponent]
})
export class ActorOverviewController implements OnInit {
    Overview: models.IActor;
    StoryId: number;
    Id: number;
    IsLoaded: boolean;


    constructor( @Inject(ActorDataService) private actorDataService: IActorDataService, routeParam: RouteParams) {
        this.StoryId = +routeParam.get('storyId');
        this.Id = +routeParam.get('id');
    }

    ngOnInit() {
        this.getOverview(this.Id);
    }

    updateName(arg: IEditFieldEventArg) {
        this.Overview.Name = arg.NewValue;
        this.actorDataService.update(this.Overview)
            .catch(reason => { this.Overview.Name = arg.OldValue; });
    }

    updateDescription(arg: IEditFieldEventArg) {
        this.Overview.Description = arg.NewValue;
        this.actorDataService.update(this.Overview)
            .catch(reason => { this.Overview.Description = arg.OldValue; });
    }

    private onOverviewReturned(actor: models.IActor) {
        this.Overview = actor;
        this.IsLoaded = true;
    };
    private getOverview(id: number) {
        this.actorDataService.get(id)
            .then(result => this.onOverviewReturned(result));

    }

    
};
