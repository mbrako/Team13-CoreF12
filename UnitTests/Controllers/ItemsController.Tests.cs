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
    /// This class holds the tests for the ItemsController class.
    /// </summary>
    public class ItemsControllerTests
    {

        #region TestSetup


        /// <summary>
        /// Initialize tests for Items Controller class
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup


        #region Get

        /// <summary>
        /// Test of invalid state for GetAllData method
        /// </summary>
        [Test]
        public void Get_Invalid_Does_Not_Return_Null_Or_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ItemsController.Get();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }

        /// <summary>
        /// Test for valid result of GetAllData method
        /// </summary>
        [Test]
        public void Get_Valid_Returns_Contents_Of_Json_File_Should_Return_True()
        {
            // Arrange

            // read JSON file directly and convert to a string for comparison
            var jsonFileReader = File.OpenText("..\\..\\..\\..\\src\\wwwroot\\data\\items.json");

            IEnumerable<ItemsModel> expected = JsonSerializer.Deserialize<ItemsModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            // Act
            var result = TestHelper.ItemsController.Get();

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        #endregion Get

    }
}
