using DataBase;
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
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();


            int movie_skip_count = 0;
            int movie_take_count = 200;
            State.Movie = API.GetMovieSlice(movie_skip_count, movie_take_count);
            State.Movie1 = API.MovieSliceByTitleAZ(movie_skip_count, movie_take_count);

            int column_count = MovieGrid.ColumnDefinitions.Count;


            int row_count = (int)Math.Ceiling((double)State.Movie.Count / (double)column_count);

            if (comboBoxItem.Tag != null)
            {
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
                            var showTitle = new TextBox();
                            var showRating = new TextBox()
                            {
                                Cursor = Cursors.Arrow,
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Center,
                            };
                            LinearGradientBrush myBrush = new LinearGradientBrush();
                            
                            myBrush.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
                            myBrush.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
                            myBrush.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
                            showRating.Background = myBrush;



                            var image = new Image()
                            {
                                Cursor = Cursors.Hand,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(10, 20, 10, 40),
                            };
                            image.MouseUp += Image_MouseUp;

                            try
                            {
                                showTitle.Text = movie.Title;
                                image.Source = new BitmapImage(new Uri(movie.ImageURL));
                                showRating.Text = movie.Rating;
                            }
                            catch (Exception e) when
                                (e is ArgumentNullException ||
                                 e is System.IO.FileNotFoundException ||
                                 e is UriFormatException)
                            {

                                image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                            }


                            MovieGrid.Children.Add(showTitle);
                            MovieGrid.Children.Add(image);
                            MovieGrid.Children.Add(showRating);


                            Grid.SetRow(showTitle, y);
                            Grid.SetRow(image, y);
                            Grid.SetRow(showRating, y);


                            Grid.SetColumn(showTitle, x);
                            Grid.SetColumn(image, x);
                            Grid.SetColumn(showRating, x);
                        }
                    }
                }

            }
            else
            {
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

                        if (i < State.Movie1.Count)
                        {

                            var movie1 = State.Movie1[i];
                            var showTitle = new TextBox()
                            {
                                FontWeight = FontWeights.Bold,
                                Background = Brushes.Black,
                                Foreground = Brushes.White,
                                Margin = new Thickness( 0, 0, 0, 27 ),
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Bottom,
                            };
                            
                            

                            var showRating = new TextBox()
                            {
                                Cursor = Cursors.Arrow,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Bottom,
                                Margin = new Thickness(0, 0, 0, 5)

                            };
                            LinearGradientBrush myBrush2 = new LinearGradientBrush();
                            myBrush2.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
                            myBrush2.GradientStops.Add(new GradientStop(Colors.Orange, 0.5));
                            myBrush2.GradientStops.Add(new GradientStop(Colors.Red, 1.0));
                            
                            showRating.Background = myBrush2;
                            



                            var image = new Image()
                            {
                                Cursor = Cursors.Hand,
                                HorizontalAlignment = HorizontalAlignment.Center,
                                VerticalAlignment = VerticalAlignment.Center,
                                Margin = new Thickness(10, 10, 10, 50),
                            };
                            image.MouseUp += Image_MouseUp;

                            try
                            {
                                showTitle.Text = movie1.Title;
                                image.Source = new BitmapImage(new Uri(movie1.ImageURL));
                                showRating.Text = movie1.Rating;
                            }
                            catch (Exception e) when
                                (e is ArgumentNullException ||
                                 e is System.IO.FileNotFoundException ||
                                 e is UriFormatException)
                            {

                                image.Source = new BitmapImage(new Uri("https://wolper.com.au/wp-content/uploads/2017/10/image-placeholder.jpg"));
                            }


                            MovieGrid.Children.Add(showTitle);
                            MovieGrid.Children.Add(image);
                            MovieGrid.Children.Add(showRating);


                            Grid.SetRow(showTitle, y);
                            Grid.SetRow(image, y);
                            Grid.SetRow(showRating, y);


                            Grid.SetColumn(showTitle, x);
                            Grid.SetColumn(image, x);
                            Grid.SetColumn(showRating, x);
                        }
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

                if (MessageBox.Show("Do you want to rent this movie?", "Rent", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    if (API.RegisterSale(State.User, State.Pick))

                        MessageBox.Show("All is well and you can download your movie now.", "Sale Succeeded!", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                        MessageBox.Show("An error happened while buying the movie, please try again at a later time.", "Sale Failed!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
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
            private void Button_SearchWindow(object sender, RoutedEventArgs e)
            {
                var searchWindow = new SearchWindow();
                searchWindow.Show();

            }
        }
    }

