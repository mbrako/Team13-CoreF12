using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Items
{
    /// <summary>
    /// Read Page will return the items data for the id passed by the Index page
    /// </summary>
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileItemsService ItemsService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="itemsService"></param>
        public ReadModel(JsonFileItemsService itemsService)
        {
            ItemsService = itemsService;
        }

        // The data to show
        public ItemsModel Item;

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Item = ItemsService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }
    }
}