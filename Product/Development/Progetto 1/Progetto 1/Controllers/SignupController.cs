using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progetto_1.Models;

namespace Progetto_1.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(IFormCollection collection)
        {
            Utente u = new Utente();
            u.Nome = "bruce";
            return View("Index", u);
        }
    }
}