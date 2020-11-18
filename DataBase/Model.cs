using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    class Model
    {
        public class Customer
        {
            public int Id { get; set; }
            public string First_Name { get; set; }
            public string Last_Name { get; set; }
            public int Birthday { get; set; }
            public string Mobile_Number { get; set; }
            public string Email_Address { get; set; }
            public List<Rental> Rental { get; set; }

        }


        public class Movie
        {

            public int Id { get; set; }
            public string Title { get; set; }
            public string Genre { get; set; }
            public string Director { get; set; }
            public float Rating { get; set; }
            public List<Rental> Rental { get; set; }

        }

        public class Rental
        {
            public int Id { get; set; }
            public Customer Customer { get; set; }
            public Movie Movie { get; set; }
            public string Rent_date { get; set; }
            public string Return_date { get; set; }
        }
    }
}
