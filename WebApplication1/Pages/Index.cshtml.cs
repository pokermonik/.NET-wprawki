using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Forms;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using WebApplication1.Models;
using Microsoft.VisualBasic;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private ILeapYearInterface _LeapYearService;

        [BindProperty]
        public Formularz FizzBuzz { set; get; }
        [BindProperty]
        public FormularzImie FizzBuzzImie { set; get; }
        [BindProperty(SupportsGet = true)]        
       
        public List<string> Results { get; set; }

        public string? Result { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ILeapYearInterface LeapYearService)
        {
            _logger = logger;
            _LeapYearService = LeapYearService;
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





                SearchEntryVM searchEntry = new SearchEntryVM();
                searchEntry.Year = FizzBuzz.Number;
                searchEntry.SearchDateTime = DateTime.Now;
                searchEntry.Result = !(FizzBuzz.Checker(FizzBuzz.Number).Contains("nie"));
                if (FizzBuzzImie.Imie == null)
                {
                    FizzBuzzImie.Imie = "Nie podano imienia";
                }
                searchEntry.UserId = User.Identity.IsAuthenticated ? User.FindFirst(ClaimTypes.NameIdentifier).Value : "Brak";
                searchEntry.UserName = User.Identity.IsAuthenticated ? User.Identity.Name : FizzBuzzImie.Imie;
                _LeapYearService.postNewSearchEntry(searchEntry);
                _LeapYearService.saveChanges();
            }
       
            return Page();
            
     

        }
    }
}