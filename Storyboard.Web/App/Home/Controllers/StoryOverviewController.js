/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
var Home;
(function (Home) {
    var StoryOverviewController = (function () {
        function StoryOverviewController($routeParams, $modal, StoryOverviewDataService, LinkDataService, ActorDataService) {
            var _this = this;
            this.onOverviewReturned = function (story) {
                _this.Overview = story;
                _this.IsLoaded = true;
            };
            this.removeActor = function (id) {
                _this.Overview.Actors = _this.Overview.Actors.filter(function (actor, index, actors) {
                    return actor.Id !== id;
                });
            };
            this.onLinkSaved = function () {
                _this.getOverview(_this.Overview.Summary.Id);
            };
            this.onActorSaved = function (id) {
                _this.linkDataService.add(new Home.CreateLinkRequest(new Home.Node(_this.Overview.Summary.Id, 1 /* Story */), new Home.Node(id, 2 /* Actor */))).then(_this.onLinkSaved);
            };
            this.storyDataService = StoryOverviewDataService;
            this.modalService = $modal;
            this.linkDataService = LinkDataService;
            this.actorDataService = ActorDataService;
            this.getOverview($routeParams.id);
        }
        StoryOverviewController.prototype.getOverview = function (id) {
            this.storyDataService.get(id).success(this.onOverviewReturned);
        };
        StoryOverviewController.prototype.openCreateActorDialog = function () {
            var settings = {
                templateUrl: 'App/Home/Views/CreateActorDialogView.html',
                controller: 'CreateActorDialogController',
                controllerAs: 'vm'
            };
            this.modalService.open(settings).result.then(this.onActorSaved);
        };
        StoryOverviewController.prototype.update = function () {
            this.storyDataService.put(this.Overview.Summary);
        };
        StoryOverviewController.prototype.deleteActorCommand = function (id) {
            var _this = this;
            this.actorDataService.delete(id).then(function (arg) { return _this.removeActor(id); });
        };
        StoryOverviewController.$inject = ['$routeParams', '$modal', 'StoryOverviewDataService', 'LinkDataService', 'ActorDataService'];
        return StoryOverviewController;
    })();
    Home.StoryOverviewController = StoryOverviewController;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=StoryOverviewController.js.map