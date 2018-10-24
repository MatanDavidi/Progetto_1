﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Progetto_1.Models;

namespace Progetto_1.Controllers
{
    public class ReadCheckController : Controller
    {
        public IActionResult Index()
        {
            CSVHelper csv = new CSVHelper(
                string.Format("wwwroot/Registrazioni/Registrazioni_{0}_{1}_{2}.csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), 
                ";",
                new string[] {
                    "data", "nome", "cognome", "data_nascita", "via", "numero_civico",
                    "citta", "nap", "telefono", "email", "sesso", "hobby", "professione" });
            UserData model = new UserData(csv.ReadAllLines().LastOrDefault());
            return View(model);
        }
    }
}