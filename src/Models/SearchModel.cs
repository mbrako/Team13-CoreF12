using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace ContosoCrafts.WebSite.Models
{
    public class SearchModel
    {
        //A field to take user input for search string
        public string Name { get; set; }

        // To string method to display the items as a text string
        public override string ToString() => JsonSerializer.Serialize<SearchModel>(this);
    }
}
