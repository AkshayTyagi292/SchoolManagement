using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Enrollment : Form
    {
        public Enrollment()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cnn = new SqlCommand("Insert into EnrollTable values(@enrollmentid, @studentname, @section, @enrolldate)", con);
            cnn.Parameters.AddWithValue("@EnrollmentId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Section", (textBox3.Text));
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker1.Value);

            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  EnrollTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn2);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

            MessageBox.Show("Record Saved Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cnn = new SqlCommand("Update EnrollTable set studentname=@studentname, section=@section, enrolldate=@enrolldate where enrollid=@enrollid", con);

            cnn.Parameters.AddWithValue("@EnrollId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Section", (textBox3.Text));
            cnn.Parameters.AddWithValue("@EnrollDate", dateTimePicker1.Value);

            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  EnrollTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn2);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

            MessageBox.Show("Record Updated Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cnn = new SqlCommand("Delete EnrollTable where enrollid=@enrollid ", con);
            cnn.Parameters.AddWithValue("@EnrollId", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  EnrollTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn2);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;

            MessageBox.Show("Record Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
    }
}
