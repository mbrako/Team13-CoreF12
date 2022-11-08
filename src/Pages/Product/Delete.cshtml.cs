using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;
using System;
using static System.Collections.Specialized.BitVector32;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// The delete Page responsible to delete a Product(School) data
    /// </summary>
    public class DeleteModel : PageModel
    {

        // Products data Service
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Construtor for DeleteModel with ProductService injected.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService">Product Service dependency injection</param>
        public DeleteModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request to show the information for the Product(school) to be deleted
        /// </summary>
        public void OnGet(string id)
        {
            // Get the product from the data storage
            Product = ProductService.GetProduct(id);
        }

        // Binding the data and ProductModel for the view
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Post request to delete existing school
        /// </summary>
        /// <returns>Redirect to Index Page after deletion</returns>
        public IActionResult OnPost()
        {
            Console.WriteLine("Inside delete func");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model invalid state");
                Console.WriteLine(ModelState.Values);
                return Page();
            }

            ProductService.DeleteData(Product.Id);
            Console.WriteLine("Product deleted");
            // Redirect user to the Index page
            return RedirectToPage("./Index");
        }

    }

}