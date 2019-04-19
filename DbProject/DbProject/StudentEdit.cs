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
    public partial class StudentEdit : Form
    {
        public int ID;
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public StudentEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// parameterized Contructor
        /// </summary>
        /// <param name="Id">Id of student</param>
        /// <param name="firstname">first nameof student</param>
        /// <param name="lastname">last name of student</param>
        /// <param name="contact">contact of student</param>
        /// <param name="email">email sof student</param>
        /// <param name="rg">Registration Number of Student</param>
        /// <param name="status">status of student</param>
        public StudentEdit(int Id, string firstname, string lastname, string contact, string email, string rg, int status)
        {
            InitializeComponent();
            ID = Id;
            textBox1.Text = firstname;
            textBox2.Text = lastname;
            textBox3.Text = contact;
            textBox4.Text = email;
            textBox5.Text = rg;
            

        }
        private void StudentEdit_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Update the student
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "UPDATE dbo.Student SET FirstName = '" + textBox1.Text + "', LastName = '" + textBox2.Text + "',Contact = '" + textBox3.Text + "', Email = '" + textBox4.Text + "', RegistrationNumber = '" + textBox5.Text + "', Status = '" + 5 + "' WHERE Id = '" + ID + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Updated");
                ViewStudent vs = new ViewStudent();
                this.Hide();
                vs.Show();

            }
        }
        /// <summary>
        /// function creates a new object of viewstudent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            ViewStudent vs = new ViewStudent();
            this.Hide();
            vs.Show();
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
        /// function creates a new object of Addclo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            AddClo ad = new AddClo();
            this.Hide();
            ad.Show();
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
        private void button1_Click_1(object sender, EventArgs e)
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
        private void button4_Click_1(object sender, EventArgs e)
        {
            Rubrics r = new Rubrics();
            this.Hide();
            r.Show();
        }
        /// <summary>
        /// function creates a new object of Addclo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            AddClo ad = new AddClo();
            this.Hide();
            ad.Show();
        }
        /// <summary>
        /// function creates a new object of viewstudent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            ViewStudent vs = new ViewStudent();
            this.Hide();
            vs.Show();
        }
        /// <summary>
        /// function creates a new object of form1 form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button7_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }
    }
}
