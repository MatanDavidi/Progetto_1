using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Progetto_1.Models
{
    public class Utente
    {
        [Required(ErrorMessage = "Inserisci un nome valido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Inserire un nome con un numero di caratteri compreso tra 3 e 50")]
        [RegularExpression(@"[a-zA-ZäöüÄÖÜçãñ ]", ErrorMessage = "Il nome inserito contiene caratteri non validi")]
        public string Nome { get; set; }

    }
}
