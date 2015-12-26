import {Component,Input, Output, EventEmitter} from 'angular2/core';
@Component({
    selector: 'sb-EditTextBox',
    templateUrl: '/Templates/Home/EditTextBoxTemplate.html',
    inputs: ['Value'],
    outputs: ['saveRequest']

})
export class EditTextBoxComponent {
    constructor() {
        this.saveRequest = new EventEmitter<IEditFieldEventArg>();
    }
    Value: string;
    saveRequest: EventEmitter<IEditFieldEventArg>
    IsEditing: boolean;
    EditedValue: string;

    edit() {
        this.IsEditing = true;
        this.EditedValue = this.Value;
    }
    save() {
        this.IsEditing = false;
        if (this.EditedValue === this.Value)
            return;
        this.saveRequest.emit({
            NewValue: this.EditedValue,
            OldValue: this.Value
        });
    }
    cancel() {
        this.IsEditing = false;
    }
}

export interface IEditFieldEventArg {
    NewValue: string;
    OldValue: string;
}

export class EditField {
    constructor() {
        this.saveRequest = new EventEmitter<IEditFieldEventArg>();
    }
    Value: string;
    saveRequest: EventEmitter<IEditFieldEventArg>
    IsEditing: boolean;   
    EditedValue: string;
    
    edit() {
        this.IsEditing = true;
        this.EditedValue = this.Value;
    }
    save() {       
        this.IsEditing = false;
        if (this.EditedValue === this.Value) 
            return;
        this.saveRequest.emit({
            NewValue: this.EditedValue,
            OldValue: this.Value
        });             
    }
    cancel() {
        this.IsEditing = false;
    }
}