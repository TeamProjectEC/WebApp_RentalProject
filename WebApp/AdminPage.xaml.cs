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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            string connection = (
                @"server=.\SQLEXPRESS;" +
                @"database=SaleDatabase;" +
                @"trusted_connection=true;" +
                @"MultipleActiveResultSets=True"
                );
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Movie   " + textboxMovieSearch.Text, con);

            System.Data.DataTable dt = new System.Data.DataTable();



            sda.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);


            MessageBox.Show("Succeded");





        }
    }
}
