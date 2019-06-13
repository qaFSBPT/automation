using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace AutomationFrameworkTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class PageBuilderTests
    {
        private IWebDriver driver;
        private string url = ConfigurationManager.AppSettings["url"];
        private string path = ConfigurationManager.AppSettings["elementsPath"];

        [TestInitialize]
        public void Init()
        {
            driver = new InternetExplorerDriver();
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Close();
            driver = null;
        }

        [TestMethod]
        public void Builder_ElementsFound()
        {
            // Arrange
            driver.Navigate().GoToUrl(url);

            // Act
            PageBuilder builder = new PageBuilder(path, driver);
            var webElements = builder.pageObjects;

            // Assert
            Assert.IsNotNull(webElements);
            Assert.AreEqual<int>(2, webElements.Count);
        }
        
        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        public void Builder_ElementNotFound()
        {
            // Arrange

            // Act
            PageBuilder builder = new PageBuilder(path, driver);
            var webElements = builder.pageObjects;

            // Assert
        }
    }
}
