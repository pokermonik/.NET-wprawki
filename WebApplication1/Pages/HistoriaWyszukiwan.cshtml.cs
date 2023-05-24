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

namespace WebApplication1.Pages
{
    public class HistoriaWyszukiwan : PageModel
    {
        private readonly WebApplication1Context _context;
        private readonly IConfiguration Configuration;
        public HistoriaWyszukiwan(WebApplication1Context context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public PaginatedList<SearchEntry> SearchEntries{ get; set; }
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


            
            IQueryable<SearchEntry> searchEntries = from s in _context.SearchEntries select s;
      
     
            searchEntries = searchEntries.OrderByDescending(s => s.SearchDateTime);

            var pageSize = Configuration.GetValue("PageSize", 20);
            SearchEntries = await PaginatedList<SearchEntry>.CreateAsync(
                searchEntries.AsNoTracking(), pageIndex ?? 1, pageSize);


        }
      

        public IActionResult OnPost(int id)
        {
            var entry = _context.SearchEntries.Find(id);
            if (entry != null)
            {
                _context.SearchEntries.Remove(entry);
                _context.SaveChanges();
            }
            

            return RedirectToPage("/HistoriaWyszukiwan");
        }

    }
}
