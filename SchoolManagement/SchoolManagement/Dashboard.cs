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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display();
            display2();
            display3();
            display4();

        }

        private void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from StudentTable", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                stCount.Text = Convert.ToString(count);
            }
            else
            {
                stCount.Text = "0";
            }

            con.Close();
        }

        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from SubjectTable", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                sbCount.Text = Convert.ToString(count);
            }
            else
            {
                sbCount.Text = "0";
            }

            con.Close();
        }

        private void display3()
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from TeacherTable", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                teCount.Text = Convert.ToString(count);
            }
            else
            {
                teCount.Text = "0";
            }

            con.Close();
        }

        private void display4()
        {
            SqlConnection con = new SqlConnection(@"Data Source = ASUS\SQLEXPRESS; Initial Catalog = schooldb; Integrated Security = True; Encrypt = False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select count(*) from EnrollTable", con);
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                erCount.Text = Convert.ToString(count);
            }
            else
            {
                erCount.Text = "0";
            }

            con.Close();
        }
    }
}
