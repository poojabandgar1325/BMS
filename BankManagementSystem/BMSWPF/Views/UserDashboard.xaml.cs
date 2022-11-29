using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for UserDashboard.xaml
    /// </summary>
    public partial class UserDashboard : Window
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            UpdateUserAccount obj = new UpdateUserAccount();
            obj.Show();
            Close();
            
        }

        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            ApplyLoan obj = new ApplyLoan();
            obj.Show();
            Close();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
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
