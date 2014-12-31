/// <reference path="../homemodule.ts" />
/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" /> 
/// <reference path="../../../scripts/typings/angularjs/angular-route.d.ts" />
/// <reference path="../../../scripts/typings/angular-ui-bootstrap/angular-ui-bootstrap.d.ts" />
/// <reference path="../services/actordataservice.ts" />
var Home;
(function (Home) {
    var CreateActorDialogController = (function () {
        function CreateActorDialogController($modalInstance, ActorDataService) {
            var _this = this;
            this.onSaveComplete = function (id) {
                _this.instance.close(id);
            };
            this.instance = $modalInstance;
            this.dataService = ActorDataService;
            this.Command = new Home.AddUpdateActorCommand();
        }
        CreateActorDialogController.prototype.cancel = function () {
            this.instance.dismiss();
        };
        CreateActorDialogController.prototype.ok = function () {
            this.dataService.add(this.Command).success(this.onSaveComplete);
        };
        CreateActorDialogController.$inject = ['$modalInstance', 'ActorDataService'];
        return CreateActorDialogController;
    })();
    Home.CreateActorDialogController = CreateActorDialogController;
    ;
})(Home || (Home = {}));
//# sourceMappingURL=CreateActorDialogController.js.map