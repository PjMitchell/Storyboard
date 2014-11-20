/// <reference path="../homemodule.ts" />
module Home {
    export class AddUpdateStoryCommand {
        Id: number
        Title: string
        Synopsis: string

        constructor() {
            this.Id = 0;
        }

    }
} 