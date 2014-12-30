/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />

module Home {
    export interface IIdRouteParam {
        id: number;
    }
    import ui = ng.ui.bootstrap;

    export class StoryOverviewController {
        static $inject = ['$routeParams','$modal', 'StoryOverviewDataService'];
        private dataService: Home.IStoryOverviewDataService;
        private modalService: ui.IModalService;

        Overview: StoryOverview;

        private onOverviewReturned = (story: Home.StoryOverview) => { this.Overview = story;};

        constructor($routeParams: IIdRouteParam, $modal: ui.IModalService, StoryOverviewDataService: IStoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.modalService = $modal;

            this.dataService.get($routeParams.id).success(this.onOverviewReturned);
        }

        public OpenCreateActorDialog() {
            var settings = <ui.IModalSettings>
                {
                    templateUrl: 'App/Home/Views/CreateActorDialogView.html',
                    controller: 'CreateActorDialogController',
                    controllerAs:'vm'
                }
            this.modalService.open(settings);
        }
    };
}
