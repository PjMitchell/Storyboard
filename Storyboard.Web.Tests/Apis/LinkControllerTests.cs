using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storyboard.Domain.Data;
using Telerik.JustMock;
using Storyboard.Web.API;
using Storyboard.Domain.Core.Commands;

namespace Storyboard.Web.Tests.Apis
{
    [TestClass]
    public class LinkControllerTests
    {
        private ILinkDataService dataService;
        private LinkController target;

        [TestInitialize]
        public void Init()
        {
            dataService = Mock.Create<ILinkDataService>();
            target = new LinkController(dataService);

        }
        [TestMethod]
        public void PostCallsLinkDataService()
        {
            var createCommand = new CreateLinkCommand();
            Mock.Arrange(() => dataService.Add(createCommand)).Occurs(1);
            target.Post(createCommand);
            Mock.Assert(dataService);
        }
    }
}
