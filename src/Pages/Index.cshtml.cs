using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    ///<summary>
    ///Shiva Chaithanya
    ///</summary>
    /// <summary>
    /// Myke Brako
    /// </summary>

    /// <summary>
    /// pranindhar reddy
    /// </summary>

    /// <summary>
    /// Vaishnavi Kulkarni
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger,
            JsonFileItemsService itemsService)
        {
            _logger = logger;
            ItemsService = itemsService;
        }

        public JsonFileItemsService ItemsService { get; }
        public IEnumerable<ItemsModel> Items { get; private set; }

        public void OnGet()
        {
            Items = ItemsService.GetAllData();
        }
    }
}