using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        public ItemsController(JsonFileItemsService itemsService)
        {
            ItemsService = itemsService;
        }

        public JsonFileItemsService ItemsService { get; }

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
