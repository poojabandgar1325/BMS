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

namespace BMSWPF.Views
{
    /// <summary>
    /// Interaction logic for ApplyLoan.xaml
    /// </summary>
    public partial class ApplyLoan : Window
    {
        public ApplyLoan()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            var loan = new Loan();
            loan.LoanType = txtType.Text;
            loan.LoanAmount = long.Parse(txtAmount.Text);
            loan.Date = DateTime.Parse(txtDate.Text);
            loan.RateOfInterest = float.Parse(txtRateOfInterest.Text);
            loan.Duration = int.Parse(txtDuration.Text);
            loan.AccountNo = int.Parse(txtAccountNo.Text);


            var json = JsonConvert.SerializeObject(loan, Formatting.Indented);

            var stringContent = new StringContent(json);

            using (HttpClient client = new HttpClient())
            {
                var str = JsonConvert.SerializeObject(loan);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage rsp = client.PostAsJsonAsync("https://localhost:5001/Loans/", loan).Result;

            }
            Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            UserDashboard obj = new UserDashboard();
            obj.Show();
            Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            Close();
        }
    }
}