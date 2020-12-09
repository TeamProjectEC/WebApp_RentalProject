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
using DataBase;

namespace WebApp
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    /// 

   
    public partial class SearchWindow : Window
    {
        Context ctx = new Context();

        public SearchWindow()
        {
            InitializeComponent();
            binddatagrid();
        }
       private void binddatagrid()
        {
           
            g1.ItemsSource = ctx.Movie.ToArray();
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {

            binddatagrid();

        }
        private void Search_Movies()
        {
            g1.ItemsSource=ctx.Movie.Where(m => m.Title.Contains(textboxMovieSearch.Text)).Take(100000).ToArray();
        }
        private void Submit_Click1(object sender, RoutedEventArgs e)
        {
            Search_Movies();
        }
     

    }
}

