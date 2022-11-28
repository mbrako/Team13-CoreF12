using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System;
using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// Read Page will return the school data for the id passed by the Index page
    /// </summary>
    public class ReadModel : PageModel
    {

        // Products(School) data Service
        public JsonFileProductService ProductService { get; }

        // To Bind the data to ProductModel for the view
        public ProductModel Product;

        /// <summary>
        /// Defualt Construtor for ReadModel with ProductService injected.
        /// </summary>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request to get data for a given Product ID
        /// </summary>
        /// <param name="id"></param>
        public IActionResult OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));

            if (Product == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

    }

}