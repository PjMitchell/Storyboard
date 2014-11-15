/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
/// <reference path="../models/addupdatestorycommand.ts" />
var Home;
(function (Home) {
    var AddStoryController = (function () {
        function AddStoryController($location, StoryOverviewDataService) {
            var _this = this;
            this.onSave = function () {
                _this.location.path('/');
            };
            this.dataService = StoryOverviewDataService;
            this.location = $location;
            this.Command = new Home.AddUpdateStoryCommand();
            this.IsSaving = false;
        }
        AddStoryController.prototype.add = function () {
            this.IsSaving = true;
            this.dataService.add(this.Command).success(this.onSave);
        };
        AddStoryController.$inject = ['$location', 'StoryOverviewDataService'];
        return AddStoryController;
    })();
    Home.AddStoryController = AddStoryController;
})(Home || (Home = {}));
//# sourceMappingURL=AddStoryController.js.map