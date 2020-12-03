using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    public static class API
    {
        static Context ctx;

        static API()
        {
            ctx = new Context();
        }

        public static Customer CheckUser(string user)
        {
            using var ctx = new Context();
            return ctx.Customer.FirstOrDefault(c => c.User_Name.ToLower() == user.ToLower());
        }

        public static Customer CheckPassword(string password)
        {
            using var ctx = new Context();
            return ctx.Customer.FirstOrDefault(c => c.Password.ToLower() == password.ToLower());
        }

       
    }

}

