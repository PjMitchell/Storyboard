/// <reference path="homemodule.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

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
            this.dataService.getAll().success(this.onSummariesReturned);
            this.Name = "Test";
            this.Summaries = [];
            
            
        }
        Name: string;
        Summaries: Home.IStoryOverviewSummary[];
         private onSummariesReturned = (result: IStoryOverviewSummary[]) => {
             this.Summaries = result;
             
        } 
    }
}