using System;
using Storyboard.Web.API;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;
using System.Net.Http;
using System.Web.Http;
using Storyboard.Web.Tests.Helpers;
using System.Threading.Tasks;
using Storyboard.Domain.Core;
using Xunit;


namespace Storyboard.Web.Tests.Apis
{
    public class ActorControllerTests
    {
        private IActorRepository repo; 
        private ActorController target;
        private HttpRequestMessage request;
        
        public ActorControllerTests()
        {
            repo = Mock.Create<IActorRepository>();
            target = new ActorController(repo);
            request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            target.Request = request;
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
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repo.Add(command))
                .Returns(()=> Task.FromResult(1))
                .MustBeCalled();
            await target.Post(command);
            Mock.Assert(repo);
        }

        [Fact(DisplayName = "ActorController: Post Returns Id")]
        public async Task Post_ReturnsId()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repo.Add(command))
                .Returns(() => Task.FromResult(1));
                
            var result = await target.Post(command);
            Assert.Equal(1, HttpTestHelper.GetHttpMessAgeContent<int>(result));
            
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
