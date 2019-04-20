using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DbProject
{
    public partial class StudentAttendance : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public StudentAttendance()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function saves the student Attendance of current Date
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                int x = 0;
                if (comboBox3.SelectedIndex == 0)
                {
                    x = 1;
                }
                if (comboBox3.SelectedIndex == 1)
                {
                    x = 2;
                }
                if (comboBox3.SelectedIndex == 2)
                {
                    x = 3;
                }
               
                string query = "INSERT INTO dbo.StudentAttendance(AttendanceId,StudentId,AttendanceStatus) VALUES('" + comboBox1.SelectedValue + "','" + comboBox2.SelectedValue + "','" + x + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved");
               
            }
        }
        /// <summary>
        /// function loads list of Attednace Date and Students in the comboboxes when form loads
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void StudentAttendance_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT * From dbo.ClassAttendance";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "AttendanceDate";
                comboBox1.ValueMember = "Id";
                string query1 = "SELECT Id,RegistrationNumber From dbo.Student Where Status = '"+5+"'";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter ad1 = new SqlDataAdapter();
                ad1.SelectCommand = cmd1;
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "RegistrationNumber";
                comboBox2.ValueMember = "Id";
            }
        }
        /// <summary>
        /// function creates a new object of viewattendance form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button8_Click(object sender, EventArgs e)
        {
            ViewAttendance v = new ViewAttendance();
            this.Hide();
            v.Show();
        }
        /// <summary>
        /// function creates a new object of Assessment form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button7_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }
        /// <summary>
        /// function creates a new object of Rubric form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button4_Click(object sender, EventArgs e)
        {
            Rubrics r = new Rubrics();
            this.Hide();
            r.Show();
        }
        /// <summary>
        /// function creates a new object of student form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            this.Hide();
            s.Show();
        }
        /// <summary>
        /// function creates a new object of addclo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            AddClo a = new AddClo();
            this.Hide();
            a.Show();
        }
        /// <summary>
        /// function creates a new object of form1 form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}