using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{
    public class SearchModel
    {
        //A field to take user input for search string
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The School Address should have a length of more than {2} and less than {1}")]
        public string Name { get; set; }

        // To string method to display the items as a text string
        public override string ToString() => JsonSerializer.Serialize<SearchModel>(this);
    }
}
