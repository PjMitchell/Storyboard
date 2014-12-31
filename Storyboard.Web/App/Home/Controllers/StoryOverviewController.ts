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
        static $inject = ['$routeParams', '$modal', 'StoryOverviewDataService', 'LinkDataService'];
        private storyDataService: IStoryOverviewDataService;
        private modalService: ui.IModalService;
        private linkDataService: ILinkDataService;
        Overview: StoryOverview;

        private onOverviewReturned = (story: Home.StoryOverview) => { this.Overview = story; };
        private onLinkSaved = () => {
            this.getOverview(this.Overview.Summary.Id)
        };
        private onActorSaved = (id: number) => {
            this.linkDataService.add(new CreateLinkRequest(new Node(this.Overview.Summary.Id, NodeTypeEnum.Story), new Node(id, NodeTypeEnum.Actor)))
                .then(this.onLinkSaved);
        }; 

        constructor($routeParams: IIdRouteParam, $modal: ui.IModalService, StoryOverviewDataService: IStoryOverviewDataService, LinkDataService: ILinkDataService) {
            this.storyDataService = StoryOverviewDataService;
            this.modalService = $modal;
            this.linkDataService = LinkDataService;
            this.getOverview($routeParams.id);          
        }

        private getOverview(id: number) {
            this.storyDataService.get(id).success(this.onOverviewReturned);

        }

        public openCreateActorDialog() {
            var settings = <ui.IModalSettings>
                {
                    templateUrl: 'App/Home/Views/CreateActorDialogView.html',
                    controller: 'CreateActorDialogController',
                    controllerAs:'vm'
                }
            this.modalService.open(settings).result.then(this.onActorSaved);
        }
    };
}
