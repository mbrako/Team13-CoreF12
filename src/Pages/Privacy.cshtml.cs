using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The Privacy page to display the privacy of the website
    /// </summary>
    public class PrivacyModel : PageModel
    {
        //The Ilogger member for logging data
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// The constructor with Ilogger dependency injection
        /// </summary>
        public PrivacyModel(ILogger<PrivacyModel> logger)
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
