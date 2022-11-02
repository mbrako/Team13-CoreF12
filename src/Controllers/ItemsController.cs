using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Items Controller to call the service methods to execute the required request
    /// </summary>
    public class ItemsController : Controller
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="itemsService"></param>
        public ItemsController(JsonFileItemsService itemsService)
        {
            ItemsService = itemsService;
        }

        // Data Service
        public JsonFileItemsService ItemsService { get; }

        // Collection of the Data
        [HttpGet]
        public IEnumerable<ItemsModel> Get()
        {
            return ItemsService.GetAllData();
        }

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ItemsService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}
