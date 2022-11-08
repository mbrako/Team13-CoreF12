using System.Linq;



using Microsoft.Extensions.DependencyInjection;



using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;



//using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Models
{
    public class ProductModelTests
    {
        #region TestSetup



        [SetUp]
        public void TestInitialize()
        {
        }



        #endregion TestSetup




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