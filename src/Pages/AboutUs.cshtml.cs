using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// The About US Page responsible to load the data of mission and vision
    /// </summary>
    public class AboutUsModel : PageModel
    {
        //The Ilogger member for logging data
        private readonly ILogger<AboutUsModel> _logger;

        /// <summary>
        /// The constructor with Ilogger dependency injection
        /// </summary>
        public AboutUsModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method to add actions to be performed on load of page
        /// </summary>
        public void OnGet()
        {
        }
    }
}