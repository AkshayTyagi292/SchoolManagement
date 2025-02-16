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
    public partial class Section : Form
    {
        public Section()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cnn = new SqlCommand("Insert into SectionTable values(@sectionid, @sectionname, @section)", con);
            cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@SectionName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Section", (textBox3.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  SectionTable", con);
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
            SqlCommand cnn = new SqlCommand("Update SectionTable set sectionname=@sectionname , section=@section where sectionid=@sectionid", con);
            cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@SectionName", (textBox2.Text));
            cnn.Parameters.AddWithValue("@Section", (textBox3.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  SectionTable", con);
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
            SqlCommand cnn = new SqlCommand("Delete SectionTable where sectionid=@sectionid", con);
            cnn.Parameters.AddWithValue("@SectionId", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();

            SqlCommand cnn2 = new SqlCommand("select * from  SectionTable", con);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
