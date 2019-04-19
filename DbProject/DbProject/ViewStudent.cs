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
    public partial class ViewStudent : Form
    {
        /// <summary>
        /// this form shows the list of all students in the Database
        /// </summary>
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";

        public ViewStudent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Edit and Delete Funcytionality Against each of the student in gridview
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //this code excuted when e.columnindex is equal to the edit column Index
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string fname = (dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value).ToString();
                    string lname = (dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value).ToString();
                    string contact = (dataGridView1.Rows[e.RowIndex].Cells["Contact"].Value).ToString();
                    string email = (dataGridView1.Rows[e.RowIndex].Cells["Email"].Value).ToString();
                    string rg = (dataGridView1.Rows[e.RowIndex].Cells["RegistrationNumber"].Value).ToString();
                    int status = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Status"].Value);
                    StudentEdit frm = new StudentEdit(ID, fname, lname, contact, email, rg, status);
                    this.Hide();
                    frm.Show();

                }
            }
            //this code excuted when e.columnindex is equal to the Delete column Index
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string query = "UPDATE dbo.Student SET Status = '" + 6 + "'  WHERE Id = '" + ID + "'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Updated");
                    ViewStudent vs = new ViewStudent();
                    this.Hide();
                    vs.Show();

                }
            }
        }
        /// <summary>
        /// function gives the list of all students when form loads
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void ViewStudent_Load(object sender, EventArgs e)
        {
           
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT * From dbo.Student Where Status = '"+ 5 +"'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns["Edit"].DisplayIndex = 8;
                dataGridView1.Columns["Delete"].DisplayIndex = 7;
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
        /// function creates a new object of student form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            this.Hide();
            stu.Show();
        }
        /// <summary>
        /// function creates a new object of AddClo form and close the current form
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
        /// function creates a new object of assessment form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button5_Click(object sender, EventArgs e)
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
    }
}
