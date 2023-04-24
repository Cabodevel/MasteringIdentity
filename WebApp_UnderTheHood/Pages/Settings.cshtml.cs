using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp_UnderTheHood.Pages
{
    [Authorize(Policy = "Admin")]
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
