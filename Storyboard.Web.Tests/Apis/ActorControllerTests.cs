using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Web.API;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Domain.Core.Commands;

namespace Storyboard.Web.Tests.Apis
{
    [TestClass]
    public class ActorControllerTests
    {
        private IActorRepository repo; 
        private ActorController target;
        
        [TestInitialize]
        public void Init()
        {
            repo = Mock.Create<IActorRepository>();
            target = new ActorController(repo);
        }
        
        [TestMethod]
        public void Post_CallsRepository()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(()=> repo.AddOrUpdate(command)).MustBeCalled();
            target.Post(command);
            Mock.Assert(repo);
        }

        [TestMethod]
        public void Post_ReturnsCommand()
        {
            var command = new AddUpdateActorCommand();
            Mock.Arrange(() => repo.AddOrUpdate(command))
                .DoInstead((AddUpdateActorCommand arg)=> arg.Id = 1);
                
            var result = target.Post(command);
            Assert.AreEqual(1, result.Id);
        }

        [TestMethod]
        public void Delete_CallsRepository()
        {
            var id =1;
            Mock.Arrange(() => repo.Delete(id)).MustBeCalled();
            target.Delete(id);
            Mock.Assert(repo);

        }
    }
}
