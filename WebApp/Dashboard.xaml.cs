using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

            string connection = @"Server=.\SQLEXPRESS; Database=RentalMoviesDatabase; Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
        }

        private void Click_Button_Add(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Button_Rent(object sender, RoutedEventArgs e)
        {

        }

        private void Click_Button_Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Click_Button_Remove(object sender, RoutedEventArgs e)
        {

        }


        private void listMovie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
