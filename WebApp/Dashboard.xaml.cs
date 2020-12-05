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
        
        
        public Dashboard()
        {
            InitializeComponent();
           

            
           

        }
     
       
        private void Click_Button_Remove(object sender, RoutedEventArgs e)
        {
          

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
