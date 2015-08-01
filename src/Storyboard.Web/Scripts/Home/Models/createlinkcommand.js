var Home;
(function (Home) {
    (function (NodeTypeEnum) {
        NodeTypeEnum[NodeTypeEnum["Story"] = 1] = "Story";
        NodeTypeEnum[NodeTypeEnum["Actor"] = 2] = "Actor";
    })(Home.NodeTypeEnum || (Home.NodeTypeEnum = {}));
    var NodeTypeEnum = Home.NodeTypeEnum;
    (function (LinkFlow) {
        LinkFlow[LinkFlow["Bidirectional"] = 0] = "Bidirectional";
        LinkFlow[LinkFlow["AtoB"] = 1] = "AtoB";
        LinkFlow[LinkFlow["BtoA"] = 2] = "BtoA";
    })(Home.LinkFlow || (Home.LinkFlow = {}));
    var LinkFlow = Home.LinkFlow;
    var NodeType = (function () {
        function NodeType(type) {
            this.Id = type;
        }
        return NodeType;
    })();
    Home.NodeType = NodeType;
    var Node = (function () {
        function Node(id, type) {
            this.Id = id;
            this.NodeType = new NodeType(type);
        }
        return Node;
    })();
    Home.Node = Node;
    var LinkType = (function () {
        function LinkType() {
            this.Id = 0;
            this.Description = "";
        }
        return LinkType;
    })();
    Home.LinkType = LinkType;
    var CreateLinkCommand = (function () {
        function CreateLinkCommand(nodeA, nodeB) {
            this.NodeA = nodeA;
            this.NodeB = nodeB;
            this.Strength = 1;
            this.Type = new LinkType();
            this.Direction = LinkFlow.Bidirectional;
        }
        return CreateLinkCommand;
    })();
    Home.CreateLinkCommand = CreateLinkCommand;
    var CreateLinkRequest = (function () {
        function CreateLinkRequest(nodeA, nodeB) {
            this.NodeAId = nodeA.Id;
            this.NodeAType = nodeA.NodeType.Id;
            this.NodeBId = nodeB.Id;
            this.NodeBType = nodeB.NodeType.Id;
            this.Strength = 1;
            this.Type = 0;
            this.Direction = LinkFlow.Bidirectional;
        }
        return CreateLinkRequest;
    })();
    Home.CreateLinkRequest = CreateLinkRequest;
})(Home || (Home = {}));
