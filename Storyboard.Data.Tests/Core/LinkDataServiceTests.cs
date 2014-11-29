using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Domain.Data;
using Simple.Data;
using Storyboard.Data.Core;
using HDLink;
using Storyboard.Domain.Core;
using System.Collections;
using Storyboard.Data.DBObject;
using System.Collections.Generic;
using System.Linq;

namespace Storyboard.Data.Tests.Core
{
    [TestClass]
    public class LinkDataServiceTests
    {

        private ILinkDataService target;
        
        [TestInitialize]
        public void Init()
        {
            var adaptor = new InMemoryAdapter();
            adaptor.SetAutoIncrementColumn("Story.Link", "Id");
            adaptor.SetKeyColumn("Story.Link", "Id");

            Database.UseMockAdapter(adaptor);
            target = new LinkDataService();
        }

        
        [TestCleanup]
        public void CleanUp()
        {
            Database.StopUsingMockAdapter();
        }
        
        
        [TestMethod]
        public void Can_Add()
        {
            var link = new SimpleLink
                {
                    NodeA = new Node(12, StoryboardNodeTypes.Actor),
                    NodeB = new Node(22, StoryboardNodeTypes.Story),
                    Direction = LinkFlow.BtoA,
                    Type = new LinkType { Id = 4},
                    Strength = 0.8f
                };

            target.Add(link);
            var db = Database.Open();
            IEnumerable<LinkTableRow> rows = db.Story.Link.All();
            var row = rows.Single();
            Assert.AreEqual(link.NodeA.Id, row.NodeARef);
            Assert.AreEqual(link.NodeA.NodeType.Id, row.NodeAType);
            Assert.AreEqual(link.NodeB.Id, row.NodeBRef);
            Assert.AreEqual(link.NodeB.NodeType.Id, row.NodeBType);
            Assert.AreEqual((int)link.Direction, row.LinkDirection);
            Assert.AreEqual(link.Strength, row.LinkStrength);
            Assert.AreEqual(link.Type.Id, row.LinkTypeRef);


        }
    }
}
