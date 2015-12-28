export interface IAddUpdateStoryCommand {
    Id: number
    Title: string
    Synopsis: string
}

export class AddUpdateStoryCommand implements IAddUpdateStoryCommand {
    Id: number
    Title: string
    Synopsis: string

    constructor() {
        this.Id = 0;
    }

} 