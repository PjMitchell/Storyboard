using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Storyboard.Data.Core;
using Xunit;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Data.DbObject;
using Storyboard.Domain.Core;
using Microsoft.Data.Entity;

namespace Storyboard.Data.Tests
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class ActorRepositoryTests : IDisposable
    {
        private readonly ActorRepository target;
        private readonly StoryboardContext context;
        private readonly ILinkDataService dataService;

        public ActorRepositoryTests()
        {
            var builder = new DbContextOptionsBuilder<StoryboardContext>();
            builder.UseInMemoryDatabase();
            
            context = new StoryboardContext(builder.Options);
            target = new ActorRepository(Mock.Create<ILinkDataService>(), context);
        }

        

        [Fact]
        public async Task GetById_Works()
        {
            var rows = new List<ActorTableRow>
            {
                new ActorTableRow { Id = 1, Description = "Actor One Description", Name = "Actor One" },
                new ActorTableRow { Id = 2, Description = "Actor Two Description", Name = "Actor Two" }
            };

            context.Actor.AddRange(rows);
            context.SaveChanges();
            var result = await target.GetAsync(1);

            Assert.Equal(rows[0].Id, result.Id);
            Assert.Equal(rows[0].Name, result.Name);
            Assert.Equal(rows[0].Description, result.Description);
            Assert.Equal(StoryboardNodeTypes.Actor.Id, result.NodeType.Id);
        }
        //Todo resolve fail when both tests are run as part of play list
        //[Fact]
        //public async Task Get_Works()
        //{
        //    var rows = new List<ActorTableRow>
        //    {
        //        new ActorTableRow { Id = 1, Description = "Actor One Description", Name = "Actor One" },
        //        new ActorTableRow { Id = 2, Description = "Actor Two Description", Name = "Actor Two" }
        //    };

        //    context.Actor.AddRange(rows);
        //    context.SaveChanges();
        //    var result = await target.GetAsync();
        //    Assert.Equal(2, result.Count);
        //    var row1 = result.Single(s => s.Id == 1);
        //    Assert.Equal(rows[0].Id, row1.Id);
        //    Assert.Equal(rows[0].Name, row1.Name);
        //    Assert.Equal(rows[0].Description, row1.Description);
        //    Assert.Equal(StoryboardNodeTypes.Actor.Id, row1.NodeType.Id);

        //    var row2 = result.Single(s => s.Id == 2);
        //    Assert.Equal(rows[1].Id, row2.Id);
        //    Assert.Equal(rows[1].Name, row2.Name);
        //    Assert.Equal(rows[1].Description, row2.Description);
        //    Assert.Equal(StoryboardNodeTypes.Actor.Id, row2.NodeType.Id);
        //}

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
