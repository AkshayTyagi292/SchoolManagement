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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolManagement
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();

            SqlCommand cnn = new SqlCommand("Insert into TeacherTable values(@teacherid, @teachername, @gender, @phone)", con);
            cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@TeacherName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Gender", (textBox3.Text));
            cnn.Parameters.AddWithValue("@Phone", (textBox4.Text));

            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  TeacherTable", con);
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
            SqlCommand cnn = new SqlCommand("Update TeacherTable set teachername=@teachername , gender=@gender , phone=@phone where teacherid=@teacherid", con);
            cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@TeacherName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Gender", (textBox3.Text));
            cnn.Parameters.AddWithValue("@Phone", (textBox4.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  TeacherTable", con);
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
            SqlCommand cnn = new SqlCommand("Delete TeacherTable where teacherid=@teacherid ", con);
            cnn.Parameters.AddWithValue("@TeacherId", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  TeacherTable", con);
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
            textBox4.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from  TeacherTable", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
