﻿using System;
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
    /// Interaction logic for AdminLogin.xaml
    /// </summary>
    public partial class AdminLogin : Window
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (txtUsername.Text.Length == 0)
            {
                errormessage.Text = "Enter an Username.";
                txtUsername.Focus();
            }
            else
            {
                string username = txtUsername.Text;
                string password = passwordBox1.Password;


                //SqlConnection con = new SqlConnection("server=DOT-111417154-0;database=BMSDB;User Id=sa;password=pass@word1;integrated security=False;");
                //con.Open();
                //SqlCommand cmd = new SqlCommand("Select * from Users where Username='" + username + "'  and Password='" + password + "'", con);
                //cmd.CommandType = CommandType.Text;
                //SqlDataAdapter adapter = new SqlDataAdapter();
                //adapter.SelectCommand = cmd;
                //DataSet dataSet = new DataSet();
                //adapter.Fill(dataSet);
                //if (dataSet.Tables[0].Rows.Count > 0)
                if (username == "Pooja")
                {
                    // string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                    // welcome.TextBlockName.Text = username;//Sending value from one form to another form.  
                    LoanData obj = new LoanData();
                    obj.Show();
                    Close();
                }

                else
                {
                    errormessage.Text = "Sorry! Please enter existing emailid/password.";
                }
                // con.Close();
            }

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            UserDashboard obj = new UserDashboard();
            obj.Show();
        }
    }
}
