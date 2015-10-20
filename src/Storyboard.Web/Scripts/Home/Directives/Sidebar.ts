/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
module Home {
    export interface ISidebarScope extends ng.IScope {
        header: string;
        openWidth: string;
    }

    export class SideBar implements ng.IDirective {
        public restrict = 'E';
        public templateUrl = '/Templates/Directives/Sidebar.html';
        public transclude = true;
        public controller = 'SidebarController';
        public link = (scope: Home.ISidebarScope, instanceElement: ng.IAugmentedJQuery, instanceAttributes: ng.IAttributes) => {
            var header = instanceAttributes['sidebarHeader'];
            if (header)
                scope.header = header;
            var openWidth = instanceAttributes['sidebarWidth'];
            if (openWidth)
                scope.openWidth = openWidth;
        };
    }

    export class SidebarController {
        public scope: Home.ISidebarScope;
        static $inject = ['$scope'];
        constructor($scope: Home.ISidebarScope) {
            this.scope = $scope;
        }
    }

}