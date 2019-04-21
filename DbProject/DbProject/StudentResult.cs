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
    public partial class StudentResult : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public StudentResult()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function loads the student Data and Rubric Level Data  and Assessment Component
        /// in respective comboboxes when form loads
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void StudentResult_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT Id,RegistrationNumber From dbo.Student WHERE Status = '" + 5 + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "RegistrationNumber";
                comboBox1.ValueMember = "Id";
                string query1 = "SELECT Id,Details From dbo.RubricLevel";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter ad1 = new SqlDataAdapter();
                ad1.SelectCommand = cmd1;
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                comboBox4.DataSource = dt1;
                comboBox4.DisplayMember = "Details";
                comboBox4.ValueMember = "Id";
                string query2 = "SELECT Id,Name From dbo.AssessmentComponent";
                SqlCommand cmd2 = new SqlCommand(query2, con);
                SqlDataAdapter ad2 = new SqlDataAdapter();
                ad2.SelectCommand = cmd2;
                DataTable dt2 = new DataTable();
                ad2.Fill(dt2);
                comboBox5.DataSource = dt2;
                comboBox5.DisplayMember = "Name";
                comboBox5.ValueMember = "Id";

            }
        }
        /// <summary>
        /// function creates a new object of Form1 form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
        /// <summary>
        /// function creates a new object of Student form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            this.Hide();
            s.Show();
        }
        /// <summary>
        /// function creates a new object of AddClo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            AddClo a = new AddClo();
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
        /// function creates a new object of assessment form and close the current form
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
        /// function saves the student Result in Database
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "INSERT INTO dbo.StudentResult(StudentId,AssessmentComponentId,RubricMeasurementId,EvaluationDate) VALUES('" + comboBox1.SelectedValue + "','" + comboBox5.SelectedValue + "','" + comboBox4.SelectedValue + "','" + DateTime.Now + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved");
            }
        }
        /// <summary>
        /// function creates a new object of viewResult form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button8_Click(object sender, EventArgs e)
        {
            ViewResult v = new ViewResult();
            this.Hide();
            v.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
