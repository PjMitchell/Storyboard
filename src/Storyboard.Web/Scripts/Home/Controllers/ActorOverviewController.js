/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
/// <reference path="../services/storyoverviewdataservice.ts" />
/// <reference path="../services/actordataservice.ts" />
/// <reference path="../services/linkdataservice.ts" />
/// <reference path="../models/storymodels.ts" />
var Home;
(function (Home) {
    var ActorOverviewController = (function () {
        function ActorOverviewController($routeParams, ActorDataService) {
            var _this = this;
            this.onOverviewReturned = function (actor) {
                _this.Overview = actor;
                _this.IsLoaded = true;
            };
            this.actorDataService = ActorDataService;
            this.StoryId = $routeParams.storyId;
            this.getOverview($routeParams.id);
        }
        ActorOverviewController.prototype.getOverview = function (id) {
            this.actorDataService.get(id).success(this.onOverviewReturned);
        };
        ActorOverviewController.prototype.update = function () {
            this.actorDataService.put(this.Overview);
        };
        ActorOverviewController.$inject = ['$routeParams', 'ActorDataService'];
        return ActorOverviewController;
    })();
    Home.ActorOverviewController = ActorOverviewController;
    ;
})(Home || (Home = {}));
