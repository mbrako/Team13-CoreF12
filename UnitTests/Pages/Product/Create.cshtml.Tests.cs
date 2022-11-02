﻿namespace UnitTests.Pages.Product



{
    using ContosoCrafts.WebSite.Pages.Product;
    using ContosoCrafts.WebSite.Services;



    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Microsoft.AspNetCore.Routing;
    using Microsoft.Extensions.Logging;



    using Moq;



    using NUnit.Framework;
    /// <summary>
    /// This class holds the tests for the Create.cshtml.Tests.cs
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        public static IUrlHelperFactory urlHelperFactory;
        public static DefaultHttpContext httpContextDefault;
        public static IWebHostEnvironment webHostEnvironment;
        public static ModelStateDictionary modelState;
        public static ActionContext actionContext;
        public static EmptyModelMetadataProvider modelMetadataProvider;
        public static ViewDataDictionary viewData;
        public static TempDataDictionary tempData;
        public static PageContext pageContext;
        public static NewRequestModel pageModel;



        [SetUp]
        public void TestInitialize()
        {
            httpContextDefault = new DefaultHttpContext()
            {
                //RequestServices = serviceProviderMock.Object,
            };



            modelState = new ModelStateDictionary();



            actionContext = new ActionContext(httpContextDefault, httpContextDefault.GetRouteData(), new PageActionDescriptor(), modelState);



            modelMetadataProvider = new EmptyModelMetadataProvider();
            viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            tempData = new TempDataDictionary(httpContextDefault, Mock.Of<ITempDataProvider>());



            pageContext = new PageContext(actionContext)
            {
                ViewData = viewData,
            };



            var mockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            _ = mockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            _ = mockWebHostEnvironment.Setup(m => m.WebRootPath).Returns("../../../../src/bin/Debug/net6.0/wwwroot");
            _ = mockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns("./data/");



            var MockLoggerDirect = Mock.Of<ILogger<NewRequestModel>>();
            JsonFileProductService productService;



            productService = new JsonFileProductService(mockWebHostEnvironment.Object);



            pageModel = new NewRequestModel(productService)
            {
            };
        }
        #endregion TestSetup



        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_True()
        {
            // Arrange




            // Act
            _ = pageModel.OnGet();



            // Reset




            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
        }
        #endregion OnGet
    }
}