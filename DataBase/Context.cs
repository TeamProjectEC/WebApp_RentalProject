using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static DataBase.Model;

namespace DataBase
{
    class Context : DbContext
    {
        public DbSet<Customer> Customrs { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                 @"server=.\SQLEXPRESS;" +
                    "database = SimpleSalesDatabase;" +
                    "trusted_connection=true"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }

    }
}
