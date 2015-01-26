using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Web.API;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;
using System.Net.Http;
using System.Web.Http;
using Storyboard.Web.Tests.Helpers;
using System.Threading.Tasks;

namespace Storyboard.Web.Tests.Apis
{
    [TestClass]
    public class ActorControllerTests
    {
        private IActorRepository repo; 
        private ActorController target;
        private HttpRequestMessage request;
        
        [TestInitialize]
        public void Init()
        {
            repo = Mock.Create<IActorRepository>();
            target = new ActorController(repo);
            request = new HttpRequestMessage();
            request.SetConfiguration(new HttpConfiguration());
            target.Request = request;
        }
        
        [TestMethod]
        public async Task Post_CallsRepository()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repo.Add(command))
                .Returns(()=> Task.FromResult(1))
                .MustBeCalled();
            await target.Post(command);
            Mock.Assert(repo);
        }

        [TestMethod]
        public async Task Post_ReturnsId()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repo.Add(command))
                .Returns(() => Task.FromResult(1));
                
            var result = await target.Post(command);
            Assert.AreEqual(1, HttpTestHelper.GetHttpMessAgeContent<int>(result));
            
        }
        [TestMethod]
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
