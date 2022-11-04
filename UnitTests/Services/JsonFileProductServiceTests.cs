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
    public class JsonFileProductServiceTests
    {

        #region TestSetup


        /// <summary>
        /// Initialize tests for JsonFileProductService class
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
            var jsonFileReader = File.OpenText("..\\..\\..\\..\\src\\wwwroot\\data\\products.json");

            IEnumerable<ProductModel> expected = JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            // Act
            var result = TestHelper.ProductService.GetAllData();

            // Assert
            Assert.AreEqual(expected.ToString(), result.ToString());
        }

        #endregion GetAllData

        

        #region CreateData

        /// <summary>
        /// Testing typical, valid usage of CreateData method
        /// </summary>
        [Test]
        public void CreateData_Valid_Last_Value_Matches_Created_Values_Should_Return_True()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.CreateData();
            var last = TestHelper.ProductService.GetAllData().Last();

            // Assert
            Assert.AreEqual("Enter School Name", result.SchoolName);
            Assert.AreEqual("Enter Complete School Address", result.SchoolAddress);
            Assert.AreEqual("Enter School contact details", result.SchoolContactInfo);
            Assert.AreEqual("Enter email", result.SchoolEmail);
            Assert.AreEqual(result.Id, last.Id);
        }
        #endregion CreateData

        #region UpdateData

        /// <summary>
        /// Testing typical, valid usage of UpdateData method
        /// </summary>
        [Test]
        public void UpdateData_Valid_Updated_Value_Matches_Should_Return_True()
        {
            // Arrange
            var data = TestHelper.ProductService.GetAllData().FirstOrDefault();
            var data2 = data;
            data2.SchoolName = "Test";

            // Act
            var result = TestHelper.ProductService.UpdateData(data2);

            // Reset
            _ = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual(data2.SchoolName, result.SchoolName);
        }



        #endregion UpdateData


    }
}
