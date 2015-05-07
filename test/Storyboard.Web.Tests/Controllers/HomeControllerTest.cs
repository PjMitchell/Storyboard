using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Storyboard.Web.Controllers;
using Microsoft.AspNet.Mvc;

namespace Storyboard.Web.Tests.Controllers
{

    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }



        [Fact]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
