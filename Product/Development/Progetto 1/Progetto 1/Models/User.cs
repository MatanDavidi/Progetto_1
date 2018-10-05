using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Progetto_1.Models
{
    public class User
    {
        [Required(ErrorMessage = "Inserire un nome")]
        [StringLength(50, ErrorMessage = "La lunghezza del nome deve essere compresa tra 3 e 50 caratteri", MinimumLength = 3)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Inserire un numero civico")]
        [StringLength(4, ErrorMessage = "La lunghezza del numero civico deve essere compresa tra 1 e 4 caratteri", MinimumLength = 1)]
        [RegularExpression("[a-zA-Z0-9]", ErrorMessage = "Il numero civico inserito contiene caratteri non validi")]
        public string CivicNumber { get; set; }

        [Required(ErrorMessage = "Inserire una città")]
        [StringLength(50, ErrorMessage = "La lunghezza della città deve essere compresa tra 3 e 50 caratteri", MinimumLength = 3)]
        public string City { get; set; }

        [Required(ErrorMessage = "Inserire un NAP")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "La lunghezza del NAP deve essere compresa tra 4 e 5 numeri")]
        [RegularExpression("[0-9]", ErrorMessage = "Il NAP inserito contiene caratteri non validi")]
        public int Nap { get; set; }

        [Required(ErrorMessage = "Inserire un numero di telefono")]
        [RegularExpression("[0-9 -_]", ErrorMessage = "Il numero di telefono inserito contiene caratteri non consentiti")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Hobby { get; set; }

        public string Job { get; set; }
    }
}
