/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
var Home;
(function (Home) {
    var StoryOverviewController = (function () {
        function StoryOverviewController($scope, $routeParams, StoryOverviewDataService) {
            var _this = this;
            this.onOverviewReturned = function (story) {
                _this.Overview = story;
            };
            this.dataService = StoryOverviewDataService;
            this.scope = $scope;
            this.dataService.get($routeParams.id).success(this.onOverviewReturned);
        }
        StoryOverviewController.$inject = ['$scope', '$routeParams', 'StoryOverviewDataService'];
        return StoryOverviewController;
    })();
    Home.StoryOverviewController = StoryOverviewController;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=StoryOverviewController.js.map