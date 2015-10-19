/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var SideBar = (function () {
        function SideBar() {
            this.scope = {
                header: '&sbHeader'
            };
            this.require = 'E';
            this.templateUrl = '/Templates/Directives/Sidebar.html';
            this.transclude = true;
            this.controller = 'SidebarController';
        }
        return SideBar;
    })();
    Home.SideBar = SideBar;
    var SidebarController = (function () {
        function SidebarController($scope) {
            this.scope = $scope;
        }
        SidebarController.$inject = ['$scope'];
        return SidebarController;
    })();
    Home.SidebarController = SidebarController;
})(Home || (Home = {}));
