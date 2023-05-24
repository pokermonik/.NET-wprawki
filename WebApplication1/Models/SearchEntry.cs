using Microsoft.EntityFrameworkCore;
namespace WebApplication1.Models
{
     public class SearchEntry
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime SearchDateTime { get; set; }
        public bool Result { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }

}