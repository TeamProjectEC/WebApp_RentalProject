using DataBase;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        
        
        public Dashboard()
        {
            InitializeComponent();

            
        }

        private void Click_Button_Show(object sender, RoutedEventArgs e)
        {
            Context ctx = new Context();


            var query = from a in ctx.Rental
                    join b in ctx.Customer on a.Id equals b.Id
                    join c in ctx.Movie on a.Id equals c.Id
                    select new
                    {
                        ID = a.Id,
                        FirstName = b.First_Name,
                        CustomerId = b.Id,
                        Title = c.Title,
                        MovieId = c.Id,
                        RentDate = a.Rent_date,

                    };

            dataView.ItemsSource = query.ToList();

        }

        private void Click_Button_Remove(object sender, RoutedEventArgs e)
        {
           

        }
        private void Click_Button_Moveis_List(object sender, RoutedEventArgs e)
        {
            Context ctx = new Context();


            var query = from a in ctx.Movie

                        select new
                        {
                            ID = a.Id,
                            Title = a.Title,
                            Rating = a.Rating,
                            Genre = a.Genre,                  

                        };

            dataView2.ItemsSource = query.ToList();

        }

        private void Click_Button_Change(object sender, RoutedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.Show();

        }

        private void Click_Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

          
        private void Fill_DataGrid(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Fill_DataGrid2(object sender, SelectionChangedEventArgs e)
        {

        }

       
    }
}
