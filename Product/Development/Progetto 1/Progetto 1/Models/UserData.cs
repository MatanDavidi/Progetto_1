using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Progetto_1.Models
{
    public class UserData : User
    {
        #region =================== membri & proprietà =========
        public DateTime Date { get; set; }
        #endregion

        #region =================== costruttori ================
        public UserData(string[] values)
        {
            Date = DateTime.Parse(values.FirstOrDefault());
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

        public UserData(DateTime dateTime, User u)
        {
            Date = dateTime;
            FirstName = u.FirstName;
            LastName = u.LastName;
            Birthday = u.Birthday;
            Address = u.Address;
            CivicNumber = u.CivicNumber;
            City = u.City;
            Nap = u.Nap;
            PhoneNumber = u.PhoneNumber;
            Email = u.Email;
            Gender = u.Gender;
            Hobby = u.Hobby;
            Job = u.Job;
        }

        public UserData(User u) : this(DateTime.Now, u)
        {

        }
        #endregion
    }
}
