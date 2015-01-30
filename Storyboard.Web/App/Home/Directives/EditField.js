/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var EditField = (function () {
        function EditField() {
            this.scope = {
                editfield: '=sbInput',
                onSaved: '&sbSaved'
            };
            this.require = 'E';
            this.templateUrl = 'App/Home/Views/Directives/EditField.html';
            this.controller = function ($scope) { return new editController($scope); };
        }
        return EditField;
    })();
    Home.EditField = EditField;
    //class editController {
    //    public isEditing : boolean;
    //    public editfield: string;
    //    public save() {
    //        this.isEditing = false;
    //    }
    //    public edit() {
    //        this.isEditing = true;
    //    }
    //    constructor() {
    //        this.isEditing = true;
    //    }
    //}
    var editController = (function () {
        function editController($scope) {
            var _this = this;
            this.scope = $scope;
            this.scope.isEditing = false;
            this.scope.edit = function () {
                $scope.isEditing = true;
                _this.storedProp = $scope.editfield;
            };
            this.scope.save = function () {
                $scope.isEditing = false;
                if (_this.storedProp === $scope.editfield)
                    return;
                _this.storedProp = $scope.editfield;
                $scope.onSaved();
            };
            this.scope.cancel = function () {
                $scope.isEditing = false;
                $scope.editfield = _this.storedProp;
            };
        }
        return editController;
    })();
})(Home || (Home = {}));
//# sourceMappingURL=EditField.js.map