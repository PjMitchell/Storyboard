/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/addupdatestorycommand.ts" />

module Home {
    export class AddStoryController {
        static $inject = ['$location','StoryOverviewDataService'];
        private dataService: Home.StoryOverviewDataService;
        private location: ng.ILocationService;         
        constructor($location: ng.ILocationService, StoryOverviewDataService :Home.StoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.location = $location;
            this.Command = new Home.AddUpdateStoryCommand();
            this.IsSaving = false;
        }
        Command: Home.AddUpdateStoryCommand
        IsSaving: boolean
        add(){
            this.IsSaving = true;
            this.dataService.add(this.Command).success(this.onSave)
        }
        
        private onSave = () => {
            this.location.path('/')

        }
    }
}