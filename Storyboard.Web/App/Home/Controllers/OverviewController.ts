/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />

module Home {
    export interface IOverviewScope extends ng.IScope {
        Name: string;
        Summaries: Home.IStoryOverviewSummary[];
    }

    export class OverviewController {
        static $inject = ['$scope', 'StoryOverviewDataService'];
        private dataService: Home.StoryOverviewDataService;
        private scope: ng.IScope;
        
        constructor($scope: ng.IScope, StoryOverviewDataService :Home.StoryOverviewDataService) {
            this.scope = $scope;
            
            this.dataService = StoryOverviewDataService;
            this.getAllSummaries();
            //this.dataService.getAll().success(this.onSummariesReturned);
            this.Name = "Test";
            this.Summaries = [];
            
            
        }
        Name: string;
        Summaries: Home.IStoryOverviewSummary[];

        deleteStoryCommand(id: number) {
            this.dataService.delete(id).success(this.getAllSummaries);
        }

        //as lambda to prevent this context changing
        private getAllSummaries = () => {
            this.dataService.getAll().success(this.onSummariesReturned);
        }
        private onSummariesReturned = (result: IStoryOverviewSummary[]) => {
             this.Summaries = result;
             
        } 
    }
}