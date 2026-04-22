using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication;
using WebApplication.Controllers;

namespace WebApplication.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Index_ReturnsViewResult()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Index_ReturnsDefaultView()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName),
                "Index should render the default view (empty ViewName).");
        }

        [TestMethod]
        public void Index_DoesNotSetViewBagMessage()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNull(result.ViewBag.Message,
                "Index should not set ViewBag.Message.");
        }

        [TestMethod]
        public void Index_BranchConditionNeverExecutes_StillReturnsView()
        {
            // Regression: the dead-code branch (i < 5, where i == 10) must never
            // affect the return value. Calling Index multiple times must always
            // yield a non-null ViewResult.
            HomeController controller = new HomeController();

            for (int call = 0; call < 3; call++)
            {
                ViewResult result = controller.Index() as ViewResult;
                Assert.IsNotNull(result,
                    $"Index() must return a non-null ViewResult on call {call + 1}.");
            }
        }

        [TestMethod]
        public void Contact_ViewBagMessage_IsCorrect()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact_ReturnsViewResult()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ActionResult result = controller.Contact();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Contact_ReturnsDefaultView()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName),
                "Contact should render the default view (empty ViewName).");
        }

        [TestMethod]
        public void Contact_ViewBagMessage_IsNotNull()
        {
            // Regression: ViewBag.Message must never be null for the Contact page.
            HomeController controller = new HomeController();

            ViewResult result = controller.Contact() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.ViewBag.Message,
                "Contact ViewBag.Message must not be null.");
        }
    }
}