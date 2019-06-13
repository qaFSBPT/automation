using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AutomationFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationFrameworkTests.Helper_Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class DataReaderTests
    {
        public string elementsPath;
        public string stepsPath;

        #region Test Setup/TearDown
        [TestInitialize]
        public void Init()
        {
            elementsPath = ConfigurationManager.AppSettings["elementsPath"];
            stepsPath = ConfigurationManager.AppSettings["stepsPath"];
        }

        [TestCleanup]
        public void TearDown()
        {
            elementsPath = null;
            stepsPath = null;
        }
        #endregion Test Setup/TearDown

        #region ReadCSV
        [TestMethod]
        public void ReadCSV_EnsureRead()
        {
            // Arrange

            // ACt
            var response = DataReader.ReadCSV(elementsPath);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        public void ReadCSV_CustomDelimiters()
        {
            // Arrange
            string[] delimiters = new string[] { "," };

            // Act
            var response = DataReader.ReadCSV(elementsPath, delimiters);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadCSV_FailCustomDelimiters()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSV(elementsPath, null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadCSV_ArguementFail()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSV(null);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadCSV_FileNotFound()
        {
            // Arrange
            elementsPath = elementsPath + "_fail";

            // Act
            var response = DataReader.ReadCSV(elementsPath);

            // Assert
        }


        #endregion ReadCSV

        #region ReadCSVKV
        [TestMethod]
        public void ReadCSVKV_EnsureReadEntire()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSVKV(stepsPath, default(int));

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count > 1);
        }

        [TestMethod]
        public void ReadCSVKV_EnsureReadRow()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSVKV(stepsPath, 2);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count >= 1);
        }

        [TestMethod]
        public void ReadCSVKV_CustomDelimiters()
        {
            // Arrange
            string[] delimiters = new string[] { "," };

            // Act
            var response = DataReader.ReadCSVKV(stepsPath, 2, delimiters);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Count >= 1);
        }


        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void ReadCSVKV_FileNotFound()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSVKV("broken-path", default(int));

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadCSVKV_ArguementFail_Row()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSVKV(stepsPath, -20);

            // Assert
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadCSVKV_ArgumentFail_Path()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSVKV(string.Empty, 2);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReadCSVKV_CustomDelimiters_Fail()
        {
            // Arrange

            // Act
            var response = DataReader.ReadCSVKV(stepsPath, 2, null);

            // Assert
        }


        #endregion READCSVKV
    }
}
