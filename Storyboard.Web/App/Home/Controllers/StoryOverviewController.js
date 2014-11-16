/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
var Home;
(function (Home) {
    var StoryOverviewController = (function () {
        function StoryOverviewController($scope, StoryOverviewDataService) {
            this.dataService = StoryOverviewDataService;
            this.scope = $scope;
        }
        StoryOverviewController.$inject = ['$scope', 'StoryOverviewDataService'];
        return StoryOverviewController;
    })();
    Home.StoryOverviewController = StoryOverviewController;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=StoryOverviewController.js.map