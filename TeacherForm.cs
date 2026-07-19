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
    public partial class TeacherForm : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-B5L4044\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=true");
        public TeacherForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Teachers WHERE TeacherCNIC=@TeacherCNIC", con);
            cmd.Parameters.AddWithValue("@TeacherCNIC", txtCNIC.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Teacher Deleted Successfully!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Teachers (Name, CNIC, Department) VALUES (@Name, @CNIC, @Department)", con);
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@CNIC", txtCNIC.Text);
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Teacher Added Successfully!");
            txtCNIC.Clear();
            txtDepartment.Clear();
            txtName.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Teachers SET Name=@Name, CNIC=@CNIC, Department=@Department where CNIC=@CNIC ", con);
            
            cmd.Parameters.AddWithValue("@Name", txtName.Text);
            cmd.Parameters.AddWithValue("@CNIC", txtCNIC.Text);
            cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Teacher Updated Successfully!");
            txtCNIC.Clear();
            txtDepartment.Clear();
            txtName.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Teachers", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
      
            TeacherForm tf = new TeacherForm();
            tf.Show();   
        

    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {

        }
    }
}
