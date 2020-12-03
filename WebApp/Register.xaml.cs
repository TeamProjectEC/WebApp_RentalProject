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
