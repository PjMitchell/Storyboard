/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
/// <reference path="../models/addupdatestorycommand.ts" />
/// <reference path="../services/storyoverviewdataservice.ts" />
var Home;
(function (Home) {
    var CreateStoryDialogController = (function () {
        function CreateStoryDialogController($modalInstance, StoryOverviewDataService) {
            var _this = this;
            this.onSaveComplete = function () {
                _this.IsSaving = false;
                _this.instance.close();
            };
            this.dataService = StoryOverviewDataService;
            this.instance = $modalInstance;
            this.Command = new Home.AddUpdateStoryCommand();
            this.IsSaving = false;
        }
        CreateStoryDialogController.prototype.cancel = function () {
            this.instance.dismiss();
        };
        CreateStoryDialogController.prototype.ok = function () {
            this.IsSaving = true;
            this.dataService.add(this.Command).success(this.onSaveComplete);
        };
        CreateStoryDialogController.$inject = ['$modalInstance', 'StoryOverviewDataService'];
        return CreateStoryDialogController;
    })();
    Home.CreateStoryDialogController = CreateStoryDialogController;
})(Home || (Home = {}));
