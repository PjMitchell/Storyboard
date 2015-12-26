import {Component, Inject, OnInit} from 'angular2/core';
import {Router, ROUTER_DIRECTIVES} from 'angular2/router';
import {StoryOverviewDataService, IStoryOverviewDataService} from '../services/storyoverviewdataservice';
import * as model from '../Models/StoryModels';

@Component({
    templateUrl: '/Templates/Home/SummaryTemplate.html',
    directives: [ROUTER_DIRECTIVES]
})
export class SummaryComponent implements OnInit {
    

    constructor(@Inject(StoryOverviewDataService) private dataService: IStoryOverviewDataService, private router: Router) {
        this.Summaries = new Array<model.IStorySummary>();
    }
    public Summaries: model.IStorySummary[];

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
    private onSummariesReturned(result: model.IStorySummary[]){
        this.Summaries = result;
    };
}