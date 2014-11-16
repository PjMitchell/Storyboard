/// <reference path="../homemodule.ts" />
var Home;
(function (Home) {
    var StoryOverviewDataService = (function () {
        function StoryOverviewDataService($http) {
            this.apiRoute = '/api/StoryOverview';
            this.http = $http;
        }
        StoryOverviewDataService.prototype.getAll = function () {
            return this.http.get(this.apiRoute);
        };
        StoryOverviewDataService.prototype.get = function (id) {
            return this.http.get(this.apiRoute + '/' + id);
        };
        StoryOverviewDataService.prototype.add = function (command) {
            return this.http.post(this.apiRoute, command);
        };
        StoryOverviewDataService.prototype.delete = function (id) {
            return this.http.delete(this.apiRoute + '/' + id);
        };
        return StoryOverviewDataService;
    })();
    Home.StoryOverviewDataService = StoryOverviewDataService;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=StoryOverviewDataService.js.map