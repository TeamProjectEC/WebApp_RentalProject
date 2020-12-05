using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;


namespace DataBase
{
    public class SeedData
    {
        static void Main(string[] args)
        {
         

            using (var ctx = new Context())
            {
                ctx.RemoveRange(ctx.Movie);
                ctx.RemoveRange(ctx.Customer);
                ctx.RemoveRange(ctx.Rental);

                ctx.AddRange(new List<Customer> {
                    new Customer { First_Name = "David", Last_Name = "Luiz", Birthday = 1987, User_Name = "user", Password = "user"},

                });
                

                var movies = new List<Movie>();
                var lines = File.ReadAllLines(@"..\..\..\DBData\MovieGenre.csv");
                for (int i = 1; i < 1000; i++)
                {
                   
                    var cells = lines[i].Split(',');

                    var url = cells[5].Trim('"');

                   
                    try { var test = new Uri(url); }
                    catch (Exception) { continue; }

                    movies.Add(new Movie {Title = cells[2], Rating = cells[3], Genre = cells[4], ImageURL = url });
                }
                ctx.AddRange(movies);
                ctx.SaveChanges();

            }

        }
    }
 
}

   
