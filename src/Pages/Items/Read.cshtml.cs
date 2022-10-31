using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages.Items
{
    public class ReadModel : PageModel
    {
        // Data middletier
        public JsonFileItemsService ItemsService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
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