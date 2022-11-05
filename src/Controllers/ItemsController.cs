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

        /// <summary>
        /// Collection of data of Items
        /// </summary>
        [HttpGet]
        public IEnumerable<ItemsModel> Get()
        {
            return ItemsService.GetAllData();
        }

        /// <summary>
        /// Method to update the ratings of the items
        /// </summary>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ItemsService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        /// <summary>
        /// Request rating class to create a reference to save the product rating data.
        /// </summary>
        public class RatingRequest
        {
            public string ProductId { get; set; }
            public int Rating { get; set; }
        }

    }

}