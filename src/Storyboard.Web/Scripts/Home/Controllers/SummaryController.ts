/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../services/storyoverviewdataservice.ts" />
/// <reference path="../models/storymodels.ts" />

module Home {

    export class SummaryController {
        static $inject = ['$modal','StoryOverviewDataService'];
        private dataService: IStoryOverviewDataService;
        private modalService: ng.ui.bootstrap.IModalService;
        private getAllSummaries: () => void;
        private onSummariesReturned: (result: IStorySummary[]) => void;

        Summaries: IStorySummary[];

        constructor($modal: ng.ui.bootstrap.IModalService, StoryOverviewDataService: Home.IStoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.modalService = $modal;
            this.Summaries = [];

            this.getAllSummaries = () => {
                this.dataService.getAll().success(this.onSummariesReturned);
            };
            this.onSummariesReturned = (result: IStorySummary[]) => {
                this.Summaries = result;
            };

            this.getAllSummaries();
        }

        private onNewStory = () => {
            this.getAllSummaries();
        }; 

        deleteStoryCommand(id: number) {
            this.dataService.delete(id).success(this.getAllSummaries);
        }

        public openCreateStoryDialog() {
            var settings = <ng.ui.bootstrap.IModalSettings>
                {
                    controller: 'CreateStoryDialogController',
                    controllerAs: 'vm',
                    templateUrl: '/Templates/CreateStoryDialogView.html'
                }
            this.modalService.open(settings).result.then(this.onNewStory);
        }
    }
}