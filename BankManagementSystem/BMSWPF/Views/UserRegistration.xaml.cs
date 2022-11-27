using BMSWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
    /// Interaction logic for UserRegistration.xaml
    /// </summary>
    public partial class UserRegistration : Window
    {
        public UserRegistration()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));
            var user = new User();

          //  user.Id = int.Parse(txtId.Text);
            user.Name = txtName.Text;
            user.UserName = txtUsername.Text;
            user.Password = txtPassword.Text;
            user.Address = txtAddress.Text;
            user.Country = txtCountry.Text;
            user.State = txtState.Text;
            user.EmailID = txtEmail.Text;
            user.PAN = txtPan.Text;
            user.ContactNo = long.Parse(txtContactNo.Text);
            user.DOB = DateTime.Parse(txtDOB.Text);
            user.AccountType = txtAccountType.Text;

            var response = client.PostAsJsonAsync("api/Users", user).Result;

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Employee Added");
                //txtId.Text = "";
                //txtName.Text = "";
                //txtAddress.Text = "";
                //txtDesignation.Text = "";
                //BindEmployeeList();
            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
        }

    }
}
