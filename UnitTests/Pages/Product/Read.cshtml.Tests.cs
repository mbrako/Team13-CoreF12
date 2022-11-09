
using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{

    /// <summary>
    /// This class holds the tests for the Read.cshtml.Tests.cs.
    /// </summary>
    public class ReadTest
    {
        #region TestSetup
        public static ReadModel pageModel;


        /// <summary>
        /// Setup test prior to execution.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Tests execution path when the school name does not exist
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            // Act
            pageModel.OnGet("35");
            // Assert
            Assert.AreEqual("Mercer Island School", pageModel.Product.SchoolName);
        }

        /// <summary>
        /// Test valid result from OnGet method.
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products_ToString()
        {
            // Arrange
            pageModel.OnGet("35");
            // Act
            string dogString = pageModel.Product.ToString();
            // Assert
            Assert.IsNotNull(dogString);
        }

        #endregion OnGet
    }
}