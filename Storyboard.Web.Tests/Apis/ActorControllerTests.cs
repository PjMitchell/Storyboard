using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Web.API;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;
using System.Net.Http;
using System.Web.Http;
using Storyboard.Web.Tests.Helpers;

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
        public void Post_CallsRepository()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repo.AddOrUpdate(command)).MustBeCalled();
            target.Post(command);
            Mock.Assert(repo);
        }

        [TestMethod]
        public void Post_ReturnsId()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repo.AddOrUpdate(command))
                .DoInstead((AddUpdateActorCommand arg)=> arg.Id = 1);
                
            var result = target.Post(command);
            Assert.AreEqual(1, HttpTestHelper.GetHttpMessAgeContent<int>(result));
            
        }
        [TestMethod]
        public void Delete_RemovesActor()
        {
            var id =1;
            Mock.Arrange(() => repo.Delete(id)).MustBeCalled();
            target.Delete(id);
            Mock.Assert(repo);

        }
    }
}
