using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutomationFramework;
using AutomationFramework.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace AutomationFrameworkTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AutomationTests
    {
        private IWebDriver driver;
        private string url = ConfigurationManager.AppSettings["url"];
        private string elementsPath = ConfigurationManager.AppSettings["elementsPath"];
        private string path = ConfigurationManager.AppSettings["stepsPath"];

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
        public void Automation_Row()
        {
            // Arrange
            Automation auto = new Automation(driver, path, url, 2);

            // Act
            var results = auto.ExcuteTest();

            // Assert
            Assert.AreEqual(1, results.Count);
            foreach (var run in results)
            {
                Assert.IsTrue(run.Value.TrueForAll(x => x.Equals(true)), string.Format("Run: {0} failed", run.Key));
            }
        }

        [TestMethod]
        public void Automation_FullDocument()
        {
            // Arrange
            Automation auto = new Automation(driver, path, url);

            // Act
            var results = auto.ExcuteTest();

            // Assert
            Assert.AreEqual(3, results.Count);
            foreach (var run in results)
            {
                Assert.IsTrue(run.Value.TrueForAll(x => x.Equals(true)), string.Format("Run: {0} failed", run.Key));
            }
        }

        [TestMethod]
        public void Automation_FullDocumentWithCustomElements()
        {
            // Arrange
            Automation auto = new Automation(driver, path, elementsPath, url);

            // Act
            var results = auto.ExcuteTest();

            // Assert
            Assert.AreEqual(3, results.Count);
            foreach (var run in results)
            {
                Assert.IsTrue(run.Value.TrueForAll(x => x.Equals(true)), string.Format("Run: {0} failed", run.Key));
            }
        }

        [TestMethod]
        public void Automation_CustomExecutor()
        {
            // Arrange
            Mock<IExecutor> moqExecutor = new Mock<IExecutor>();
            moqExecutor.Setup(x => x.Click(It.IsAny<IWebElement>())).Returns(true);

            Automation auto = new Automation(driver, path, url, 4);
            ObjectLocator.container.EjectAllInstancesOf<IExecutor>();
            ObjectLocator.container.Configure(x => x.For<IExecutor>().Use(moqExecutor.Object));

            // Act
            var results = auto.ExcuteTest();

            // Assert
            Assert.AreEqual(1, results.Count, string.Format("results.Count was: {0}, expected 1", results.Count));
            Assert.AreEqual(2, results[results.Keys.First()].Count, string.Format("results[{0}].Count was: {1}, expected 2", results.Keys.First(), results[results.Keys.First()].Count));
            foreach(var run in results)
            {
                Assert.IsTrue(run.Value.TrueForAll(x => x.Equals(true)), string.Format("Run: {0} failed at {1}", run.Key, run.Value));
            }
        }
    }
}
