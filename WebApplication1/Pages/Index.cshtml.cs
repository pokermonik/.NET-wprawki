using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Formularz FizzBuzz { set; get; }
        [BindProperty]
        public FormularzImie FizzBuzzImie { set; get; }
        [BindProperty(SupportsGet = true)]        
       
        public List<string> Results { get; set; }

        public string? Result { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
 
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {

                Result = FizzBuzzImie.Checker(FizzBuzzImie.Imie) + FizzBuzz.Checker(FizzBuzz.Number);
                if (HttpContext.Session.GetString("Results") != null)
                {
                    Results = JsonConvert.DeserializeObject<List<string>>(HttpContext.Session.GetString("Results"));
                    Results.Add(Result);
                }
                else
                {
                    Results = new List<string> { Result };
                }
                HttpContext.Session.SetString("Results",JsonConvert.SerializeObject(Results));
            }
     
                return Page();
            
     

        }
    }
}