/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var EditTitle = (function () {
        function EditTitle() {
            this.scope = {
                editfield: '=sbInput',
                onSaved: '&sbSaved'
            };
            this.require = 'E';
            this.templateUrl = 'App/Home/Views/Directives/EditTitle.html';
            this.controller = function ($scope) { return new editController($scope); };
        }
        return EditTitle;
    })();
    Home.EditTitle = EditTitle;
    var EditArea = (function () {
        function EditArea() {
            this.scope = {
                editfield: '=sbInput',
                onSaved: '&sbSaved'
            };
            this.require = 'E';
            this.templateUrl = 'App/Home/Views/Directives/EditArea.html';
            this.controller = function ($scope) { return new editController($scope); };
        }
        return EditArea;
    })();
    Home.EditArea = EditArea;
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