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
    public partial class AssessmentComponent : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public AssessmentComponent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function loads the list of assessments and rubric in the combobox
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void AssessmentComponent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT Id,Title From dbo.Assessment";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Title";
                comboBox1.ValueMember = "Id";
  
                string query1 = "SELECT Id,Details From dbo.Rubric";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter ad1 = new SqlDataAdapter();
                ad1.SelectCommand = cmd1;
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                comboBox2.DataSource = dt1;
                comboBox2.DisplayMember = "Details";
                comboBox2.ValueMember = "Id";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// function saves the assessment component
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "INSERT INTO dbo.AssessmentComponent(Name,RubricId,TotalMarks,DateCreated,DateUpdated,AssessmentId) VALUES('" + textBox1.Text.ToString() + "','" + comboBox2.SelectedValue + "','" + textBox4.Text.ToString() + "','" + DateTime.Now + "','" + DateTime.Now + "','" + comboBox1.SelectedValue + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved");
                textBox1.Text = "";

                textBox4.Text = "";
            }
        }
        /// <summary>
        /// function creates a new object of viewassessmentComponent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewAssessmentComponent v = new ViewAssessmentComponent();
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
        /// function creates a new object of addclo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button4_Click(object sender, EventArgs e)
        {
            AddClo ad = new AddClo();
            this.Hide();
            ad.Show();
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
    }
}
 