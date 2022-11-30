using System.Linq;

using Microsoft.Extensions.DependencyInjection;

using Bunit;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using TestContext = Bunit.TestContext;

namespace UnitTests.Components
{
    /// <summary>
    /// Productlist test set.
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup
        /// <summary>
        /// Initialize the test set 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        /// <summary>
        /// Test for returning list of products.
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileItemsService>(TestHelper.ItemsService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Laptops: 128 laptops donated until now."));
        }

        /// <summary>
        /// Test for returning list of products.
        /// </summary>
        [Test]
        public void SearchProduct_Valid_ID_searchButton_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileItemsService>(TestHelper.ItemsService);
            var id = "searchButton";

            // Act
            var page = RenderComponent<ProductList>();

            var buttonList = page.FindAll("Button");

            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            button.Click();

            // Get the Cards retrned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("The Name field is required"));
        }
    }
}