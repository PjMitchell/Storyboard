export interface IStorySummary {
    Id: number;
    Title: string;
    Synopsis: string;
};

export interface IActor {
    Id: number;
    Name: string;
    Description: string;
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
export interface IStorySection {
    Id: number;
    Description: string;
    HierarchyLevel: number;
    Order: number;
    ParentHierarchyElementId: number;
}
export class StorySection {
    Id: number;
    Description: string;
    HierarchyLevel: number;
    Order: number;
    ParentHierarchyElementId: number;
}
export interface IStoryOverview {
    Summary: IStorySummary;
    Actors: IActor[];
    Sections: IStorySection[];
};
export class StoryOverview {
    Summary: StorySummary;
    Actors: Actor[];
    Sections: StorySection[];
};
