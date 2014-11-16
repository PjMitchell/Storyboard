/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
module Home {
    export class StoryOverviewController {
        static $inject = ['$scope', 'StoryOverviewDataService'];
        private dataService: Home.IStoryOverviewDataService;
        private scope: ng.IScope;

        constructor($scope: ng.IScope, StoryOverviewDataService: Home.IStoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.scope = $scope;
        }
    };
}
