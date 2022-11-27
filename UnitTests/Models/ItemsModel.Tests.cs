using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Models
{
    /// <summary>
    /// Test class for ItemsModel
    /// </summary>
    public class ItemsModelTests
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
        /// Test case to verify the item in list of items
        /// </summary>
        [Test]
        public void ItemsModel_Valid_ToString_Should_Return_String()
        {
            // Arrange
            var data = new ItemsModel() { Title = "Laptops: 128 laptops donated until now." };

            // Act
            var result = data.ToString();

            // Assert
            Assert.AreEqual(true, result.Contains("Laptops: 128 laptops donated until now."));
        }
    }
}