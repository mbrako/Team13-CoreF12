
using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    public class ReadTests
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            // Act
            pageModel.OnGet("Mercer Island School");
            // Assert
            Assert.AreEqual("Mercer Island School", pageModel.Product.SchoolName);
        }

        [Test]
        public void OnGet_Valid_Should_Return_Products_ToString()
        {
            // Arrange
            pageModel.OnGet("Mercer Island School");
            // Act
            string dogString = pageModel.Product.ToString();
            // Assert
            Assert.IsNotNull(dogString);
        }

        #endregion OnGet
    }
}