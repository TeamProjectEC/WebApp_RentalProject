using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    public class API
    {
        public static Context ctx;

        static API()
        {
            ctx = new Context();
            
        }
 

        public static Customer CheckUser(string user)
        {
            
            return ctx.Customer.FirstOrDefault(c => c.User_Name.ToLower() == user.ToLower());
        }

        public static Customer CheckPassword(string password)
        {
            
            return ctx.Customer.FirstOrDefault(c => c.Password.ToLower() == password.ToLower());
        }

        public static List<Movie> MovieSliceByTitleAZ(int x, int y)
        {
            return ctx.Movie.OrderByDescending(z => z.Title).Skip(x).Take(y).ToList();
        }

        public static List<Movie> GetMovieSlice(int skip_x, int take_x)
        {
            return ctx.Movie.OrderBy(m => m.Title).Skip(skip_x).Take(take_x).ToList();
        }

        public static bool RegisterSale(Customer customer, Movie movie)
        {

            try
            {
                ctx.Add(new Rental() { Rent_date = DateTime.Now, Customer = customer, Movie = movie });

                bool one_record_added = ctx.SaveChanges() == 1;
                return one_record_added;
            }
            catch (DbUpdateException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.InnerException.Message);
                return false;
            }
        }
    }

}

