using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace SchoolManagement
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cnn = new SqlCommand("Insert into AttendanceTable values(@attendanceid, @studentname, @status)", con);
            cnn.Parameters.AddWithValue("@AttendanceId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Status", (textBox3.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  AttendanceTable", con);
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
            SqlCommand cnn = new SqlCommand("Update AttendanceTable set studentname=@studentname , status=@status where attendanceid=@attendanceid", con);
            cnn.Parameters.AddWithValue("@AttendanceId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@StudentName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Status", (textBox3.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  AttendanceTable", con);
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
            SqlCommand cnn = new SqlCommand("Delete AttendanceTable where attendanceid=@attendanceid", con);
            cnn.Parameters.AddWithValue("@attendanceId", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  AttendanceTable", con);
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
