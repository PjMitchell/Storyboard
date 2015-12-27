import {Component, Inject, OnInit} from 'angular2/core';
import {Router, RouteParams} from 'angular2/router';
import {ActorDataService, IActorDataService} from '../services/actordataservice';
import * as model from '../models/storymodels';
import {ICreateActorCommand} from '../models/createactorcommand';
import * as links from '../models/linkmodels';

@Component({
    templateUrl: '/Templates/Home/CreateActorTemplate.html'
})
export class CreateActorComponent implements OnInit {
    private storyLink: links.ICreateLinkForNewNodeCommand;
    private storyId: number;
    constructor( @Inject(ActorDataService) private dataService: IActorDataService, private router: Router, routeParam: RouteParams) {
        this.storyId = + routeParam.get('storyId')
        this.storyLink = {
            NodeBId: this.storyId,
            NodeBType: links.NodeTypeEnum.Story,
            Direction: links.LinkFlow.Bidirectional,
            Strength: 1,
            Type: 1
        };
        this.Actor = {
            Id: 0,
            Name: '',
            Description: ''
        };
        this.Command = {
            ActorCommand: this.Actor,
            Links: [this.storyLink]
        };
    }
    Actor: model.IActor
    Command: ICreateActorCommand

    ngOnInit() {
    }

    save() {
        this.dataService.add(this.Command)
            .then(returnedId => this.router.navigate(['StoryOverview', { id: this.storyId }]));
    }
    //saveAndOpen() {
    //    this.dataService.add(this.Command)
    //        .then(id => this.router.navigate(['StoryOverview', { id: id }]));
    //}
    cancel() {
        this.router.navigate(['StoryOverview', { id: this.storyId }]);
    }
}
