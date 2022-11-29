using BMSWPF.Models;
using Newtonsoft.Json;
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
   
            var user = new User();
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

            var json = JsonConvert.SerializeObject(user, Formatting.Indented);

            var stringContent = new StringContent(json);

            using (HttpClient client = new HttpClient())
            {
                var str = JsonConvert.SerializeObject(user);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage rsp = client.PostAsJsonAsync("https://localhost:5001/Users/", user).Result;
               
            }
            
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            Close();
        }
    }
}
