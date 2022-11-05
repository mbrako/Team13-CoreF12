using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{

    /// <summary>
    /// Products Controller to call the service methods to execute the required request
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        // Products(School) data Service
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor with ProductService dependency injection
        /// </summary>
        /// <param name="productService"></param>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// Collection of data of Products(Schools)
        /// </summary>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

    }

}