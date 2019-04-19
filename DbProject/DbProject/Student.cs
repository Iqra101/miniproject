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

    public partial class Student : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public Student()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// function creates a new object of addclo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            AddClo ac = new AddClo();
            this.Hide();
            ac.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

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
        /// function creates a new object of viewstudent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewStudent st = new ViewStudent();
            this.Hide();
            st.Show();
        }
        /// <summary>
        /// function creates a new object of viewstudent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            ViewStudent stu = new ViewStudent();
            this.Hide();
            stu.Show();
        }
        /// <summary>
        /// function creates a new object of Form1 form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void Student_Load(object sender, EventArgs e)
        {

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
        /// function saves the student data
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click_1(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "INSERT INTO dbo.Student(FirstName,LastName,Contact,Email,RegistrationNumber,Status) VALUES('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + 5 + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                

            }
            else
            {
                MessageBox.Show("Database Not connected");
            }
        }
        /// <summary>
        /// function creates a new object of viewstudent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click_2(object sender, EventArgs e)
        {
            ViewStudent vs = new ViewStudent();
            this.Hide();
            vs.Show();
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
