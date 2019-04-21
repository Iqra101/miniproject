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
    public partial class EditAssessmentComponent : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public EditAssessmentComponent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// parametrized constructor
        /// </summary>
        /// <param name="id">id of the Assessment Component</param>
        /// <param name="name">name of assessment component</param>
        /// <param name="marks">marks of the assessment component</param>
        public EditAssessmentComponent(int id,string name, int marks)
        {
            InitializeComponent();
            ID = id;
            textBox1.Text = name;
            textBox4.Text = marks.ToString();
        }
        /// <summary>
        /// function loads the list of assessments and rubrics
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void EditAssessmentComponent_Load(object sender, EventArgs e)
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
        /// <summary>
        /// function updates the assessment component
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "UPDATE dbo.AssessmentComponent SET Name = '" + textBox1.Text + "', RubricId = '" + comboBox2.SelectedValue + "', TotalMarks = '" + textBox4.Text + "', DateUpdated = '" + DateTime.Now + "', AssessmentId = '" + comboBox1.SelectedValue + "' WHERE Id = '" + ID + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated");
                ViewAssessmentComponent vs = new ViewAssessmentComponent();
                this.Hide();
                vs.Show();

            }
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
        /// <summary>
        /// function creates a new object of viewassessmentcomponent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewAssessmentComponent a = new ViewAssessmentComponent();
            this.Hide();
            a.Show();
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
        private void button4_Click(object sender, EventArgs e)
        {
            AddClo ac = new AddClo();
            this.Hide();
            ac.Show();
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
    }
}
