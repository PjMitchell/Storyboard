/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />

module Home {
    export interface IActorOverviewRouteParam {
        id: number;
        storyId: number;
    }

    export class ActorOverviewController {
        static $inject = ['$routeParams', 'ActorDataService'];
        private storyDataService: IStoryOverviewDataService;
        private modalService: ng.ui.bootstrap.IModalService;
        private linkDataService: ILinkDataService;
        private actorDataService: IActorDataService
        Overview: Actor;
        StoryId: number;
        IsLoaded: boolean;
        private onOverviewReturned = (actor: Actor) => {
            this.Overview = actor;
            this.IsLoaded = true;
        };

        constructor($routeParams: IActorOverviewRouteParam, ActorDataService: IActorDataService) {
            this.actorDataService = ActorDataService;
            this.StoryId = $routeParams.storyId;
            this.getOverview($routeParams.id);
        }

        private getOverview(id: number) {
            this.actorDataService.get(id).success(this.onOverviewReturned);

        }

        public update() {
            this.actorDataService.put(this.Overview)
        }
    };
} 