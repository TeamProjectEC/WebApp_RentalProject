using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataBase
{
    class Context : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Rental> Rental { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(
                @"server=.\SQLEXPRESS;" +
                @"database=RentalMoviesDatabase;" +
                @"trusted_connection=true;" +
                @"MultipleActiveResultSets=True"
                );
               
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

    }
}
