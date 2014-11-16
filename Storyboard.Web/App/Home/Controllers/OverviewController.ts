/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />

module Home {
    
    export class OverviewController {
        static $inject = ['$scope', 'StoryOverviewDataService'];
        private dataService: Home.IStoryOverviewDataService;
        private scope: ng.IScope;
        
        constructor($scope: ng.IScope, StoryOverviewDataService :Home.IStoryOverviewDataService) {
            this.scope = $scope;
            this.dataService = StoryOverviewDataService;
            this.Summaries = [];
            this.getAllSummaries();            
        }

        Summaries: Home.IStorySummary[];

        deleteStoryCommand(id: number) {
            this.dataService.delete(id).success(this.getAllSummaries);
        }

        //as lambda to prevent this context changing
        private getAllSummaries = () => {
            this.dataService.getAll().success(this.onSummariesReturned);
        }
        private onSummariesReturned = (result: IStorySummary[]) => {
             this.Summaries = result;
        } 
    }
}