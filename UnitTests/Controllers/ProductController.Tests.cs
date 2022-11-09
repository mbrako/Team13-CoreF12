namespace UnitTests.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using Bunit.Extensions;

    using ContosoCrafts.WebSite.Models;

    using NUnit.Framework;

    /// <summary>
    /// This class holds the tests for the ProductController class.
    /// </summary>
    public class ProductControllerTests
    {

        #region TestSetup


        /// <summary>
        /// Initialize tests for ProductController class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup


        #region GetAllData

        /// <summary>
        /// Test of invalid state for GetAllData method
        /// </summary>
        [Test]
        public void GetAllData_Invalid_Does_Not_Return_Null_Or_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductsController.Get();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }

        /// <summary>
        /// Test for valid result of GetAllData method
        /// </summary>
        [Test]
        public void GetAllData_Valid_Returns_Contents_Of_Json_File_Should_Return_True()
        {
            // Arrange

            // read JSON file directly and convert to a string for comparison
            var jsonFileReader = File.OpenText("..\\..\\..\\..\\src\\wwwroot\\data\\products.json");

            IEnumerable<ProductModel> expected = JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            // Act
            var result = TestHelper.ProductsController.Get();

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        #endregion GetAllData
    }
}
