using DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    static class State
    {
        public static Customer User { get; set; }
        public static List<Movie> Movie { get; set; }
        public static List<Movie> Movie1 { get; set; }
        public static Movie Pick { get; set; }
        public static List<Rental> Rental { get; set; }
        

    }
}
