﻿/// <reference path="../homemodule.ts" />
var Home;
(function (Home) {
    var StoryOverviewDataService = (function () {
        function StoryOverviewDataService($http) {
            this.http = $http;
        }
        StoryOverviewDataService.prototype.getAll = function () {
            return this.http.get('/api/StoryOverview');
        };

        StoryOverviewDataService.prototype.add = function (command) {
            return this.http.post('/api/StoryOverview', command);
        };
        return StoryOverviewDataService;
    })();
    Home.StoryOverviewDataService = StoryOverviewDataService;
})(Home || (Home = {}));
//# sourceMappingURL=StoryOverviewDataService.js.map
