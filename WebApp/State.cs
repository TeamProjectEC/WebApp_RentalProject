using DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    class State
    {
        public static Customer User { get; set; }
        public static List<Movie> Movie { get; set; }
        public static Movie Pick { get; set; }
        public static Rental Rental { get; set; }
    }
}
