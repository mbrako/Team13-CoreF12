
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System;

namespace UnitTests.Pages.Product.Update
{
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
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
            pageModel.OnGet("23");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Seattle Public School", pageModel.Product.SchoolName);
        }

        [Test]
        public void OnGet_InValid_Should__Not_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("50");

            // Assert

            Assert.IsNull(pageModel.Product);
        }
        #endregion OnGet

        #region OnPostAsync
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange


            pageModel.OnGet("23");
            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                SchoolName = "bogus",
                SchoolAddress = "bogus",
                SchoolEmail = "bogus",
                SchoolContactInfo = "bogus",
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        [Test]
        public void OnPostAsync_Bogus_Value_Return_Null_Page()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                SchoolName = "bogus",
                SchoolAddress = "bogus",
                SchoolEmail = "bogus",
                SchoolContactInfo = "bogus",
            };

            // Force an invalid error state


            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.IsNull(result);

        }

        #endregion OnPostAsync
    }
}