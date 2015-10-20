/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var SideBar = (function () {
        function SideBar() {
            this.restrict = 'E';
            this.templateUrl = '/Templates/Directives/Sidebar.html';
            this.transclude = true;
            this.controller = 'SidebarController';
            this.link = function (scope, instanceElement, instanceAttributes) {
                var header = instanceAttributes['sidebarHeader'];
                if (header)
                    scope.header = header;
                var openWidth = instanceAttributes['sidebarWidth'];
                if (openWidth)
                    scope.openWidth = openWidth;
            };
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
