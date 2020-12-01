using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
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
        
        SqlConnection con = new SqlConnection(@"Server =.\SQLEXPRESS; Database = RentalMoviesDatabase; Integrated Security = True");
        public Dashboard()
        {
            InitializeComponent();
           

            
            //SqlCommand cmd = new SqlCommand("SELECT * From Rental;", con);
            ///*.Id,CustomerId,First_Name,Last_Name,Movie.Id,MovieId, Movie.Title,Rent_date  From Rental JOIN Customer ON Rental.Id = Customer.Id  JOIN Movie ON Rental.Id = Movie.Id*/

            //con.Open();
            //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //tbl2.ItemsSource = dt.DefaultView;
            //cmd.Dispose();
            //con.Close();

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
            //    try
            //    {

            //        SqlCommand cmd = new SqlCommand("Delete From Rental Where Id = 5;", con);
            //        con.Open();
            //        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            //        DataTable dt = new DataTable();
            //        adapter.Fill(dt);
            //        tbl2.ItemsSource = dt.DefaultView;
            //        cmd.Dispose();
            //        con.Close();
            //    }
            //    catch (Exception)
            //    {

            //        MessageBox.Show(" Try again!");
            //    }

        }




       


        private void Fill_DataGrid(object sender, SelectionChangedEventArgs e)
        {
            

                SqlCommand cmd = new SqlCommand("Select Id,Title,Rating,Genre from Movie", con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tbl.ItemsSource = dt.DefaultView;
                cmd.Dispose();

                con.Close();
           

        }

        private void Fill_DataGrid2(object sender, SelectionChangedEventArgs e)
        {


        }

        
    }
}
