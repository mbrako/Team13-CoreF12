using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Models
{
    /// <summary>
    /// Test class for ProductModel
    /// </summary>
    public class ProductModelTests
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
        /// Method to test valid input of a school name
        /// </summary>

        [Test]
        public void ProductModel_Valid_ToString_Should_Return_String()
        {
            // Arrange
            var data = new ProductModel() { SchoolName = "Seattle Public School" };

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("Seattle Public School"));
        }
    }
}