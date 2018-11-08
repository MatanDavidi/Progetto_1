using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
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
        public IActionResult Index(IFormCollection collection)
        {
            User u = CollectionToUser(collection);
            return View("Index", u);
        }

        [HttpPost]
        public IActionResult DataCheck(IFormCollection collection)
        {
            if (ModelState.IsValid)
            {
                User u = CollectionToUser(collection);
                return View("DataCheck", u);
            }
            else
            {
                return View();
            }
        }

        private User CollectionToUser(IFormCollection collection)
        {
            collection.TryGetValue("FirstName", out StringValues fName);
            collection.TryGetValue("LastName", out StringValues lName);
            collection.TryGetValue("Birthday", out StringValues bDay);
            collection.TryGetValue("Address", out StringValues address);
            collection.TryGetValue("CivicNumber", out StringValues cNumber);
            collection.TryGetValue("City", out StringValues city);
            collection.TryGetValue("Nap", out StringValues nap);
            collection.TryGetValue("PhoneNumber", out StringValues phone);
            collection.TryGetValue("Email", out StringValues email);
            collection.TryGetValue("Gender", out StringValues gender);
            collection.TryGetValue("Hobby", out StringValues hobby);
            collection.TryGetValue("Job", out StringValues job);

            User u = new User()
            {
                FirstName = fName.FirstOrDefault(),
                LastName = lName.FirstOrDefault(),
                Address = address.FirstOrDefault(),
                CivicNumber = cNumber.FirstOrDefault(),
                City = city.FirstOrDefault(),
                PhoneNumber = phone.FirstOrDefault(),
                Email = email.FirstOrDefault(),
                Gender = gender.FirstOrDefault(),
                Hobby = hobby.FirstOrDefault(),
                Job = job.FirstOrDefault(),
            };

            DateTime bd = new DateTime();
            DateTime.TryParse(bDay.FirstOrDefault(), out bd);
            u.Birthday = bd;

            int np = new int();
            int.TryParse(nap.FirstOrDefault(), out np);
            u.Nap = np;
            return u;
        }

        [HttpPost]
        public IActionResult Save(IFormCollection collection)
        {
            User user = CollectionToUser(collection);
            try
            {
                DateTime dt = DateTime.Now;
                CSVHelper all = new CSVHelper("wwwroot/Registrazioni/Registrazioni_tutte.csv", ";", new string[] { "data", "nome", "cognome", "data_nascita", "via", "numero_civico", "citta", "nap", "telefono", "email", "sesso", "hobby", "professione" });
                CSVHelper day = new CSVHelper(string.Format("wwwroot/Registrazioni/Registrazioni_{0}_{1}_{2}.csv", dt.Year, dt.Month, dt.Day), ";", new string[] { "data", "nome", "cognome", "data_nascita", "via", "numero_civico", "citta", "nap", "telefono", "email", "sesso", "hobby", "professione" });
                string[] s = new string[]
                {
                    dt.ToString(),
                    user.FirstName,
                    user.LastName,
                    user.Birthday.ToString(),
                    user.Address,
                    user.CivicNumber,
                    user.City,
                    user.Nap.ToString(),
                    user.PhoneNumber,
                    user.Email,
                    user.Gender,
                    user.Hobby,
                    user.Job
                };
                all.Write(s);
                day.Write(s);

                return RedirectToAction("", "ReadCheck");
            }
            catch (Exception)
            {
                return View("Index");
            }
        }
    }
}