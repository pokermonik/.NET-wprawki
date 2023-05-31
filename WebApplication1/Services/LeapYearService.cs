using System;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Migrations;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Services
{
    public class LeapYearService : ILeapYearInterface
    {
        private readonly IRepository _searchEntryRepository;
        public LeapYearService(IRepository searchEntryRepository)
        {
            _searchEntryRepository = searchEntryRepository;
        }
        public IQueryable<SearchEntryVM> GetAllSearchEntries()
        {
            var result = _searchEntryRepository.GetAllSearchEntries();
            return result.Select(entry => new SearchEntryVM
            {
                Id = entry.Id,
                UserId = entry.UserId,
                UserName = entry.UserName,
                SearchDateTime = entry.SearchDateTime,
                Result = entry.Result,
                Year = entry.Year
            });
        }
        public void postNewSearchEntry(SearchEntryVM entry)
        {
            SearchEntry _entry = new SearchEntry
            {
                Id = entry.Id,
                UserId = entry.UserId,
                UserName = entry.UserName,
                SearchDateTime = entry.SearchDateTime,
                Result = entry.Result,
                Year = entry.Year
            };
            _searchEntryRepository.postNewSearchEntry(_entry);
        }
        public void deleteEntry(SearchEntryVM entry)
        {
            SearchEntry _entry = new SearchEntry
            {
                Id = entry.Id,
                UserId = entry.UserId,
                UserName = entry.UserName,
                SearchDateTime = entry.SearchDateTime,
                Result = entry.Result,
                Year = entry.Year
            };
            _searchEntryRepository.deleteEntry(_entry);
        }
        public SearchEntryVM GetSearchEntryById(int id)
        {
           var result = _searchEntryRepository.GetSearchEntryById(id);
            SearchEntryVM entry = new SearchEntryVM
            {
                Id = result.Id,
                UserId = result.UserId,
                UserName = result.UserName,
                SearchDateTime = result.SearchDateTime,
                Result = result.Result,
                Year = result.Year
            };
            return entry;
        }
        public void saveChanges()
        {
            _searchEntryRepository.saveChanges();
        }
    }
}
