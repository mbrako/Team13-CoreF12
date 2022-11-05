using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// To Manage the Update of the data for a single record
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Products(School) data Service
        public JsonFileProductService ProductService { get; }

        // To bind data to the model for the view and to save it later
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Defualt Construtor for UpdateModel with ProductService injected.
        /// </summary>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// REST Get request, this gets all Products and filters the data for given ID
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Product
        /// Call the data layer to Update that data
        /// Then return to the index page
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ProductService.UpdateData(Product) == null)
            {
                return null;
            }

            return RedirectToPage("./Index");
        }

    }

}