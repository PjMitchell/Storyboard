/// <reference path="homemodule.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var OverviewController = (function () {
        function OverviewController($scope, StoryOverviewDataService) {
            var _this = this;
            this.onSummariesReturned = function (result) {
                _this.Summaries = result;
            };
            this.scope = $scope;

            this.dataService = StoryOverviewDataService;
            this.dataService.getAll().success(this.onSummariesReturned);
            this.Name = "Test";
            this.Summaries = [];
        }
        OverviewController.$inject = ['$scope', 'StoryOverviewDataService'];
        return OverviewController;
    })();
    Home.OverviewController = OverviewController;
})(Home || (Home = {}));
//# sourceMappingURL=OverviewController.js.map
