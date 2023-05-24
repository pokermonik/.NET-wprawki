using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Forms
{
    public class FormularzImie
    {
        [Display(Name = "Imie")]
        [RegularExpression(@"^[a-zA-Z@.]+$", ErrorMessage = "Tylko litery, @ i .")]
        [MaxLength(100, ErrorMessage = "Wprowadzone imię musi mieć co najwyżej {1} znaków")]
        public String? Imie { get; set; }

        public String Checker(String? Imie)
        {
            if (Imie != null)
            {
                if (Imie.EndsWith('a'))
                {
                    return Imie + " urodziła się w ";
                }
                else
                {
                    return Imie + " urodził się w ";
                }
            }
            return ("Nie podano imienia ");




        }

    }
}
