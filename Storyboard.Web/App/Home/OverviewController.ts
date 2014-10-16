/// <reference path="homemodule.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />

module Home {
    export class OverviewController {
        static $inject = ['$scope'];
        name: string;
        constructor($scope) {
            $scope.name = "Test";
        }
    }
}