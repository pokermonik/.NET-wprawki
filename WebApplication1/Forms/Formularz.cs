using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Forms
{
    public class Formularz
    {
        [Display(Name = "Rok urodzenia")]
        [Required, Range(1899, 2022, ErrorMessage = "Oczekiwana wartość {0} z zakresu {1} i {2}.")]
        
        public int Number { get; set; }

        public String Checker(int Number)
        {
            String s = "w "+ Number.ToString()+" roku. To ";
            if(Number%4!=0)
            {
                s = s + "nie";
            }
            s = s + " był rok przestępny";
            return s;
            
        }
    
    }
}
