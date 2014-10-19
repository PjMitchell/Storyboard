/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var OverviewController = (function () {
        function OverviewController($scope, StoryOverviewDataService) {
            var _this = this;
            //as lambda to prevent this context changing
            this.getAllSummaries = function () {
                _this.dataService.getAll().success(_this.onSummariesReturned);
            };
            this.onSummariesReturned = function (result) {
                _this.Summaries = result;
            };
            this.scope = $scope;

            this.dataService = StoryOverviewDataService;
            this.getAllSummaries();

            //this.dataService.getAll().success(this.onSummariesReturned);
            this.Name = "Test";
            this.Summaries = [];
        }
        OverviewController.prototype.deleteStoryCommand = function (id) {
            this.dataService.delete(id).success(this.getAllSummaries);
        };
        OverviewController.$inject = ['$scope', 'StoryOverviewDataService'];
        return OverviewController;
    })();
    Home.OverviewController = OverviewController;
})(Home || (Home = {}));
//# sourceMappingURL=OverviewController.js.map
