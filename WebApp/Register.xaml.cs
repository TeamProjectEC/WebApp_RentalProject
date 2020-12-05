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
using DataBase;

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

            using (var ctx = new Context())
            {
                try
                {
                    if (textBoxFirstName.Text.Length == 0)
                    {
                        errormessage.Text = "Firstname can not be blank.";

                    }
                    else if (textBoxLastName.Text.Length == 0)
                    {
                        errormessage.Text = "Lastname can not be blank.";
                    }

                    else if (textBoxBirthday.Text.Length == 0)
                    {
                        errormessage.Text = "Birthday can not be blank.";
                    }

                    else if (textBoxUser.Text.Length == 0)
                    {
                        errormessage.Text = "Username can not be blank.";
                    }
                    else if (passwordBox1.Text.Length == 0 && passwordBoxConfirm.Text.Length == 0)
                    {
                        errormessage.Text = "Password can not be blank.";
                    }
                    else if (passwordBoxConfirm.Text.Length == 1 && passwordBox1.Text.Length != passwordBoxConfirm.Text.Length)
                    {
                        errormessage.Text = "Confirm password must be same as password.";
                    }
                    else
                    {  
                        
                        State.User = API.CheckUser(textBoxUser.Text);
                        if (State.User != null)
                        {
                                errormessage.Text = "Username already taken.";
                        }

                        else
                        {

                            ctx.Customer.Add(new Customer { First_Name = textBoxFirstName.Text, Last_Name = textBoxLastName.Text, Birthday = Convert.ToInt32(textBoxBirthday.Text), User_Name = textBoxUser.Text, Password = passwordBox1.Text });                       
                            ctx.SaveChanges();
                            MessageBox.Show("You have Registered successfully.");
                            var welecome = new Welcome();
                            welecome.Show();
                            this.Close();

                        }
                    }


                }

                catch (Exception)
                {

                    throw;
                }
            }

        }


        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
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
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


    }
}
