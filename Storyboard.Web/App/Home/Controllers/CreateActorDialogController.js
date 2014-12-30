/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
var Home;
(function (Home) {
    var CreateActorDialogController = (function () {
        function CreateActorDialogController($modalInstance) {
            var _this = this;
            this.onOverviewReturned = function (story) {
                _this.Overview = story;
            };
            this.instance = $modalInstance;
        }
        CreateActorDialogController.$inject = ['$modalInstance'];
        return CreateActorDialogController;
    })();
    Home.CreateActorDialogController = CreateActorDialogController;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=CreateActorDialogController.js.map