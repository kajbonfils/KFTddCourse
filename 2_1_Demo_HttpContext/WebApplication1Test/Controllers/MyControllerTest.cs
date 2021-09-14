using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebApplication1.Controllers;

namespace WebApplication1Test.Controllers
{
    [TestClass]
    public class MyControllerTest
    {
        [TestMethod]
        public void Index_ReturnsView()
        {
            var context = new Mock<IHttpContext>();
            context.SetupGet(p => p.Request).Returns(
                new HttpRequestWrapper(
                    new HttpRequest("x", "http://foo", "Foo=Bar")));

            var controller = new MyController(context.Object);
            var actual = controller.Index() as ViewResult;
            Assert.AreEqual("Bar", actual.ViewData["Foo"]);
        }

        //[TestMethod]
        //public void Index_ReturnsViewWithFoo()
        //{
        //    //Arrange
        //    var controller = new MyController();
                
        //    //Act
        //    var actual = controller.Index() as ViewResult;

        //    //Assert
        //    Assert.AreEqual("Bar", actual.ViewData["Foo"]);
        //}

    }
}
