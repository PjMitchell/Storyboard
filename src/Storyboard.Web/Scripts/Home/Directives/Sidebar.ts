/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
module Home {
    export interface ISidebarScope {
        header: string;
    }

    export class SideBar implements ng.IDirective {
        public scope: ISidebarScope = {
            header : '&sbHeader'
        };
        public require = 'E';
        public templateUrl = '/Templates/Directives/Sidebar.html';
        public transclude = true;
        public controller = 'SidebarController';
    }

    export class SidebarController {
        static $inject = ['$scope'];
        public scope;
        constructor($scope: ISidebarScope) {
            this.scope = $scope;
        }
    }

}