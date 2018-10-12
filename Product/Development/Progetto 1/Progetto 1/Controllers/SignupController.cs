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
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection collection)
        {
            User u = CollectionToUser(collection);
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
    }
}