/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
module Home {
    interface ISidebarScope {
    }

    export class SideBar implements ng.IDirective {
        public scope: ISidebarScope = {
        };
        public require = 'E';
        public templateUrl = '/Templates/Directives/Sidebar.html';
        public transclude = true;

    }

}