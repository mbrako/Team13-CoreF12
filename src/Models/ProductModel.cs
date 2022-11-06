using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary> 
    /// School data entered by the user about the school
    /// </summary>
    public class ProductModel
    {
        // The ID for the school, use a Guid so it is always unique
        public string Id { get; set; } = System.Guid.NewGuid().ToString();

        // The school name
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The School Name should have a length of more than {2} and less than {1}")]
        public string SchoolName { get; set; }
        
        //The school address
        [StringLength (maximumLength: 150, MinimumLength = 5, ErrorMessage = "The School Address should have a length of more than {2} and less than {1}")]
        public string SchoolAddress { get; set; }

        // The school's email
        [StringLength(maximumLength: 100, MinimumLength = 12, ErrorMessage = "The  School Email should have a length of more than {2} and less than {1}")]
        public string SchoolEmail { get; set; }

        // The school's phone number (school contact info)
        [StringLength(maximumLength: 13, MinimumLength = 10, ErrorMessage = "The School Phone Number should have a length of more than {2} and less than {1}")]
        public string SchoolContactInfo { get; set; }

        // The quantity of laptos needed
        public string LaptopQuantity { get; set; }

        // The quantity of projectors needed
        public string ProjectorsQuantity { get; set; }

        // The quantity of speakers needed
        public string SpeakersQuantity { get; set; }

        // The quantity of smart boards needed
        public string SmartBoardsQuantity { get; set; }

        // The quantity of tablets needed
        public string TabletsQuantity { get; set; }

        // The quantity of digital markers needed
        public string DigitalMarkersQuantity { get; set; }

        // To string method to display the items as a text string
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}