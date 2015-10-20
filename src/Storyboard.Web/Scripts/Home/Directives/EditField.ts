﻿/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
module Home {

    export class EditTitle implements ng.IDirective {
        public scope : IEditFieldScope = {
            editfield: '=sbInput',
            onSaved: '&sbSaved'
        };
        public restrict = 'E';
        public templateUrl = '/Templates/Directives/EditTitle.html';
        public controller = 'EditController';
       
    }

    export class EditArea implements ng.IDirective {
        public scope: IEditFieldScope = {
            editfield: '=sbInput',
            onSaved: '&sbSaved'
        };
        public restrict = 'E';
        public templateUrl = '/Templates/Directives/EditArea.html';
        public controller = 'EditController';

    }

    export interface IEditFieldScope  {
        editfield: string
        onSaved: any //Has to be any to invoke
        isEditing?: boolean
        edit?: () => void
        save?: () => void
        cancel?: ()=> void
    }

    export class EditController {
        static $inject = ['$scope'];
        public scope;
        private storedProp: string

        constructor($scope: IEditFieldScope) {
            this.scope = $scope;
            this.scope.isEditing = false;
            this.scope.edit = () => {
                $scope.isEditing = true;
                this.storedProp = $scope.editfield;
            }
            this.scope.save = () => {
                $scope.isEditing = false;
                if (this.storedProp === $scope.editfield)
                    return;
                this.storedProp = $scope.editfield;
                $scope.onSaved();
            }

            this.scope.cancel = () => {
                $scope.isEditing = false;
                $scope.editfield = this.storedProp;
            }
        }
    }
    
} 