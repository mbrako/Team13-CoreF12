
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{
    /// <summary>
    /// This class holds the tests for the Delete.cshtml.Tests.cs.
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup

        // Data field to hold page model specific to the Delete function
        public static DeleteModel pageModel;



        /// <summary>
        /// Setup test prior to execution.
        /// </summary>

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test a valid result for OnGet method
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_ProductToDelete()
        {
            // Arrange

            // Act
            pageModel.OnGet("23");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Seattle Public School", pageModel.Product.SchoolName);
        }
        #endregion OnGet

        #region OnPost


        /// <summary>
        /// Test a valid result for OnPost method
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_DeleteProduct()
        {
            // Arrange

            // First Create the product to delete. By calling CreateData
            // We will create a product that "
            pageModel.Product = TestHelper.ProductService.CreateData();
            pageModel.Product.SchoolName = "Example to Delete";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }


        /// <summary>
        /// Test an invalid result for OnPost method
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("Error", "Error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}