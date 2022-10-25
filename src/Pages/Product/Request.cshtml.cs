using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class RequestModel : PageModel
    {
        private readonly ILogger<RequestModel> _logger;

        public RequestModel(ILogger<RequestModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
