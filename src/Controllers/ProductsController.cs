using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Products Controller to call the service methods to execute the required request
    /// </summary>
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }
        // Data Service
        public JsonFileProductService ProductService { get; }

        // Collection of the Data
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }
    }
}