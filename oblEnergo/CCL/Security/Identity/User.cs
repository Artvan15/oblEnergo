using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public int UserID { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Email { get; }
        public int Phone { get; }
        protected string UserType { get; }

        public User(int userId, string name, string surname, string email,
            int phone, string userType)
        {
            UserID = userId;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            UserType = userType;
        }
    }
}
