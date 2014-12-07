/// <reference path="../homemodule.ts" />
var Home;
(function (Home) {
    var StoryDataService = (function () {
        function StoryDataService($http) {
            this.apiRoute = '/api/Story';
            this.http = $http;
        }
        StoryDataService.prototype.getAll = function () {
            return this.http.get(this.apiRoute);
        };
        StoryDataService.prototype.get = function (id) {
            return this.http.get(this.apiRoute + '/' + id);
        };
        StoryDataService.prototype.add = function (command) {
            return this.http.post(this.apiRoute, command);
        };
        StoryDataService.prototype.delete = function (id) {
            return this.http.delete(this.apiRoute + '/' + id);
        };
        return StoryDataService;
    })();
    Home.StoryDataService = StoryDataService;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=StoryDataService.js.map