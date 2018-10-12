using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Inserire un cognome")]
        [StringLength(50, ErrorMessage = "La lunghezza del cognome deve essere compresa tra 3 e 50 caratteri", MinimumLength = 3)]
        [Display(Name = "Cognome")]
        public string LastName { get; set; }

        [DataType(DataType.Date, ErrorMessage = "È stata inserita una data di nascita")]
        [BindRequired]
        [Required(ErrorMessage = "Inserire una data di nascita")]
        [Display(Name = "Data di nascita")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Inserire un indirizzo")]
        [StringLength(50, ErrorMessage = "La lunghezza dell'indirizzo deve essere compresa tra 3 e 50 caratteri", MinimumLength = 3)]
        [Display(Name = "Indirizzo")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Inserire un numero civico")]
        [StringLength(4, ErrorMessage = "La lunghezza del numero civico deve essere compresa tra 1 e 4 caratteri", MinimumLength = 1)]
        [RegularExpression("[^a-zA-Z0-9]", ErrorMessage = "Il numero civico inserito contiene caratteri non validi")]
        [Display(Name = "Numero civico")]
        public string CivicNumber { get; set; }

        [Required(ErrorMessage = "Inserire una città")]
        [StringLength(50, ErrorMessage = "La lunghezza della città deve essere compresa tra 3 e 50 caratteri", MinimumLength = 3)]
        [Display(Name = "Città")]
        public string City { get; set; }

        [BindRequired]
        [Required(ErrorMessage = "Inserire un NAP")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "La lunghezza del NAP deve essere compresa tra 4 e 5 numeri")]
        [Display(Name = "NAP")]
        public int Nap { get; set; }

        [Required(ErrorMessage = "Inserire un numero di telefono")]
        [Display(Name = "Numero di telefono")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Inserire un indirizzo email")]
        [EmailAddress(ErrorMessage = "È stata inserita un'email in un formato non riconosciuto")]
        [Display(Name = "Indirizzo e-mail")]
        public string Email { get; set; }

        [Display(Name = "Genere")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "La lunghezza dell'hobby deve essere al massimo di 500 caratteri")]
        public string Hobby { get; set; }

        [StringLength(500, ErrorMessage = "La lunghezza della professione deve essere al massimo di 500 caratteri")]
        [Display(Name = "Professione")]
        public string Job { get; set; }
    }
}
