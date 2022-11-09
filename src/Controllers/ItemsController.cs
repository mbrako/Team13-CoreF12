using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Controllers
{

    /// <summary>
    /// Items Controller to call the service methods to execute the required request
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        // Items data Service
        public JsonFileItemsService ItemsService { get; }

        /// <summary>
        /// Default Constructor with ItemsService dependency injection
        /// </summary>
        /// <param name="itemsService"></param>
        public ItemsController(JsonFileItemsService itemsService)
        {
            ItemsService = itemsService;
        }

    }

}