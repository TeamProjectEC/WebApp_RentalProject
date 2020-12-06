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

            State.User = API.CheckUser(userBox.Text.Trim());
            if (State.User != null)
            {
                if (State.User.Password == passwordBox.Password)
                {
                    var welcome = new Welcome();
                    welcome.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Check your password.");
                }
            }
            else
            {
                MessageBox.Show("Please Check your username.");
            }

        }
        
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var mainw = new MainWindow();
            mainw.Show();
            Close();
        }
    }
}
