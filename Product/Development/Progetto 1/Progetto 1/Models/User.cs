﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Progetto_1.Models
{
    public class User
    {
        #region =================== costanti ===================
        public const string TEXTREGEX = "[a-zA-ZàáâäãåąčćęèéêëėįìíîïłńòóôöõøùúûüųūÿýżźñçčšžÀÁÂÄÃÅĄĆČĖĘÈÉÊËÌÍÎÏĮŁŃÒÓÔÖÕØÙÚÛÜŲŪŸÝŻŹÑßÇŒÆČŠŽ∂ð .'-]+$";
        #endregion

        #region =================== membri & proprietà =========
        [Required(ErrorMessage = "Inserire un nome")]
        [StringLength(50, ErrorMessage = "La lunghezza del nome deve essere al massimo di 50 caratteri")]
        [Display(Name = "Nome")]
        [RegularExpression(TEXTREGEX, ErrorMessage = "Il nome contiene caratteri non consentiti")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Inserire un cognome")]
        [StringLength(50, ErrorMessage = "La lunghezza del cognome deve essere al massimo di 50 caratteri")]
        [Display(Name = "Cognome")]
        [RegularExpression(TEXTREGEX, ErrorMessage = "Il cognome contiene caratteri non consentiti")]
        public string LastName { get; set; }

        [DataType(DataType.Date, ErrorMessage = "La data di nascita inserita è in un formato non valido")]
        [BindRequired]
        [Required(ErrorMessage = "Inserire una data di nascita")]
        [Display(Name = "Data di nascita")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Inserire un indirizzo")]
        [StringLength(50, ErrorMessage = "La lunghezza dell'indirizzo deve essere al massimo di 50 caratteri")]
        [Display(Name = "Indirizzo")]
        [RegularExpression(TEXTREGEX, ErrorMessage = "L'indirizzo contiene caratteri non consentiti")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Inserire un numero civico")]
        [StringLength(4, ErrorMessage = "La lunghezza del numero civico deve essere al massimo di 4 caratteri")]
        [RegularExpression("(\\d+\\s*([A-Za-z](?![A-Za-z]))?)", ErrorMessage = "Il numero civico inserito è in un formato non valido")]
        [Display(Name = "Numero civico")]
        public string CivicNumber { get; set; }

        [Required(ErrorMessage = "Inserire una città")]
        [StringLength(50, ErrorMessage = "La lunghezza della città deve essere al massimo di 50 caratteri")]
        [Display(Name = "Città")]
        [RegularExpression(TEXTREGEX, ErrorMessage = "La città contiene caratteri non consentiti")]
        public string City { get; set; }

        [BindRequired]
        [Required(ErrorMessage = "Inserire un NAP valido")]
        [StringLength(5, MinimumLength = 4, ErrorMessage = "La lunghezza del NAP deve essere compresa tra 4 e 5 numeri")]
        [Display(Name = "NAP")]
        public int Nap { get; set; }

        [Required(ErrorMessage = "Inserire un numero di telefono")]
        [Display(Name = "Numero di telefono")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(50, ErrorMessage = "La lunghezza del numero di telefono deve essere compresa tra 8 e 50 caratteri", MinimumLength = 8)]
        [RegularExpression("^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$", ErrorMessage = "Il numero di telefono inserito è in un formato non riconosciuto")]
        [Phone(ErrorMessage = "Il numero di telefono inserito è in un formato non riconosciuto")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Inserire un indirizzo email")]
        [Display(Name = "Indirizzo e-mail")]
        [EmailAddress(ErrorMessage = "L'indirizzo email inserito è in un formato non riconosciuto")]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "L'indirizzo email inserito contiene caratteri non consentiti")]
        [StringLength(50, ErrorMessage = "La lunghezza dell'indirizzo email non può eccedere i 50 caratteri")]
        public string Email { get; set; }

        [Display(Name = "Sesso")]
        public string Gender { get; set; }

        [StringLength(500, ErrorMessage = "La lunghezza dell'hobby deve essere al massimo di 500 caratteri")]
        [RegularExpression("^((?![;[\\]{}<>\\\\]).)*$", ErrorMessage = "L'hobby contiene caratteri non consentiti")]
        public string Hobby { get; set; }

        [StringLength(500, ErrorMessage = "La lunghezza della professione deve essere al massimo di 500 caratteri")]
        [Display(Name = "Professione")]
        [RegularExpression("^((?![;[\\]{}<>\\\\]).)*$", ErrorMessage = "La professione contiene caratteri non consentiti")]
        public string Job { get; set; }
        #endregion

        #region =================== costruttori ================
        public User(string[] values)
        {
            FirstName = values.ElementAtOrDefault(1);
            LastName = values.ElementAtOrDefault(2);
            Birthday = DateTime.Parse(values.ElementAtOrDefault(3));
            Address = values.ElementAtOrDefault(4);
            CivicNumber = values.ElementAtOrDefault(5);
            City = values.ElementAtOrDefault(6);
            Nap = int.Parse(values.ElementAtOrDefault(7));
            PhoneNumber = values.ElementAtOrDefault(8);
            Email = values.ElementAtOrDefault(9);
            Gender = values.ElementAtOrDefault(10);
            Hobby = values.ElementAtOrDefault(11);
            Job = values.LastOrDefault();
        }

        public User()
        {

        }
        #endregion
    }
}
