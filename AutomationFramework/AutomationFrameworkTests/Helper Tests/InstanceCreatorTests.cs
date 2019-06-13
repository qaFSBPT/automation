using System;
using System.Diagnostics.CodeAnalysis;
using AutomationFramework.Helpers;
using AutomationFrameworkTests.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;

namespace AutomationFrameworkTests.Helper_Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class InstanceCreatorTests
    {
        private Mock<IWebDriver> driver;

        [TestInitialize]
        public void Init()
        {
            driver = new Mock<IWebDriver>();
        }

        [TestCleanup]
        public void TearDown()
        {
            driver = null;
        }

        [TestMethod]
        public void Instance_IsNull()
        {
            // Arrange

            // Act
            var instance = InstanceCreator.Create("test_string", driver.Object);

            // Assert
            Assert.IsNull(instance);
        }

        [TestMethod]
        public void Instance_IsTypeGoogle()
        {
            // Arrange

            // Act
            var instance = InstanceCreator.Create("AutomationFrameworkTests.PageObjects.GoogleHome", driver.Object);

            // Assert
            Assert.IsNotNull(instance);
            Assert.ReferenceEquals(instance, typeof(GoogleHome));
        }
    }
}
