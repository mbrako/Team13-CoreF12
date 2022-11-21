using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// Items that schools can raise a request for assistance.
    /// </summary>
    public class ItemsModel
    {
        // The ID for the items
        public string Id { get; set; }

        // This is the link to the image file to display in item preview
        [JsonPropertyName("img")]
        public string Image { get; set; }

        // This is the web location for the item
        public string Url { get; set; }

        // The Items Title
        [StringLength(maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}")]
        public string Title { get; set; }

        // A short description of the content of the item
        public string Description { get; set; }

        // Ratings for the item which is a trace from the Contosco Crafts Website
        public int[] Ratings { get; set; }

        public string Quantity { get; set; }

        // Item price which is a trace from the Contosco Crafts Website
        [Range(-1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Price { get; set; }

        // To string method to display the item as a text string
        public override string ToString() => JsonSerializer.Serialize<ItemsModel>(this);

    }
}