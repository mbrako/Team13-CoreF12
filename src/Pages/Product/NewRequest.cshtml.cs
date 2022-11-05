using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// New Request Page will create a new request for the data entered by a user/requester
    /// </summary>
    public class NewRequestModel : PageModel
    {

        // Products(School) data Service
        public JsonFileProductService ProductService { get; }

        // To bind the data to ProductModel for the view
        public ProductModel Product;

        /// <summary>
        /// Defualt Construtor for NewRequestModel with ProductService injected.
        /// </summary>
        /// <param name="productService"></param>
        public NewRequestModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request to create new Product(school)
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet()
        {
            Product = ProductService.CreateData();

            return RedirectToPage("./Update", new { Id = Product.Id });
        }

    }

}