using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class LoginForrm : Form
    {
        public LoginForrm()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-B5L4044\\SQLEXPRESS;Initial Catalog=Studentdb;Integrated  Security=True");

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (string.IsNullOrWhiteSpace(txtpassword.Text) || string.IsNullOrWhiteSpace(txtusername.Text))
                {
                    MessageBox.Show(" Password and UserName field are required");
                    return;
                }
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*)FROM Login WHERE Password=@Password AND UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@UserName", txtusername.Text);
                int count = (int)cmd.ExecuteScalar();
                if(count>0)
                {
                
                    MessageBox.Show("Login Sucessfull !");
                    this.Hide();
                    Admin f = new Admin();
                    f.Show();

                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password !");
                }
            }
            catch (Exception ex) 
            { Console.WriteLine(ex.Message); }
            finally { 
                con.Close();
                txtpassword.Clear();
                txtusername.Clear();
            }
        }

        private void buttonreset_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (string.IsNullOrWhiteSpace(txtpassword.Text) || string.IsNullOrWhiteSpace(txtusername.Text))
                {
                    MessageBox.Show(" Enter your previous Password and UserName !");
                    return;
                }
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*)FROM Login WHERE Password=@Password AND UserName=@UserName", con);
                cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmd.Parameters.AddWithValue("@UserName", txtusername.Text);
                int count = (int)cmd.ExecuteScalar();
                if (count > 0)
                {   
                   
                    buttonconfirm.Visible = true;
                    MessageBox.Show("Enter Your New Credentail and then Click on Confirm");
                    

                }
                else
                {
                    MessageBox.Show("Invalid User Name or Password Correct Credential are requied to reset Password !");
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            finally { 
                con.Close();
                txtpassword.Clear();
                txtusername.Clear();
            }
        }

        private void buttonconfirm_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                if (string.IsNullOrWhiteSpace(txtpassword.Text) || string.IsNullOrWhiteSpace(txtusername.Text))
                {
                    MessageBox.Show(" Enter your New Password and UserName !");
                    return;
                }
                SqlCommand cmc = new SqlCommand("UPDATE Login SET Password=@Password,UserName=@UserName WHERE Password=@Password AND UserName=@UserName");
                cmc.Parameters.AddWithValue("@Password", txtpassword.Text);
                cmc.Parameters.AddWithValue("@UserName", txtusername.Text);
                cmc.ExecuteNonQuery();
                buttonconfirm.Visible = false;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                txtpassword.Clear();
                txtusername.Clear();
                con.Close();}
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
           
        }
    }
}
