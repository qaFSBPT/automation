using System;
using System.Diagnostics.CodeAnalysis;
using AutomationFramework.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationFrameworkTests.Helper_Tests
{ 
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void Validator_IsNull_NotNull()
        {
            // Arrange
            int i = 0;

            // Act
            Validators.IsArgumentNull(i);

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validator_IsNull_IsNull()
        {
            // Arrange
            object obj = null;

            // Act
            Validators.IsArgumentNull(obj);
        }

        [TestMethod]
        public void Validator_IsEmpty_NotEmpty()
        {
            // Arranage
            string str = "hello";

            // Act
            Validators.IsArgumentEmpty(str);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validator_IsEmpty_IsNull()
        {
            // Arrange
            string str = null;

            // Act
            Validators.IsArgumentEmpty(str);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Validator_IsEmpty_IsEmpty()
        {
            // Arrange
            string str = string.Empty;

            // Act
            Validators.IsArgumentEmpty(str);
        }
    }
}
