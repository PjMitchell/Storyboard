/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../services/actordataservice.ts" />
/// <reference path="../models/addupdateactorcommand.ts" />


module Home {

    export class CreateActorDialogController {
        static $inject = ['$modalInstance', 'ActorDataService'];
        
        private instance: ng.ui.bootstrap.IModalServiceInstance;
        private dataService: IActorDataService;

        private onSaveComplete = (id: number) => {
            this.instance.close(id);
        };

        constructor($modalInstance: ng.ui.bootstrap.IModalServiceInstance, ActorDataService: IActorDataService) {
            this.instance = $modalInstance;
            this.dataService = ActorDataService;
            this.Command = new AddUpdateActorCommand();
        }

        public Command: AddUpdateActorCommand;

        public cancel() {
            this.instance.dismiss();
        }
        public ok() {
            this.dataService.add(this.Command).success(this.onSaveComplete)
        }
        
        
    };
} 