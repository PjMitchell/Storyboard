/// <reference path="../../../scripts/typings/angularjs/angular.d.ts" />
module Home {

    export class EditField implements ng.IDirective {
        public scope : IEditFieldScope = {
            editfield: '=sbInput',
            onSaved: '&sbSaved'
        };
        public require = 'E';
        public templateUrl = 'App/Home/Views/Directives/EditField.html';
        public controller = ($scope) => new editController($scope);
        //public controllerAs = 'vm';
        //public bindToController = true;
        //constructor() {
        //    this.scope = {};
        //    //this.scope.isEditing = false;
        //    this.scope.editfield = '=sbInput';
        //            //    //save: '&saveCommand',
        //            //    ,
        //            //    edit: () => {
        //            //        
        //            //    },
        //            //    save: () => {
        //            //        this.scope.isEditing = false;
        //            //    }
        //            //}
        //}
        
        
        
    }
    interface IEditFieldScope  {
        editfield: string
        onSaved: any //Has to be any to invoke
        isEditing?: boolean
        edit?: () => void
        save?: () => void
        cancel?: ()=> void
    }

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

    class editController {
       
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