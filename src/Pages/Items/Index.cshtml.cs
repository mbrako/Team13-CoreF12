using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Items
{
    /// <summary>
    /// Index Page will return all the items to show
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="itemsService"></param>
        public IndexModel(JsonFileItemsService itemsService)
        {
            ItemsService = itemsService;
        }

        // Data Service
        public JsonFileItemsService ItemsService { get; }

        // Collection of the Data
        public IEnumerable<ItemsModel> Items { get; private set; }

        /// <summary>
        /// REST OnGet, return all data
        /// </summary>
        public void OnGet()
        {
            Items = ItemsService.GetAllData();
        }
    }
}