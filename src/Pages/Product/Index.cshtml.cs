using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// Index Page will return all the Products(schools) to show
    /// </summary>
    public class IndexModel : PageModel
    {

        // Products(School) data Service
        public JsonFileProductService ProductService { get; }

        // Collection of data of Products(Schools)
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Default Constructor for IndexModel with ProductService injected.
        /// </summary>
        /// <param name="itemsService"></param>
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST OnGet, return data for all Products(schools)
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }

    }

}