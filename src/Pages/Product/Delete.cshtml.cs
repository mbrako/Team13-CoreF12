using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// The delete Page responsible to delete a Product(School) data
    /// </summary>
    public class DeleteModel : PageModel
    {

        // Products data Service
        public JsonFileProductService ProductService { get; }

        // Binding the data and ProductModel for the view
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Default Construtor for DeleteModel with ProductService injected.
        /// </summary>
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

        /// <summary>
        /// REST Post request to delete existing school
        /// </summary>
        /// <returns>Redirect to Index Page after deletion</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ProductService.DeleteData(Product.Id);

            // Redirect user to the Index page
            return RedirectToPage("./Index");
        }

    }

}