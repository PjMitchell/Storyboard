import {Component, Inject} from 'angular2/core';
import {Router} from 'angular2/router';
import {StoryDataService, IStoryDataService} from '../services/storydataservice';
import * as model from '../models/storymodels';
import {AddUpdateStoryCommand} from '../models/addupdatestorycommand';


@Component({
    providers: [StoryDataService],
    templateUrl: '/Templates/Home/CreateStoryTemplate.html'
})
export class CreateStoryComponent {
    constructor( @Inject(StoryDataService) private dataService: IStoryDataService, private router: Router) {
        this.Command = new AddUpdateStoryCommand();
    }

    Command: AddUpdateStoryCommand

    save() {
        this.dataService.add(this.Command)
            .then(command =>this.router.navigate(['Summary']));
    }
    saveAndOpen() {
        this.dataService.add(this.Command)
            .then(id => this.router.navigate(['StoryOverview', { id: id }]));
    }
    cancel() {
        this.router.navigate(['Summary']);
    }


}