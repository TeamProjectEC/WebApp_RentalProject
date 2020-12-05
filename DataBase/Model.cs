
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{

    public class Customer
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Birthday { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public virtual List<Rental> Rental { get; set; }

        public static implicit operator Customer(string v)
        {
            throw new NotImplementedException();
        }
    }

    public class Movie
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Rating { get; set; }
        public string Genre { get; set; }
        public string ImageURL { get; set; }
        public virtual List<Rental> Rental { get; set; }

    }

    public class Rental
    {
        public int Id { get; set; }
        public DateTime Rent_date { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Movie Movie { get; set; }
    }

}
