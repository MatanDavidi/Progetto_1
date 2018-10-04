using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Progetto_1.Models;

namespace Progetto_1.Controllers
{
    public class SignupController : Controller
    {
        public IActionResult Index()
        {
            Utente u = new Utente();
            u.Nome = "Big shaq";
            return View(u);
        }

        public IActionResult Signup()
        {
            return null;
        }
    }
}