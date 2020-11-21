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
            this.Close();
        }

        private void Button_Click_Log_Out(object sender, RoutedEventArgs e)
        {
            var main_w = new MainWindow();
            main_w.Show();
            this.Close();
        }
    }
}
