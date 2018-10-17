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
            User u = new User()
            {
                Address = "address",
                Birthday = DateTime.Now,
                City = "city",
                CivicNumber = "12",
                Email = "a@b.c",
                FirstName = "firstName",
                Gender = "m",
                Hobby = "hobby",
                Job = "job",
                LastName = "lastName",
                Nap = 6900,
                PhoneNumber = "0123456789"
            };
            return View(u);
        }

        [HttpPost]
        public IActionResult Index(User u)
        {
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
                Job = hobby.FirstOrDefault(),
            };

            DateTime bd = new DateTime();
            DateTime.TryParse(bDay.FirstOrDefault(), out bd);
            u.Birthday = bd;

            int np = new int();
            int.TryParse(nap.FirstOrDefault(), out np);
            u.Nap = np;
            return u;
        }

        public IActionResult Clear()
        {
            ModelState.Clear();
            return View("Index");
        }

        [HttpPost]
        public IActionResult Save(IFormCollection collection)
        {
            User user = CollectionToUser(collection);
            try
            {
                CSVHelper all = new CSVHelper("wwwroot/Registrazioni/Registrazioni_tutte.csv", new string[] { "data", "nome", "cognome", "data_nascita", "via", "numero_civico", "citta", "nap", "telefono", "email", "sesso", "hobby", "professione" });
                CSVHelper day = new CSVHelper(string.Format("wwwroot/Registrazioni/Registrazioni_{0}_{1}_{2}.csv", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day), new string[] { "data", "nome", "cognome", "data_nascita", "via", "numero_civico", "citta", "nap", "telefono", "email", "sesso", "hobby", "professione" });
                string[] s = new string[]
                {
                    DateTime.Now.ToString(),
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
                return View("Index", user);
            }
            catch (Exception e)
            {
                return View("Index", new User());
            }
        }
    }
}