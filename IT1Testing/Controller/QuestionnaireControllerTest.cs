using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WelCareForYou_IT1;
using WelCareForYou_IT1.Controllers;

namespace IT1Testing.Controller
{
    [TestClass]
    public class QuestionnaireControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            QuestionnaireController controller = new QuestionnaireController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
