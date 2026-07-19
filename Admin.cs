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
using System.Xml.Linq;
namespace WindowsFormsApp1
{
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-B5L4044\\SQLEXPRESS;Initial Catalog=StudentDB;Integrated Security=true");

        public Admin()
        {
            InitializeComponent();
        }


        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Required field check
                if (string.IsNullOrWhiteSpace(txtRollNo.Text) ||
                    string.IsNullOrWhiteSpace(txtSemester.Text) ||
                    string.IsNullOrWhiteSpace(txtDepartment.Text))
                {
                    MessageBox.Show("RollNo, Semester, and Department are required!");
                    return;
                }

                con.Open();

                // Duplicate RollNo + Semester + Department check
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Student WHERE RollNo=@RollNo AND Department=@Department AND Semester=@Semester", con);
                checkCmd.Parameters.AddWithValue("@RollNo", txtRollNo.Text);
                checkCmd.Parameters.AddWithValue("@Semester", txtSemester.Text);
                checkCmd.Parameters.AddWithValue("@Department", txtDepartment.Text);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("This RollNo with the same Semester and Department already exists!");
                    return;
                }

                // Email duplicate check (only if email is entered)
                if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    SqlCommand emailCmd = new SqlCommand(
                        "SELECT COUNT(*) FROM Student WHERE Email=@Email", con);
                    emailCmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    int emailCount = (int)emailCmd.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        MessageBox.Show("This Email already exists!");
                        return;
                    }
                }

                // RollNo validation
                int rollno = Convert.ToInt32(txtRollNo.Text);
                if (rollno <= 0) txtRollNo.Text = "0";

                // Semester validation
                int semester = Convert.ToInt32(txtSemester.Text);
                if (semester <= 0 || semester > 8) txtSemester.Text = "0";

                // CGPA optional check
                decimal cgpa = 0.00m;
                if (!string.IsNullOrWhiteSpace(txtCGPA.Text))
                {
                    decimal.TryParse(txtCGPA.Text, out cgpa);
                    if (cgpa < 0 || cgpa > 4) cgpa = 0.00m;
                }

                // Optional fields
                string name = string.IsNullOrWhiteSpace(txtName.Text) ? "" : txtName.Text;
                string address = string.IsNullOrWhiteSpace(txtAddress.Text) ? "" : txtAddress.Text;
                string sdof = string.IsNullOrWhiteSpace(txtSD.Text) ? "" : txtSD.Text;
                string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;

                // Insert query
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Student (RollNo, Name, Semester, CGPA, Department, Address, SDof, Email) " +
                    "VALUES (@RollNo, @Name, @Semester, @CGPA, @Department, @Address, @SDof, @Email)", con);

                cmd.Parameters.AddWithValue("@RollNo", txtRollNo.Text);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Semester", txtSemester.Text);
                cmd.Parameters.AddWithValue("@CGPA", cgpa);
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@SDof", sdof);
                cmd.Parameters.AddWithValue("@Email", (object)email ?? DBNull.Value);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Record Added Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtCGPA.Clear();
                txtDepartment.Clear();
                txtRollNo.Clear();
                txtName.Clear();
                txtSemester.Clear();
                txtAddress.Clear();
                txtSD.Clear();
                txtEmail.Clear();
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                dataGridView1.Visible = true;
                buttonhide.Visible = true;
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Please select a row to update!");
                    return;
                }

                // NEW values (latest from DataGridView)
                string newRollNo = dataGridView1.CurrentRow.Cells["RollNo"].EditedFormattedValue.ToString();
                string newDepartment = dataGridView1.CurrentRow.Cells["Department"].EditedFormattedValue.ToString();
                string newSemester = dataGridView1.CurrentRow.Cells["Semester"].EditedFormattedValue.ToString();
                string newName = dataGridView1.CurrentRow.Cells["Name"].EditedFormattedValue.ToString();
                string newCgpa = dataGridView1.CurrentRow.Cells["CGPA"].EditedFormattedValue.ToString();
                string newAddress = dataGridView1.CurrentRow.Cells["Address"].EditedFormattedValue.ToString();
                string newSDof = dataGridView1.CurrentRow.Cells["SDof"].EditedFormattedValue.ToString();
                string newEmail = dataGridView1.CurrentRow.Cells["Email"].EditedFormattedValue.ToString();

                // Primary Key (must exist in your table)
                string studentId = dataGridView1.CurrentRow.Cells["StudentID"].Value.ToString();

                // Duplicate RollNo + Department + Semester check (exclude current row)
                SqlCommand checkCmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM Student 
              WHERE RollNo=@NewRollNo AND Department=@NewDepartment AND Semester=@NewSemester
              AND StudentID<>@StudentID", con);

                checkCmd.Parameters.AddWithValue("@NewRollNo", newRollNo);
                checkCmd.Parameters.AddWithValue("@NewDepartment", newDepartment);
                checkCmd.Parameters.AddWithValue("@NewSemester", newSemester);
                checkCmd.Parameters.AddWithValue("@StudentID", studentId);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Another student already exists with same RollNo, Department, and Semester!");
                    return;
                }

                // Duplicate Email check (exclude current row, only if email is not empty)
                if (!string.IsNullOrWhiteSpace(newEmail))
                {
                    SqlCommand emailCmd = new SqlCommand(
                        @"SELECT COUNT(*) FROM Student 
                  WHERE Email=@NewEmail AND StudentID<>@StudentID", con);

                    emailCmd.Parameters.AddWithValue("@NewEmail", newEmail);
                    emailCmd.Parameters.AddWithValue("@StudentID", studentId);

                    int emailCount = (int)emailCmd.ExecuteScalar();
                    if (emailCount > 0)
                    {
                        MessageBox.Show("Another student already exists with same Email!");
                        return;
                    }
                }

                // Update using StudentID
                SqlCommand cmd = new SqlCommand(
                    @"UPDATE Student 
              SET RollNo=@NewRollNo, Department=@NewDepartment, Semester=@NewSemester, 
                  Name=@NewName, CGPA=@NewCGPA, Address=@NewAddress, SDof=@NewSDof, Email=@NewEmail
              WHERE StudentID=@StudentID", con);

                cmd.Parameters.AddWithValue("@NewRollNo", newRollNo);
                cmd.Parameters.AddWithValue("@NewDepartment", newDepartment);
                cmd.Parameters.AddWithValue("@NewSemester", newSemester);
                cmd.Parameters.AddWithValue("@NewName", newName);
                cmd.Parameters.AddWithValue("@NewCGPA", newCgpa);
                cmd.Parameters.AddWithValue("@NewAddress", newAddress);
                cmd.Parameters.AddWithValue("@NewSDof", newSDof);
                cmd.Parameters.AddWithValue("@NewEmail", string.IsNullOrWhiteSpace(newEmail) ? (object)DBNull.Value : newEmail);
                cmd.Parameters.AddWithValue("@StudentID", studentId);

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                    MessageBox.Show("Record Updated Successfully!");
                else
                    MessageBox.Show("Update failed. Record not found!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {   try
            {
                con.Open();
                if (string.IsNullOrWhiteSpace(txtDepartment.Text) || string.IsNullOrWhiteSpace(txtSemester.Text) || string.IsNullOrWhiteSpace(txtRollNo.Text)) 
                {
                    MessageBox.Show("Semester ,Departmet and Roll No field are Required");
                    return;
                }
                SqlCommand cmc =new SqlCommand("Select COUNT(*)from Student Where RollNo=@RollNo AND Semester=@Semester AND Department=@Department",con);
                cmc.Parameters.AddWithValue("@RollNo", txtRollNo.Text);
                cmc.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmc.Parameters.AddWithValue("@Semester", txtSemester.Text);


                int count = (int)cmc.ExecuteScalar();
                if (count==0)
                {
                    MessageBox.Show("No match found for the Semester ,Department, RollNO ");
                    return;
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RollNo=@RollNo AND Semester=@Semester AND Department=@Department", con);
                cmd.Parameters.AddWithValue("@RollNo", txtRollNo.Text);
                cmd.Parameters.AddWithValue("@Semester", txtSemester.Text);
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);
                cmd.ExecuteNonQuery();
                
                MessageBox.Show("Record Deleted Successfully!");
            }
            catch(Exception ex)
            {  
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txtCGPA.Clear();
                txtDepartment.Clear();
                txtRollNo.Clear();
                txtName.Clear();
                txtSemester.Clear();
                con.Close();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Visible = true;
                buttonhide.Visible = true;
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
               
                dataGridView1.DataSource = dt;
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
                {
                txtCGPA.Clear();
                txtDepartment.Clear();
                txtRollNo.Clear();
                txtName.Clear();
                txtSemester.Clear();
                con.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {  try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Student WHERE RollNo=@RollNo AND Semester=@Semester AND Department=@Department", con);
                cmd.Parameters.AddWithValue("@RollNo", txtRollNo.Text);
                cmd.Parameters.AddWithValue("@Semester", txtSemester.Text);
                cmd.Parameters.AddWithValue("@Department", txtDepartment.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                
            }
            catch(Exception ex)
            {  MessageBox.Show(ex.Message);
            }
            finally
            {
                txtCGPA.Clear();
                txtDepartment.Clear();
                txtRollNo.Clear();
                txtName.Clear();
                txtSemester.Clear();
                con.Close();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            TeacherForm tf = new TeacherForm();
            tf.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void buttonhide_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible= false;
            buttonhide.Visible= false;
        }
    }
}
