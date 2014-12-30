/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />

module Home {

    import ui = ng.ui.bootstrap;

    export class CreateActorDialogController {
        static $inject = ['$modalInstance'];
        
        private instance: ui.IModalServiceInstance;

        Overview: StoryOverview;

        private onOverviewReturned = (story: Home.StoryOverview) => { this.Overview = story; };

        constructor($modalInstance: ui.IModalServiceInstance) {
            this.instance = $modalInstance;
        }

        
    };
} 