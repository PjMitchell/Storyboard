import {Component, Inject, OnInit} from 'angular2/core';
import {Router, RouteParams, ROUTER_DIRECTIVES} from 'angular2/router';
import {StoryOverviewDataService, IStoryOverviewDataService } from '../services/storyoverviewdataservice';
import * as models from '../models/storymodels';
import {EditTextBoxComponent, IEditFieldEventArg} from './editfield'

@Component({
    templateUrl: '/Templates/Home/StoryOverviewTemplate.html',
    directives: [ROUTER_DIRECTIVES, EditTextBoxComponent]
})
export class StoryOverviewController implements OnInit {
    //private modalService: ng.ui.bootstrap.IModalService;
    //private linkDataService: ILinkDataService;
    //private actorDataService: IActorDataService


    private removeActor = (id: number) => {
        this.Overview.Actors = this.Overview.Actors.filter((actor, index, actors) => {
            return actor.Id !== id;
        })
    };
    //private onLinkSaved = () => {
    //    this.getOverview(this.Overview.Summary.Id)
    //};
    //private onActorSaved = (id: number) => {
    //    this.linkDataService.add(new CreateLinkRequest(new Node(this.Overview.Summary.Id, NodeTypeEnum.Story), new Node(id, NodeTypeEnum.Actor)))
    //        .then(this.onLinkSaved);
    //}; 
    constructor( @Inject(StoryOverviewDataService) private storyDataService: IStoryOverviewDataService, private routeParams: RouteParams) {
        //this.modalService = $modal;
        //this.linkDataService = LinkDataService;
        //this.actorDataService = ActorDataService;
    }

    Overview: models.IStoryOverview;
    IsLoaded: boolean;

    ngOnInit() {
        this.getOverview(+this.routeParams.get('id'));
    };

    openCreateActorDialog() {
        //var settings = <ng.ui.bootstrap.IModalSettings>
        //    {
        //        templateUrl: '/Templates/CreateActorDialogView.html',
        //        controller: 'CreateActorDialogController',
        //        controllerAs:'vm'
        //    }
        //this.modalService.open(settings).result.then(this.onActorSaved);
    }

    private getOverview(id: number) {
        this.storyDataService.get(id)
            .then(value => this.onOverviewReturned(value));
    }

    private onOverviewReturned(story: models.IStoryOverview){
        this.Overview = story;
        this.IsLoaded = true;
    };
    
    updateTitle(arg: IEditFieldEventArg) {
        this.Overview.Summary.Title = arg.NewValue;
        this.storyDataService.put(this.Overview.Summary)
            .catch(reason => { this.Overview.Summary.Title = arg.OldValue; });
    }

    //public update() {
    //    this.storyDataService.put(this.Overview.Summary)
    //}

    //public deleteActorCommand(id: number) {
    //    this.actorDataService.delete(id).then(arg=> this.removeActor(id))
    //}
};

