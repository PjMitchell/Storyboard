/// <reference path="../homemodule.ts" />
module Home {
    export interface IStorySummary {
        Id: number;
        Title: string;
        Synopsis: string;
    };
    export class StorySummary implements IStorySummary {
        Id: number;
        Title: string;
        Synopsis: string;
    };
    export class Actor {
        Id: number;
        Name: string;
        Description: string;
    };
    export class StoryOverview {
        Summary: StorySummary;
        Actors: Actor[];
    };

} 