/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var SummaryController = (function () {
        function SummaryController($scope, StoryOverviewDataService) {
            var _this = this;
            this.scope = $scope;
            this.dataService = StoryOverviewDataService;
            this.Summaries = [];
            this.getAllSummaries = function () {
                _this.dataService.getAll().success(_this.onSummariesReturned);
            };
            this.onSummariesReturned = function (result) {
                _this.Summaries = result;
            };
            this.getAllSummaries();
        }
        SummaryController.prototype.deleteStoryCommand = function (id) {
            this.dataService.delete(id).success(this.getAllSummaries);
        };
        SummaryController.$inject = ['$scope', 'StoryOverviewDataService'];
        return SummaryController;
    })();
    Home.SummaryController = SummaryController;
})(Home || (Home = {}));
//# sourceMappingURL=SummaryController.js.map