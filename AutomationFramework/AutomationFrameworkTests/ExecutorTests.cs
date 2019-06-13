using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using AutomationFramework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationFrameworkTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ExecutorTests
    {
        private Mock<IWebElement> element;
        private Executor executor;

        [TestInitialize]
        public void Init()
        {
            element = new Mock<IWebElement>();
            executor = new Executor();
        }

        [TestCleanup]
        public void Teardown()
        {
            element = null;
            executor = null;
        }

        [TestMethod]
        public void Executor_Click_Success()
        {
            // Arrange
            element.Setup(x => x.Click()).Verifiable();

            // Act
            bool response = executor.Click(element.Object);

            // Assert
            Assert.IsTrue(response);
            element.Verify(x => x.Click(), Times.Once);
        }

        [TestMethod]
        public void Executor_SendKeys_Success()
        {
            // Arrange
            element.Setup(x => x.SendKeys(It.IsAny<string>())).Verifiable();

            // Act
            bool response = executor.SendKeys(element.Object, "test_string");

            // Assert
            Assert.IsTrue(response);
            element.Verify(x => x.SendKeys(It.IsAny<string>()), Times.Once);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Executor_SendKeys_Fail()
        {
            // Arrange

            // Act
            bool response = executor.SendKeys(element.Object, null);

            // Assert
        }

        [TestMethod]
        public void Executor_SelectElement_Found()
        {
            // Arrange
            Mock<IWebElement> optionElement = new Mock<IWebElement>();
            optionElement.Setup(x => x.TagName).Returns("option");
            optionElement.Setup(x => x.GetAttribute("index")).Returns("0");

            var optionsCollection = new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { optionElement.Object});

            element.Setup(x => x.TagName).Returns("select");
            element.Setup(x => x.GetAttribute("multiple")).Returns("false");
            element.Setup(x => x.FindElements(By.TagName("option"))).Returns(optionsCollection);

            // Act
            bool response = executor.SelectElement(element.Object, 0);

            //Assert
            Assert.IsTrue(response);
            element.Verify(x => x.FindElements(It.IsAny<By>()), Times.Once);
            optionElement.Verify(x => x.GetAttribute(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Executor_SelectElement_NotFound()
        {
            // Arrange
            Mock<IWebElement> optionElement = new Mock<IWebElement>();
            optionElement.Setup(x => x.TagName).Returns("option");
            optionElement.Setup(x => x.GetAttribute("index")).Returns("1");

            var optionsCollection = new ReadOnlyCollection<IWebElement>(new List<IWebElement>() { optionElement.Object});

            element.Setup(x => x.TagName).Returns("select");
            element.Setup(x => x.GetAttribute("multiple")).Returns("false");
            element.Setup(x => x.FindElements(By.TagName("option"))).Returns(optionsCollection);

            // Act
            bool response = executor.SelectElement(element.Object, 0);

            // Assert
            Assert.IsFalse(false);
            element.Verify(x => x.FindElements(It.IsAny<By>()), Times.Once);
            optionElement.Verify(x => x.GetAttribute(It.IsAny<string>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void Executor_AssertPresent_IsPresent()
        {
            // Arrange
            element.Setup(x => x.Enabled).Returns(true);
            element.Setup(x => x.Displayed).Returns(true);

            // Act
            bool response = executor.AssertPresent(element.Object);

            // Assert
            Assert.IsTrue(response);
            element.Verify(x => x.Enabled, Times.Once);
            element.Verify(x => x.Displayed, Times.Once);
        }

        [TestMethod]
        public void Executor_AssertPresent_IsNotPresent()
        {
            // Arrange
            element.Setup(x => x.Enabled).Returns(false);
            element.Setup(x => x.Displayed).Returns(false);

            // Act
            bool response = executor.AssertPresent(element.Object);

            // Assert
            Assert.IsFalse(response);
            element.Verify(x => x.Enabled, Times.Once);
        }
    }
}
