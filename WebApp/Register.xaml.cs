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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();


        }
 
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            string connection = @"Server=.\SQLEXPRESS; Database=RentalMoviesDatabase; Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            try
            {
                
                string query = "Insert into Customer(First_Name,Last_Name,Birthday,User_Name,Password) Values('" + textBoxFirstName.Text + "','" + textBoxLastName.Text + "','" + textBoxBirthday.Text + "','" + textBoxUser.Text + "','" + passwordBox1.Text + "')";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                da.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Account created successfully..");
                ClearData();
                this.Close();
                var wlc = new Welcome();
                wlc.Show();
                var mw = new MainWindow();
                mw.Hide();
               
            }
            catch
            {
                MessageBox.Show("Error occured...");
            }
            finally
            {
                con.Close();
            }
        }

        private void ClearData()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxBirthday.Text = "";
            textBoxUser.Text = "";
            passwordBox1.Text = "";
            passwordBoxConfirm.Text = "";
          
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

       
    }
}
