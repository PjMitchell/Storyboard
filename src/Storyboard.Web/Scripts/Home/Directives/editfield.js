/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
var Home;
(function (Home) {
    var EditTitle = (function () {
        function EditTitle() {
            this.scope = {
                editfield: '=sbInput',
                onSaved: '&sbSaved'
            };
            this.restrict = 'E';
            this.templateUrl = '/Templates/Directives/EditTitle.html';
            this.controller = 'EditController';
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
            this.restrict = 'E';
            this.templateUrl = '/Templates/Directives/EditArea.html';
            this.controller = 'EditController';
        }
        return EditArea;
    })();
    Home.EditArea = EditArea;
    var EditController = (function () {
        function EditController($scope) {
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
        EditController.$inject = ['$scope'];
        return EditController;
    })();
    Home.EditController = EditController;
})(Home || (Home = {}));
