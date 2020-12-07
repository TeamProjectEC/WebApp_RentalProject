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
using System.Linq;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Data;


namespace WebApp
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
            binddatagrid();
        }


        private void binddatagrid()
        {
            string connection = (
             @"server=.\SQLEXPRESS;" +
             @"database=SaleDatabase;" +
             @"trusted_connection=true;" +
             @"MultipleActiveResultSets=True"
             );
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from  Movie ";
            cmd.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            System.Data.DataTable dt = new System.Data.DataTable("Movie");
            da.Fill(dt);
            g1.ItemsSource = dt.DefaultView;



        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            binddatagrid();


            MessageBox.Show("Succeded");

        }
        private void Submit_Click1(object sender, RoutedEventArgs e)
        {
            try
            {
                string connection = (
            @"server=.\SQLEXPRESS;" +
            @"database=SaleDatabase;" +
            @"trusted_connection=true;" +
            @"MultipleActiveResultSets=True"
            );
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Movie Where Id =   " + textboxMovieSearch.Text, con);


                System.Data.DataTable dt1 = new System.Data.DataTable();



                sda.Fill(dt1);
                g1.ItemsSource = dt1.DefaultView;
                sda.Update(dt1);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        

         }

    }
}

