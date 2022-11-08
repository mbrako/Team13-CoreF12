using System.Linq;



using Microsoft.Extensions.DependencyInjection;



using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;



//using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Models
{
    public class ItemsModelTests
    {
        #region TestSetup



        [SetUp]
        public void TestInitialize()
        {
        }



        #endregion TestSetup




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