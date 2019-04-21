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
    public partial class ViewAssessment : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public ViewAssessment()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function shows list of all assessment in the gridview 
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void ViewAssessment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT * From dbo.Assessment";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[2].Visible = false;
                

            }
        }
        /// <summary>
        /// function Edit and Delete the Assessment
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Edit form will be Open if user clicks the edit column
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
   
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string title = (dataGridView1.Rows[e.RowIndex].Cells["Title"].Value).ToString();
                    int marks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TotalMarks"].Value);
                    int w = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TotalWeightage"].Value);
                    EsitAssessment frm = new EsitAssessment(ID,title,marks,w);
                    this.Hide();
                    frm.Show();

                }
            }
            ///Delete the current Assessment and Assessment Component against the Assessment
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    if (MessageBox.Show("Deleting this item will cause other items to delete. Are You Sure you Want to Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                        string query1 = "DELETE FROM dbo.AssessmentComponent WHERE AssessmentId = '" + ID + "'";
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        cmd1.ExecuteNonQuery();
                        string query = "DELETE FROM dbo.Assessment WHERE Id = '" + ID + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        ViewAssessment frm = new ViewAssessment();
                        this.Hide();
                        frm.Show();
                    }
                }

            }
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
        /// <summary>
        /// function creates a new object of AddClo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            AddClo clo = new AddClo();
            this.Hide();
            clo.Show();
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
