import {Component, Inject, OnInit} from 'angular2/core';
import {Router, ROUTER_DIRECTIVES} from 'angular2/router';
import {StoryDataService, IStoryDataService} from '../services/storydataservice';
import * as model from '../Models/StoryModels';

@Component({
    templateUrl: '/Templates/Home/SummaryTemplate.html',
    directives: [ROUTER_DIRECTIVES]
})
export class SummaryComponent implements OnInit {
    

    constructor(@Inject(StoryDataService) private dataService: IStoryDataService, private router: Router) {
        this.Summaries = new Array<model.IStory>();
    }
    public Summaries: model.IStory[];

    ngOnInit() {
        this.getAllSummaries();
    };

    deleteStoryCommand(id: number) {
        this.dataService.delete(id)
            .then(() => this.getAllSummaries());
    }

    openCreateStoryDialog() {
        this.router.navigate(['CreateStory']);
    }

    private getAllSummaries() {
        this.dataService.getAll()
            .then(result => this.onSummariesReturned(result));
    };
    private onSummariesReturned(result: model.IStory[]){
        this.Summaries = result;
    };
}