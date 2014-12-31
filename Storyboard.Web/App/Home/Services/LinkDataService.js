var Home;
(function (Home) {
    var LinkDataService = (function () {
        function LinkDataService($http) {
            this.apiRoute = '/api/Link';
            this.http = $http;
        }
        LinkDataService.prototype.add = function (command) {
            return this.http.post(this.apiRoute, command);
        };
        return LinkDataService;
    })();
    Home.LinkDataService = LinkDataService;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=LinkDataService.js.map