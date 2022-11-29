using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    /// <summary>
    /// Test class for SearchModel
    /// </summary>
    internal class SearchModelTests
    {
        #region TestSetup

        /// <summary>
        /// Setup test prior to execution
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        /// <summary>
        /// Test case to verify the value of the field
        /// </summary>
        [Test]
        public void SearchModel_Valid_ToString_Should_Return_String()
        {
            // Arrange
            var data = new SearchModel() { Name = "Laptops" };

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("Laptop"));
        }
    }
}
