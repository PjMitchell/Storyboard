using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simple.Data;
using Storyboard.Domain.Data;
using HDLink;
using Storyboard.Data.Core;
using System.Linq;
using Storyboard.Data.DBObject;
using System.Collections.Generic;
using Storyboard.Domain.Core;

namespace Storyboard.Data.Tests.Core
{
    [TestClass]
    public class LinkRepositoryTests
    {
        private ILinkRepository target;

        [TestInitialize]
        public void Init()
        {
            var adaptor = new InMemoryAdapter();
            adaptor.SetAutoIncrementColumn("Story.Link", "Id");
            adaptor.SetKeyColumn("Story.Link", "Id");

            Database.UseMockAdapter(adaptor);
            target = new LinkRepository();
        }

        [TestCleanup]
        public void CleanUp()
        {
            Database.StopUsingMockAdapter();
        }


        [TestMethod]
        public void Get_All_CanGetAllLinks()
        {
            LoadLinks();
            var result = target.Get();
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void Get_All_LinksArePopulted()
        {
            var db = Database.Open();

            var row = new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Story.Id, NodeBRef=4, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 0.6f, LinkTypeRef = 1};
            db.Story.Link.Insert(row);
            var result = target.Get().Single() as SimpleLink;
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.NodeA.Id);
            Assert.AreEqual(StoryboardNodeTypes.Story, result.NodeA.NodeType);
            Assert.AreEqual(4, result.NodeB.Id);
            Assert.AreEqual(StoryboardNodeTypes.Actor, result.NodeB.NodeType);
            Assert.AreEqual(0.6f, result.Strength);
            Assert.AreEqual(1, result.Type.Id);
        }

        [TestMethod]
        public void Get_Node_ReturnsCorrentNumberOfLinks()
        {
            LoadLinks();

            var result1 = target.Get(new Node(1, StoryboardNodeTypes.Story));
            var result2 = target.Get(new Node(1, StoryboardNodeTypes.Actor));

            
            Assert.AreEqual(4, result1.Count());
            Assert.AreEqual(1, result2.Count());

        }

        [TestMethod]
        public void Get_NodeNodeType_ReturnsCorrentNumberOfLinks()
        {
            LoadLinks();
            var db = Database.Open();

            var rows = new List<LinkTableRow>
                {
                    new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Actor.Id, NodeBRef=2,LinkDirection= (int)LinkFlow.Bidirectional, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 1f, LinkTypeRef = 1},
                    new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Actor.Id, NodeBRef=3,LinkDirection= (int)LinkFlow.Bidirectional, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 0.9f, LinkTypeRef = 1},
                    new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Actor.Id, NodeBRef=4,LinkDirection= (int)LinkFlow.Bidirectional, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 0.6f, LinkTypeRef = 1},
                };
            db.Story.Link.Insert(rows);

            var result = target.Get(new Node(1, StoryboardNodeTypes.Actor), StoryboardNodeTypes.Story);

            Assert.AreEqual(1, result.Count());

        }

        private void LoadLinks()
        {
            var db = Database.Open();

            var rows = new List<LinkTableRow>
                {
                    new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Story.Id, NodeBRef=1,LinkDirection= (int)LinkFlow.Bidirectional, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 1f, LinkTypeRef = 1},
                    new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Story.Id, NodeBRef=2,LinkDirection= (int)LinkFlow.Bidirectional, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 1f, LinkTypeRef = 1},
                    new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Story.Id, NodeBRef=3,LinkDirection= (int)LinkFlow.Bidirectional, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 0.9f, LinkTypeRef = 1},
                    new LinkTableRow{ NodeARef = 1, NodeAType = StoryboardNodeTypes.Story.Id, NodeBRef=4,LinkDirection= (int)LinkFlow.Bidirectional, NodeBType =  StoryboardNodeTypes.Actor.Id, LinkStrength = 0.6f, LinkTypeRef = 1},
                };
            db.Story.Link.Insert(rows);
        }
    }
}
