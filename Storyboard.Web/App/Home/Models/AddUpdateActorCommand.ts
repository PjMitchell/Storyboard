/// <reference path="../homemodule.ts" />
module Home {
    export class AddUpdateActorCommand {
        Id: number
        Name: string
        Description: string

        constructor() {
            this.Id = 0;
        }

    }
}  