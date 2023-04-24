using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp_UnderTheHood.Pages
{
    [Authorize(Policy = "HRPolicy")]
    public class HumanResourceModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
