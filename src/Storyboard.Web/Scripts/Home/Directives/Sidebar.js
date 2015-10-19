/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var SideBar = (function () {
        function SideBar() {
            this.scope = {};
            this.require = 'E';
            this.templateUrl = '/Templates/Directives/Sidebar.html';
            this.transclude = true;
        }
        return SideBar;
    })();
    Home.SideBar = SideBar;
})(Home || (Home = {}));
