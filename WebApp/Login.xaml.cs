using System;
using System.Collections.Generic;
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
using DataBase;
using Microsoft.Data.SqlClient;

namespace WebApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        
        public Login()
        {
            InitializeComponent();
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection (@"Server=.\SQLEXPRESS; Database=RentalMoviesDatabase; Integrated Security=True");
            string query = "Select * From Customer Where Email = '" + emailBox.Text.Trim() + "' and Password = '" + passwordBox.Text.Trim() + "'";
            SqlDataAdapter sqlData = new SqlDataAdapter(query, connection);
            DataTable customer = new DataTable();
            sqlData.Fill(customer);
            if (customer.Rows.Count == 1)
            {
                Welcome objWelcome = new Welcome();
                this.Close();
                objWelcome.Show();
                var mw = new MainWindow();
                mw.Hide();

            }
            else
            {
                MessageBox.Show("Please Check your email and password!");
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
