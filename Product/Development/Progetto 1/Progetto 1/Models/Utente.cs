using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Progetto_1.Models
{
    public class Utente
    {
        private string nome;

        [Required(ErrorMessage = "Inserisci un nome valido")]
        public string Nome { get; set; }

    }
}
