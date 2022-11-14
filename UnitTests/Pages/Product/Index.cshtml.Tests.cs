using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    /// <summary>
    /// This class holds the tests for the Index.cshtml.Tests.cs
    /// </summary>
    public class IndexTests
    {
        #region TestSetup
        // The SharePoint page context object.
        public static PageContext pageContext;

        // Data field for page model
        public static IndexModel pageModel;


        /// <summary>
        /// Setup test prior to execution
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test a valid result for OnGet method
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Change this value if you modify the data source
            Assert.AreEqual(5, pageModel.Products.ToList().Count);
        }
        #endregion OnGet
    }
}