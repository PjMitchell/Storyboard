using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HDLink;
using Storyboard.Data.Core;
using Xunit;
using Storyboard.Domain.Data;
using Microsoft.Data.Entity;
using Telerik.JustMock;
using Storyboard.Data.DbObject;
using Storyboard.Domain.Core;

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
            //var options = new DbContextOptions<StoryboardContext>()
            //    .Us
            var builder = new DbContextOptionsBuilder();
            builder.UseInMemoryStore();
            context = new StoryboardContext(builder.Options);
            target = new ActorRepository(Mock.Create<ILinkDataService>(), context);
        }

        

        [Fact]
        public async Task GetByIdWorks()
        {
            var rows = new List<ActorTableRow>
            {
                new ActorTableRow { Id = 1, Description = "Actor One Description", Name = "Actor One" },
                new ActorTableRow { Id = 2, Description = "Actor Two Description", Name = "Actor Two" }
            };

            context.Actor.AddRange(rows);
            context.SaveChanges();
            var result = await target.GetAsync(1);//Todo Fails on Could not load type 'System.LinqEnityFrameWorkQueryableExtension

            Assert.Equal(rows[0].Id, result.Id);
            Assert.Equal(rows[0].Name, result.Name);
            Assert.Equal(rows[0].Description, result.Description);
            Assert.Equal(StoryboardNodeTypes.Actor.Id, result.NodeType.Id);


        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
