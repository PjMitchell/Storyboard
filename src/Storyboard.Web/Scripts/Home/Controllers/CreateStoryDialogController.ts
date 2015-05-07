/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
/// <reference path="../models/addupdatestorycommand.ts" />
/// <reference path="../services/storyoverviewdataservice.ts" />


module Home {
    export class CreateStoryDialogController {
        static $inject = ['$modalInstance','StoryOverviewDataService'];
        private dataService: StoryOverviewDataService;
        private instance: ng.ui.bootstrap.IModalServiceInstance;         
        constructor($modalInstance: ng.ui.bootstrap.IModalServiceInstance, StoryOverviewDataService :StoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.instance = $modalInstance;
            this.Command = new AddUpdateStoryCommand();
            this.IsSaving = false;
        }
        Command: AddUpdateStoryCommand
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