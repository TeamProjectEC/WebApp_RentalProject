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
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Click_Button_Submit(object sender, RoutedEventArgs e)
        {

            if (passwordBox1.Password.Length == 0)
            {
                MessageBox.Show("Old password can not be blank.");
            }
            else if (passwordBox2.Password.Length == 0)
            {
                MessageBox.Show("New password can not be blank.");
            }
            else if (passwordBox3.Password.Length == 0)
            {
                MessageBox.Show("Confirm password can not be blank.");
            }

            else
            {
                State.User = API.CheckPassword(passwordBox1.Password);
                if (State.User != null)
                {
                    if (passwordBox2.Password == passwordBox3.Password)
                    {

                        State.User.Password = passwordBox2.Password;
                        API.ctx.Customer.Update(State.User);
                        API.ctx.SaveChanges();
                        MessageBox.Show("Your password has ben changed successfully.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password and Confirm must be the same.");
                    }
                }
                else
                {
                    MessageBox.Show("Old Password is incorrect.");
                }
            }




        }


        private void Click_Button_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
