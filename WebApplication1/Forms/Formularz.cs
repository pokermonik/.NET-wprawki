using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Forms
{
    public class Formularz
    {
        [Display(Name = "Twój szczęśliwy numerek")]
        [Required, Range(1, 1000, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        
        public int? Number { get; set; }

        public String Checker(int? Number)
        {
            if (Number % 3 == 0)
            {
                if(Number%5==0)
                {
                    return "FizzBuzz";
                }
                return "Fizz";
            }
            if (Number % 5==0)
            {
                return "Buzz";
            }
            return "Liczba " + Number + " Nie spełnia kryteriów FizzBuzz";
            
        }
    
    }
}
