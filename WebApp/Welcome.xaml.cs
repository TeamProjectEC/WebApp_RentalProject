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
using DataBase;

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

            
            int movie_skip_count = 0;
            int movie_take_count = 100;
            State.Movie = API.GetMovieSlice(movie_skip_count, movie_take_count);

            int column_count = MovieGrid.ColumnDefinitions.Count;

          
            int row_count = (int)Math.Ceiling((double)State.Movie.Count / (double)column_count);

            for (int y = 0; y < row_count; y++)
            {
                
                MovieGrid.RowDefinitions.Add(
                    new RowDefinition()
                    {
                        Height = new GridLength(350, GridUnitType.Pixel)
                    });

               
                for (int x = 0; x < column_count; x++)
                {
                    
                    int i = y * column_count + x;
                   
                    if (i < State.Movie.Count)
                    {
                       
                        var movie = State.Movie[i];
                      
                        var image = new Image()
                        {
                            Cursor = Cursors.Hand, 
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(10, 10, 10, 10),
                        };
                        image.MouseUp += Image_MouseUp;

                        try
                        {
                            image.Source = new BitmapImage(new Uri(movie.ImageURL)); 
                        }
                        catch (Exception e) when
                            (e is ArgumentNullException ||
                             e is System.IO.FileNotFoundException ||
                             e is UriFormatException)
                        {
                            
                            image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                        }

                       
                        MovieGrid.Children.Add(image);
                        
                        Grid.SetRow(image, y);
                        Grid.SetColumn(image, x);
                    }
                }
            }
        }

        
        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            
            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

           
            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            
            State.Pick = State.Movie[i];

            
            if (API.RegisterSale(State.User, State.Pick))
                
                MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
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


    }
}
