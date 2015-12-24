import {Component, Inject} from 'angular2/core';
import {StoryOverviewDataService, IStoryOverviewDataService} from '../Services/StoryOverviewDataService';
import * as model from '../Models/StoryModels';

@Component({
    providers: [StoryOverviewDataService],
    templateUrl: '/Templates/Home/SummaryTemplate.html'
})
export class SummaryComponent {
    private getAllSummaries: () => void;
    private onSummariesReturned: (result: model.IStorySummary[]) => void;
    public Summaries: model.IStorySummary[];

    constructor( @Inject(StoryOverviewDataService) private dataService: IStoryOverviewDataService) {
        this.Summaries = new Array<model.IStorySummary>();
        this.getAllSummaries = () => {
            this.dataService.getAll().then(this.onSummariesReturned);
        };
        this.onSummariesReturned = (result: model.IStorySummary[]) => {
            this.Summaries = result;
        };
        this.getAllSummaries();    
    }

    deleteStoryCommand(id: number) {
        this.dataService.delete(id).then(this.getAllSummaries);
    }

    public openCreateStoryDialog() {
        //var settings = <ng.ui.bootstrap.IModalSettings>
        //    {
        //        controller: 'CreateStoryDialogController',
        //        controllerAs: 'vm',
        //        templateUrl: '/Templates/CreateStoryDialogView.html'
        //    }
        //this.modalService.open(settings).result.then(this.onNewStory);
        this.getAllSummaries();
    }

}