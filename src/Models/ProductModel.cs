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
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 1, ErrorMessage = "The School Name should have a length of more than {2} and less than {1}")]
        public string SchoolName { get; set; }

        //The school address
        [Required]
        [StringLength (maximumLength: 150, MinimumLength = 5, ErrorMessage = "The School Address should have a length of more than {2} and less than {1}")]
        public string SchoolAddress { get; set; }

        // The school's email
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 12, ErrorMessage = "The  School Email should have a length of more than {2} and less than {1}")]
        public string SchoolEmail { get; set; }

        // The school's phone number (school contact info)
        [Required]
        [StringLength(maximumLength: 13, MinimumLength = 10, ErrorMessage = "The School Phone Number should have a length of more than {2} and less than {1}")]
        public string SchoolContactInfo { get; set; }

        // The quantity of laptos needed
        [Range(0, 1000)]
        public int LaptopQuantity { get; set; }

        // The quantity of projectors needed
        [Range(0, 1000)]
        public int ProjectorsQuantity { get; set; }

        // The quantity of speakers needed
        [Range(0, 1000)]
        public int SpeakersQuantity { get; set; }

        // The quantity of smart boards needed
        [Range(0, 1000)]
        public int SmartBoardsQuantity { get; set; }

        // The quantity of tablets needed
        [Range(0, 1000)]
        public int TabletsQuantity { get; set; }

        // The quantity of digital markers needed
        [Range(0, 1000)]
        public int DigitalMarkersQuantity { get; set; }

        // The action field indicates that the recorded is under create or already created and ready to be updated
        public string action { get; set; }

        // To string method to display the items as a text string
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);


    }
}