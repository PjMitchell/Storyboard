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

        //private ILinkDataService target;
        
        //[TestInitialize]
        //public void Init()
        //{
        //    var adaptor = new InMemoryAdapter();
        //    adaptor.SetAutoIncrementColumn("Story.Link", "Id");
        //    adaptor.SetKeyColumn("Story.Link", "Id");

        //    Database.UseMockAdapter(adaptor);
        //    target = new LinkDataService();
        //}

        
        //[TestCleanup]
        //public void CleanUp()
        //{
        //    Database.StopUsingMockAdapter();
        //}
        
        
        //[TestMethod]
        //public void Can_Add()
        //{
        //    var link = new SimpleLink
        //        {
        //            NodeA = new Node(12, StoryboardNodeTypes.Actor),
        //            NodeB = new Node(22, StoryboardNodeTypes.Story),
        //            Direction = LinkFlow.BtoA,
        //            Type = new LinkType { Id = 4},
        //            Strength = 0.8f
        //        };

        //    target.Add(link);
        //    var db = Database.Open();
        //    IEnumerable<LinkTableRow> rows = db.Story.Link.All();
        //    var row = rows.Single();
        //    Assert.AreEqual(link.NodeA.Id, row.NodeARef);
        //    Assert.AreEqual(link.NodeA.NodeType.Id, row.NodeAType);
        //    Assert.AreEqual(link.NodeB.Id, row.NodeBRef);
        //    Assert.AreEqual(link.NodeB.NodeType.Id, row.NodeBType);
        //    Assert.AreEqual((int)link.Direction, row.LinkDirection);
        //    Assert.AreEqual(link.Strength, row.LinkStrength);
        //    Assert.AreEqual(link.Type.Id, row.LinkTypeRef);


        //}

        //[TestMethod]
        //public void Can_Remove()
        //{
        //    var link1 = new SimpleLink //The one to be deleted
        //    {
        //        NodeA = new Node(12, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(22, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.1f
        //    };

        //    var link2 = new SimpleLink //The NodeB is different
        //    {
        //        NodeA = new Node(12, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(13, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.2f
        //    };

        //    var link3 = new SimpleLink //The NodeB is different
        //    {
        //        NodeA = new Node(12, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(22, StoryboardNodeTypes.Actor),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.3f
        //    };

        //    var link4 = new SimpleLink //The NodeA is different
        //    {
        //        NodeA = new Node(13, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(22, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.4f
        //    };

        //    var link5 = new SimpleLink //The NodeA is different
        //    {
        //        NodeA = new Node(12, StoryboardNodeTypes.Story),
        //        NodeB = new Node(22, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.5f
        //    };
        //    var link6 = new SimpleLink
        //    {
        //        NodeA = new Node(12, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(22, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 3 },
        //        Strength = 0.6f
        //    };
        //    target.Add(link1);
        //    target.Add(link2);
        //    target.Add(link3);
        //    target.Add(link4);
        //    target.Add(link5);
        //    target.Add(link6);

        //    target.Remove(link1);
        //    var db = Database.Open();
        //    IEnumerable<LinkTableRow> rows = db.Story.Link.All();
        //    var rowAsList = rows.ToList();
        //    Assert.AreEqual(5, rowAsList.Count);
        //    Assert.IsFalse(rowAsList.Any(r => r.LinkStrength == 0.1f));



        //}

        //[TestMethod]
        //public void Can_Remove_ByNode()
        //{
        //    var link1 = new SimpleLink //Deleted
        //    {
        //        NodeA = new Node(12, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(22, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.1f
        //    };

        //    var link2 = new SimpleLink //Node type is different
        //    {
        //        NodeA = new Node(12, StoryboardNodeTypes.Story),
        //        NodeB = new Node(13, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.4f
        //    };

        //    var link3 = new SimpleLink //Deleted
        //    {
        //        NodeA = new Node(22, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(12, StoryboardNodeTypes.Actor),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.3f
        //    };

        //    var link4 = new SimpleLink //The NodeA is different
        //    {
        //        NodeA = new Node(13, StoryboardNodeTypes.Actor),
        //        NodeB = new Node(22, StoryboardNodeTypes.Story),
        //        Direction = LinkFlow.BtoA,
        //        Type = new LinkType { Id = 4 },
        //        Strength = 0.4f
        //    };

        //    target.Add(link1);
        //    target.Add(link2);
        //    target.Add(link3);
        //    target.Add(link4);
            
        //    target.Remove(new Node(12, StoryboardNodeTypes.Actor));
        //    var db = Database.Open();
        //    IEnumerable<LinkTableRow> rows = db.Story.Link.All();
        //    var rowAsList = rows.ToList();
        //    Assert.AreEqual(2, rowAsList.Count);
        //    Assert.IsTrue(rowAsList.All(r => r.LinkStrength == 0.4f));

            
        //}
    }
}
