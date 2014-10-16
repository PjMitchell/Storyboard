/// <reference path="homemodule.ts" />
/// <reference path="../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var OverviewController = (function () {
        function OverviewController($scope) {
            $scope.name = "Test";
        }
        OverviewController.$inject = ['$scope'];
        return OverviewController;
    })();
    Home.OverviewController = OverviewController;
})(Home || (Home = {}));
//# sourceMappingURL=OverviewController.js.map
