import {Component, Inject} from 'angular2/core';
import {Router} from 'angular2/router';
import {StoryOverviewDataService, IStoryOverviewDataService} from '../services/storyoverviewdataservice';
import * as model from '../models/storymodels';
import {AddUpdateStoryCommand} from '../models/addupdatestorycommand';


@Component({
    providers: [StoryOverviewDataService],
    templateUrl: '/Templates/Home/CreateStoryTemplate.html'
})
export class CreateStoryComponent {
    constructor( @Inject(StoryOverviewDataService) private dataService: IStoryOverviewDataService, private router: Router) {
        this.Command = new AddUpdateStoryCommand();
    }

    Command: AddUpdateStoryCommand

    save() {
        this.dataService.add(this.Command)
            .then(() =>this.router.navigate(['Summary']));
    }
    cancel() {
        this.router.navigate(['Summary']);
    }


}