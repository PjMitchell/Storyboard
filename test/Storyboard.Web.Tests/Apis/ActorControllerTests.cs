using Storyboard.Web.API;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;
using System.Net.Http;
using Newtonsoft.Json;
using Storyboard.Web.Tests.Helpers;
using System.Threading.Tasks;
using Storyboard.Domain.Core;
using Xunit;
using Newtonsoft.Json.Linq;
using System.Text;
using Storyboard.Web.Models.Home;
using Microsoft.AspNet.Mvc;

namespace Storyboard.Web.Tests.Apis
{
    public class ActorControllerTests
    {
        private IActorRepository repo;
        private ILinkDataService linkDataService;
        private ActorController target;



        public ActorControllerTests()
        {
            repo = Mock.Create<IActorRepository>();
            linkDataService = Mock.Create<ILinkDataService>();
            target = new ActorController(repo, linkDataService);
        }

        [Fact(DisplayName ="ActorController: Get Calls Repository")]
        public async Task Get_CallsRepository()
        {
            var expected = new Actor();
            var id = 3;
            Mock.Arrange(() => repo.GetAsync(id))
                .Returns(() => Task.FromResult(expected));
            var result = await target.Get(id);
            Assert.Equal(expected, result);
        }

        [Fact(DisplayName = "ActorController: Post Calls Repository")]
        public async Task Post_CallsRepository()
        {
            var actorCommand = new AddUpdateActorCommand
            {
                Id = 1,
                Description = "Description",
                Name ="Name"
            };
            var command = new CreateActorCommand();
            command.ActorCommand = actorCommand;
            AddUpdateActorCommand repoCommand = new AddUpdateActorCommand();
           Mock.Arrange(() => repo.Add(Arg.IsAny<AddUpdateActorCommand>()))
                .Returns((AddUpdateActorCommand cmd) => {
                    repoCommand = cmd;
                    return Task.FromResult(cmd.Id);
                    });
            await target.Post(command);
            Assert.Equal(command.ActorCommand.Id, repoCommand.Id);
            Assert.Equal(command.ActorCommand.Description, repoCommand.Description);
            Assert.Equal(command.ActorCommand.Name, repoCommand.Name);
            
        }

        [Fact(DisplayName = "ActorController: Post Returns Command with Id")]
        public async Task Post_ReturnsId()
        {
            var newId = 23;
            var actorCommand = new AddUpdateActorCommand
            {
                Id = 0,
                Description = "Description",
                Name = "Name"
            };
            var command = new CreateActorCommand();
            command.ActorCommand = actorCommand;
            Mock.Arrange(() => repo.Add(Arg.IsAny<AddUpdateActorCommand>()))
                .Returns((AddUpdateActorCommand cmd) => Task.FromResult(newId));
                
            var result = await target.Post(command) as ObjectResult;
            var completedCommand = result?.Value as CreateActorCommand;
            Assert.Equal(newId, completedCommand.ActorCommand.Id);
            
        }
        [Fact(DisplayName = "ActorController: Delete Calls Repository")]
        public async Task Delete_RemovesActor()
        {
            var id =1;
            Mock.Arrange(() => repo.Delete(id))
                .Returns(() => Task.FromResult(true))
                .MustBeCalled();
            await target.Delete(id);
            Mock.Assert(repo);

        }
    }
}
