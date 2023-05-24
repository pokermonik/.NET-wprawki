using System;
using WebApplication1.Models;

namespace WebApplication1.Interfaces
{
    public interface ILeapYearInterface
    {
        public IQueryable<SearchEntry> GetAllSearchEntries();
        public void postNewSearchEntry(SearchEntry entry);
        public void deleteEntry(SearchEntry entry);
        public SearchEntry GetSearchEntryById(int id);
        public void saveChanges();
    }
}
