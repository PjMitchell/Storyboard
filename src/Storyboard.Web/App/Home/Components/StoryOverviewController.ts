///// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
///// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
///// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
///// <reference path="../models/storymodels.ts" />
///// <reference path="../services/actordataservice.ts" />
///// <reference path="../services/linkdataservice.ts" />
///// <reference path="../services/storyoverviewdataservice.ts" />
///// <reference path="../models/createlinkcommand.ts" />
//module Home {
//    export interface IIdRouteParam {
//        id: number;
//    }
    
//    export class StoryOverviewController {
//        static $inject = ['$routeParams', '$modal', 'StoryOverviewDataService', 'LinkDataService', 'ActorDataService'];
//        private storyDataService: IStoryOverviewDataService;
//        private modalService: ng.ui.bootstrap.IModalService;
//        private linkDataService: ILinkDataService;
//        private actorDataService: IActorDataService
//        Overview: StoryOverview;
//        IsLoaded: boolean;
//        private onOverviewReturned = (story: StoryOverview) => {
//            this.Overview = story;
//            this.IsLoaded = true;
//        };
//        private removeActor = (id: number) => {
//            this.Overview.Actors = this.Overview.Actors.filter((actor, index, actors) => {
//                return actor.Id !== id;
//            })
//        };
//        private onLinkSaved = () => {
//            this.getOverview(this.Overview.Summary.Id)
//        };
//        private onActorSaved = (id: number) => {
//            this.linkDataService.add(new CreateLinkRequest(new Node(this.Overview.Summary.Id, NodeTypeEnum.Story), new Node(id, NodeTypeEnum.Actor)))
//                .then(this.onLinkSaved);
//        }; 

//        constructor($routeParams: IIdRouteParam, $modal: ng.ui.bootstrap.IModalService, StoryOverviewDataService: IStoryOverviewDataService, LinkDataService: ILinkDataService, ActorDataService: IActorDataService) {
//            this.storyDataService = StoryOverviewDataService;
//            this.modalService = $modal;
//            this.linkDataService = LinkDataService;
//            this.actorDataService = ActorDataService;
//            this.getOverview($routeParams.id);          
//        }

//        private getOverview(id: number) {
//            this.storyDataService.get(id).success(this.onOverviewReturned);

//        }

//        public openCreateActorDialog() {
//            var settings = <ng.ui.bootstrap.IModalSettings>
//                {
//                    templateUrl: '/Templates/CreateActorDialogView.html',
//                    controller: 'CreateActorDialogController',
//                    controllerAs:'vm'
//                }
//            this.modalService.open(settings).result.then(this.onActorSaved);
//        }
//        public update() {
//            this.storyDataService.put(this.Overview.Summary)
//        }


//        public deleteActorCommand(id: number) {
//            this.actorDataService.delete(id).then(arg=> this.removeActor(id))
//        }
//    };
//}
