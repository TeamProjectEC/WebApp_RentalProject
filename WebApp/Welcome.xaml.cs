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
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {
            Welcome newWindow = new Welcome();
            Application.Current.MainWindow = newWindow;

            newWindow.Show();

            this.Close();
        }

        private void Button_Click_Dashboar(object sender, RoutedEventArgs e)
        {
            var dash = new Dashboard();
            dash.Show();
            
        }

        private void Button_Click_Log_Out(object sender, RoutedEventArgs e)
        {
            var main_w = new MainWindow();
            main_w.Show();
            this.Close();
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
           
            string connection = @"Server=.\SQLEXPRESS; Database= SaleDatabase; Integrated Security=True";
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Movie WHERE Id  =  " + textboxMovieSearch.Text, con);
          
            System.Data.DataTable dt = new System.Data.DataTable();
  
          
           
            sda.Fill(dt);
            datagrid1.ItemsSource = dt.DefaultView;
            sda.Update(dt);


            MessageBox.Show("Succeded");
          
           
 

           
            }
        }
    }

