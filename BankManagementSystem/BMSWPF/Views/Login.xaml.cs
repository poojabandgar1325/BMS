using BMSWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        UserRegistration registration = new UserRegistration();
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (textBox2.Text != "" && wordBox1.word != "")
            {
                DBconnection objconn = new DBconnection();
                objconn.connection(); //calling connection   

                SqlCommand com = new SqlCommand("user_Sp_Login", objconn.con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@UserId", textBox2.Text);
                com.Parameters.AddWithValue("@word", wordBox1.word);

                int IsValidUser = Convert.ToInt32(com.ExecuteScalar());
                if (IsValidUser == 1) //if user found it returns 1  
                {
                    Landing obj = new Landing();

                    MainWindow objmain = new MainWindow();
                    obj.Show(); //after login Redirect to second window  
                    objmain.Hide();//after login hide the  Login window  


                }
                else
                {

                    MessageBox.Show("InValid UserId Or word");

                }
            }
            else
            {

                MessageBox.Show("UserId and word Is Required");

            }
        
        

        }
    }
}


