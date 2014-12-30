/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
var Home;
(function (Home) {
    var StoryOverviewController = (function () {
        function StoryOverviewController($routeParams, $modal, StoryOverviewDataService) {
            var _this = this;
            this.onOverviewReturned = function (story) {
                _this.Overview = story;
            };
            this.dataService = StoryOverviewDataService;
            this.modalService = $modal;
            this.dataService.get($routeParams.id).success(this.onOverviewReturned);
        }
        StoryOverviewController.prototype.OpenCreateActorDialog = function () {
            var settings = {
                templateUrl: 'App/Home/Views/CreateActorDialogView.html',
                controller: 'CreateActorDialogController',
                controllerAs: 'vm'
            };
            this.modalService.open(settings);
        };
        StoryOverviewController.$inject = ['$routeParams', '$modal', 'StoryOverviewDataService'];
        return StoryOverviewController;
    })();
    Home.StoryOverviewController = StoryOverviewController;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=StoryOverviewController.js.map