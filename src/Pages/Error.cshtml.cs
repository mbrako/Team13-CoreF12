using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// The Error page reponsible to show the error code when some page fails 
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // Request ID for the error request
        public string RequestId { get; set; }

        //Bollean to check if request ID is present or not
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        //The Ilogger member for logging data
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// The constructor with Ilogger dependency injection
        /// </summary>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Method to add actions to be performed on load of page
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}