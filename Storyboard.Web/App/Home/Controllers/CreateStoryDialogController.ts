/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/addupdatestorycommand.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
module Home {
    export class CreateStoryDialogController {
        static $inject = ['$modalInstance','StoryOverviewDataService'];
        private dataService: Home.StoryOverviewDataService;
        private instance: ng.ui.bootstrap.IModalServiceInstance;         
        constructor($modalInstance: ng.ui.bootstrap.IModalServiceInstance, StoryOverviewDataService :Home.StoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.instance = $modalInstance;
            this.Command = new Home.AddUpdateStoryCommand();
            this.IsSaving = false;
        }
        Command: Home.AddUpdateStoryCommand
        IsSaving: boolean
        public cancel() {
            this.instance.dismiss();
        }

        private onSaveComplete = () => {
            this.IsSaving = false;
            this.instance.close();
        }

        public ok() {
            this.IsSaving = true;
            this.dataService.add(this.Command).success(this.onSaveComplete);
        }
      
        
    }
}