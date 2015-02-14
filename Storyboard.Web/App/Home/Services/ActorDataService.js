var Home;
(function (Home) {
    var ActorDataService = (function () {
        function ActorDataService($http) {
            this.apiRoute = '/api/Actor';
            this.http = $http;
        }
        ActorDataService.prototype.get = function (id) {
            return this.http.get(this.apiRoute + '/' + id);
        };
        ActorDataService.prototype.add = function (command) {
            return this.http.post(this.apiRoute, command);
        };
        ActorDataService.prototype.put = function (command) {
            return this.http.put(this.apiRoute + '/' + command.Id, command);
        };
        ActorDataService.prototype.delete = function (id) {
            return this.http.delete(this.apiRoute + '/' + id);
        };
        return ActorDataService;
    })();
    Home.ActorDataService = ActorDataService;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=actordataservice.js.map