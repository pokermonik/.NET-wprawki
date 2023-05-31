using System;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Interfaces
{
    public interface ILeapYearInterface
    {
        public IQueryable<SearchEntryVM> GetAllSearchEntries();
        public void postNewSearchEntry(SearchEntryVM entry);
        public void deleteEntry(SearchEntryVM entry);
        public SearchEntryVM GetSearchEntryById(int id);
        public void saveChanges();
    }
}
