/// <reference path="../homemodule.ts" />
module Home {
    export class AddUpdateStoryCommand {
        constructor() {
            this.Id = 0;
        }
        Id: number
        Title: string
        Synopsis: string
    }
} 