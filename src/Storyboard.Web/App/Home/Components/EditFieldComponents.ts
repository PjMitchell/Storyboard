import {Component,Input, Output, EventEmitter} from 'angular2/core';
export interface IEditFieldEventArg {
    NewValue: string;
    OldValue: string;
}

@Component({
    selector: 'sb-EditTextBox',
    templateUrl: '/Templates/Home/EditTextBoxTemplate.html',
    inputs: ['Value'],
    outputs: ['saveRequest']
})
export class EditTextBoxComponent{
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

@Component({
    selector: 'sb-EditTextArea',
    templateUrl: '/Templates/Home/EditTextAreaTemplate.html',
    inputs: ['Value'],
    outputs: ['saveRequest']
})
export class EditTextAreaComponent {
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