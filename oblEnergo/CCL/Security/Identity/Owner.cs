using System;
using System.Collections.Generic;
using System.Text;
namespace CCL.Security.Identity
{
    public class Owner
        : User
    {
        public bool HaveDebt = false;
        public Owner(int userId, string name, string surname, string email,
            int phone) : base(userId, name, surname, email, phone, nameof(Owner))
        {

        }
    }
}
