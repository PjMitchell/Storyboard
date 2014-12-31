/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
/// <reference path="../services/actordataservice.ts" />

module Home {

    import ui = ng.ui.bootstrap;

    export class CreateActorDialogController {
        static $inject = ['$modalInstance', 'ActorDataService'];
        
        private instance: ui.IModalServiceInstance;
        private dataService: Home.IActorDataService;

        private onSaveComplete = (id: number) => {
            this.instance.close(id);
        };

        constructor($modalInstance: ui.IModalServiceInstance, ActorDataService: Home.IActorDataService) {
            this.instance = $modalInstance;
            this.dataService = ActorDataService;
            this.Command = new Home.AddUpdateActorCommand();
        }

        public Command: Home.AddUpdateActorCommand;

        public cancel() {
            this.instance.dismiss();
        }
        public ok() {
            this.dataService.add(this.Command).success(this.onSaveComplete)
        }
        
        
    };
} 