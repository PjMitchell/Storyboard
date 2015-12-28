export enum NodeTypeEnum {
    Story = 1,
    Actor = 2
}
export enum LinkFlow {
    Bidirectional = 0,
    AtoB = 1,
    BtoA = 2,
}

export class NodeType {
    Id: number
    constructor(type: NodeTypeEnum) {
        this.Id = type;
    }

}
export class Node {
    Id: number
    NodeType: NodeType
    constructor(id: number, type: NodeTypeEnum) {
        this.Id = id;
        this.NodeType = new NodeType(type);
    }
}
export class LinkType {
    Description: string
    Id: number
    constructor() {
        this.Id = 0;
        this.Description = "";
    }
}

export class CreateLinkRequest {
    Direction: number
    NodeAId: number
    NodeAType: number
    NodeBId: number
    NodeBType: number
    Strength: number
    Type: number

    constructor(nodeA: Node, nodeB: Node) {
        this.NodeAId = nodeA.Id;
        this.NodeAType = nodeA.NodeType.Id;
        this.NodeBId = nodeB.Id;
        this.NodeBType = nodeB.NodeType.Id;
        this.Strength = 1;
        this.Type = 0;
        this.Direction = LinkFlow.Bidirectional
    }
}

export interface ICreateLinkForNewNodeCommand
{
    Direction: number;
    NodeBId: number;
    NodeBType: number;
    Strength: number;
    Type: number;
}