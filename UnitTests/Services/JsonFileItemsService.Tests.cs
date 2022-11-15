namespace UnitTests.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    using Bunit.Extensions;

    using ContosoCrafts.WebSite.Models;

    using NUnit.Framework;

    /// <summary>
    /// This class holds the tests for the main JsonFileProductService class.
    /// </summary>
    public class JsonFileItemsServiceTests
    {

        #region TestSetup


        /// <summary>
        /// Initialize tests for JsonFileItemsServiceTests class
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
            var result = TestHelper.ProductService.GetAllData();

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
            var jsonFileReader = File.OpenText("..\\..\\..\\..\\src\\wwwroot\\data\\items.json");

            IEnumerable<ItemsModel> expected = JsonSerializer.Deserialize<ItemsModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            // Act
            var result = TestHelper.ItemsService.GetAllData();

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        #endregion GetAllData

        #region AddRating
        /// <summary>
        /// Testing invalid null input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ItemsService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Testing invalid empty string input for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ItemsService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Testing typical, valid usage of AddRating method
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ItemsService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ItemsService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ItemsService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }
        /// <summary>
        /// Testing invalid, too below zero rating value for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Rating_below_zero_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ItemsService.AddRating("sailorhg-corsage", -1);

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Testing invalid, above five rating value for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_Rating_above_five_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ItemsService.AddRating("sailorhg-corsage", 6);

            // Assert
            Assert.AreEqual(false, result);
        }
        /// <summary>
        /// Testing for creation of ratings array is provided to AddRating method
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_if_rating_does_not_exist_create_rating_array_return_true()
        {
            // Arrange

            // Get the Last data item
            var data = TestHelper.ItemsService.GetAllData().Last();

            // Act
            var result = TestHelper.ItemsService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ItemsService.GetAllData().Last();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.First());
        }
        /// <summary>
        /// Testing invalid, if null data was given as product ID for AddRating method
        /// </summary>
        [Test]
        public void AddRating_InValid_if_data_null_for_given_productId_should_return_false()
        {
            // Arrange

            // Act
            var result = TestHelper.ItemsService.AddRating("selinazawacki-moon-one", 6);

            // Assert
            Assert.AreEqual(false, result);
        }
#endregion AddRating

    }
}
