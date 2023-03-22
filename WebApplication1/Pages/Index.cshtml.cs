using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Forms;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public Formularz FizzBuzz { set; get; }
        [BindProperty(SupportsGet = true)]        
        public string Name { get; set; }
        public string Result { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if(string.IsNullOrWhiteSpace(Name))
            {
                Name = "Uzytkowniku domyslny";
            }
        }
        public IActionResult OnPost()
        {
            Result = FizzBuzz.Checker(FizzBuzz.Number);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            return RedirectToPage("./Privacy");
        }
    }
}