using BMSWPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using System.Net.Http.Formatting;

namespace BMSWPF.Views
{
    /// <summary>
    /// Interaction logic for LoanData.xaml
    /// </summary>
    public partial class LoanData : Window
    {
        public LoanData()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BindUserList();
        }
       


        private void BindUserList()
        {

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("https://localhost:5001/Users/").Result;
                response.EnsureSuccessStatusCode();
                IList<User> usr = response.Content.ReadAsAsync<IList<User>>().Result;
                grdUser.ItemsSource = usr;
            }
        }
    }
}
