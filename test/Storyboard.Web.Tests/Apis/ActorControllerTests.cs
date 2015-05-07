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

namespace Storyboard.Web.Tests.Apis
{
    public class ActorControllerTests
    {
        private IActorRepository repo; 
        private ActorController target;



        public ActorControllerTests()
        {
            repo = Mock.Create<IActorRepository>();
            target = new ActorController(repo);
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
            var command = new AddUpdateActorCommand
            {
                Id = 1,
                Description = "Description",
                Name ="Name"
            };
            AddUpdateActorCommand repoCommand = new AddUpdateActorCommand();
           Mock.Arrange(() => repo.Add(Arg.IsAny<AddUpdateActorCommand>()))
                .Returns((AddUpdateActorCommand cmd) => {
                    repoCommand = cmd;
                    return Task.FromResult(cmd.Id);
                    });
            await target.Post(command);
            Assert.Equal(command.Id, repoCommand.Id);
            Assert.Equal(command.Description, repoCommand.Description);
            Assert.Equal(command.Name, repoCommand.Name);
            
        }

        [Fact(DisplayName = "ActorController: Post Returns Id")]
        public async Task Post_ReturnsId()
        {
            var command = new AddUpdateActorCommand
            {
                Id = 1,
                Description = "Description",
                Name = "Name"
            };
            Mock.Arrange(() => repo.Add(Arg.IsAny<AddUpdateActorCommand>()))
                .Returns((AddUpdateActorCommand cmd) => Task.FromResult(cmd.Id));
                
            var result = await target.Post(command);
            Assert.Equal(1, (int)result.Value);
            
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
