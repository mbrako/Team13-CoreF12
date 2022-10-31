using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{
    public class ProductModel
    {
        public string Id { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The School Name should have a length of more than {2} and less than {1}")]
        public string SchoolName { get; set; }
        
        [StringLength (maximumLength: 150, MinimumLength = 5, ErrorMessage = "The School Address should have a length of more than {2} and less than {1}")]
        public string SchoolAddress { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 12, ErrorMessage = "The email should have a length of more than {2} and less than {1}")]
        public string SchoolEmail { get; set; }

        [StringLength(maximumLength: 13, MinimumLength = 10, ErrorMessage = "The email should have a length of more than {2} and less than {1}")]
        public string SchoolContactInfo { get; set; }

        // Store the Comments entered by the users on this product
        [JsonPropertyName("Items")]
        public List<ItemsModel> ItemsList { get; set; } = new List<ItemsModel>();

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}