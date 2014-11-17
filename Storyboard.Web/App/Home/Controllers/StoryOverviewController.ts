/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />

module Home {
    export interface IIdRouteParam {
        id: number;
    }


    export class StoryOverviewController {
        static $inject = ['$scope','$routeParams', 'StoryOverviewDataService'];
        private dataService: Home.IStoryOverviewDataService;
        private scope: ng.IScope;

        Overview: StoryOverview;

        private onOverviewReturned = (story: Home.StoryOverview) => { this.Overview = story;};

        constructor($scope: ng.IScope, $routeParams: IIdRouteParam, StoryOverviewDataService: Home.IStoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.scope = $scope;

            this.dataService.get($routeParams.id).success(this.onOverviewReturned);
        }
    };
}
