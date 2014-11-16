/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />

module Home {

    export class SummaryController {
        static $inject = ['$scope', 'StoryOverviewDataService'];
        private dataService: Home.IStoryOverviewDataService;
        private scope: ng.IScope;
        private getAllSummaries: () => void;
        private onSummariesReturned: (result: IStorySummary[]) => void;

        Summaries: Home.IStorySummary[];

        constructor($scope: ng.IScope, StoryOverviewDataService: Home.IStoryOverviewDataService) {
            this.scope = $scope;
            this.dataService = StoryOverviewDataService;
            this.Summaries = [];

            this.getAllSummaries = () => {
                this.dataService.getAll().success(this.onSummariesReturned);
            };
            this.onSummariesReturned = (result: IStorySummary[]) => {
                this.Summaries = result;
            };

            this.getAllSummaries();
        }

        deleteStoryCommand(id: number) {
            this.dataService.delete(id).success(this.getAllSummaries);
        }
    }
}