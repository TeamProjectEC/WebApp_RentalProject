﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataBase;
namespace WebApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Button_Click_Home(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_Login(object sender, RoutedEventArgs e)
        {
            var login_obj = new Login();
            login_obj.Show();
        }

        private void Button_Click_Register(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_About(object sender, RoutedEventArgs e)
        {

        }
    } 
}