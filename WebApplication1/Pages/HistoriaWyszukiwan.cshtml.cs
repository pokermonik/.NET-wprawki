using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication1.Data;
using WebApplication1.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using WebApplication1.ContosoUniversity;
using WebApplication1.Interfaces;
using WebApplication1.Services;
using WebApplication1.ViewModels;

namespace WebApplication1.Pages
{
    public class HistoriaWyszukiwan : PageModel
    {
     
        private readonly ILeapYearInterface _LeapYearService;
        private readonly IConfiguration Configuration;
        public HistoriaWyszukiwan(ILeapYearInterface LeapYearService, IConfiguration configuration)
        {
            _LeapYearService = LeapYearService;
            Configuration = configuration;
        }
        public PaginatedList<SearchEntryVM> SearchEntries{ get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString,
          int? pageIndex)
        {

            CurrentSort = sortOrder;
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }



            IQueryable<SearchEntryVM> searchEntries =_LeapYearService.GetAllSearchEntries();
      
     
            searchEntries = searchEntries.OrderByDescending(s => s.SearchDateTime);

            var pageSize = Configuration.GetValue("PageSize", 20);
            SearchEntries = await PaginatedList<SearchEntryVM>.CreateAsync(
                searchEntries.AsNoTracking(), pageIndex ?? 1, pageSize);


        }
      

        public IActionResult OnPost(int id)
        {
            var entry = _LeapYearService.GetSearchEntryById(id);
            if (entry != null)
            {
                _LeapYearService.deleteEntry(entry);
                _LeapYearService.saveChanges();
            }
            

            return RedirectToPage("/HistoriaWyszukiwan");
        }

    }
}
