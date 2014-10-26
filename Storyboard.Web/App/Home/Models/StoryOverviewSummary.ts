/// <reference path="../homemodule.ts" />
module Home {
    export interface IStoryOverviewSummary {
        Id : number
        Title : string
        Synopsis: string
    }
    export class StoryOverviewSummary implements IStoryOverviewSummary {
        Id: number
        Title: string
        Synopsis: string
    }
} 