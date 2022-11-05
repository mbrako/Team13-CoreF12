using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Myke Brako
    /// </summary>

    /// <summary>
    /// Vaishnavi Kulkarni
    /// </summary>
    /// 
    /// <summary>
    /// Index Page will return all the Items to show
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        // Items data Service
        public JsonFileItemsService ItemsService { get; }

        // Collection of data of Items
        public IEnumerable<ItemsModel> Items { get; private set; }

        /// <summary>
        /// Default Constructor for IndexModel with JsonFileItemsService injected.
        /// </summary>
        /// <param name="itemsService"></param>
        /// <param name="logger"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileItemsService itemsService)
        {
            _logger = logger;
            ItemsService = itemsService;
        }

        /// <summary>
        /// REST OnGet, return data for all Items
        /// </summary>
        public void OnGet()
        {
            Items = ItemsService.GetAllData();
        }
    }
}