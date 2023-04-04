using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication1.Pages
{
    public class SavedInSessionModel : PageModel
    {
        public Formularz FizzBuzz { get; set; }

        public List<string> Results { get; set; }

        public SavedInSessionModel()
        {
            Results = new List<string>(); 
        }
        public void OnGet()
        {
            var resultsJson = HttpContext.Session.GetString("Results");
            if (resultsJson != null)
            {
                Results = JsonConvert.DeserializeObject<List<string>>(resultsJson);
            }
        }
    }
}
