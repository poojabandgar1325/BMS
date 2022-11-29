using BMSWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BMSWPF.Views
{
    /// <summary>
    /// Interaction logic for UpdateUserAccount.xaml
    /// </summary>
    public partial class UpdateUserAccount : Window
    {
        public UpdateUserAccount()
        {
            InitializeComponent();
        }

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            String message = "Updated Sucessfully";

            using (HttpClient client = new HttpClient())
            {
                var user = new User()
                {
                    Name = txtName.Text,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text,
                    Address = txtAddress.Text,
                    Country = txtCountry.Text,
                    State = txtState.Text,
                    EmailID = txtEmail.Text,
                    PAN = txtPan.Text,
                    ContactNo = long.Parse(txtContactNo.Text),
                    DOB = DateTime.Parse(txtDOB.Text),
                    AccountType = txtAccountType.Text
                };
                try
                {
                    HttpResponseMessage response = client.PostAsJsonAsync("https://localhost:5001/Users/",user).Result;
                    response.EnsureSuccessStatusCode();
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                }

            }
            MessageBox.Show(this, message, "Message", MessageBoxButton.OK);
            DialogResult = true;
            }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            UserDashboard obj = new UserDashboard();
            obj.Show();
            Close();
        }
    }
    }

