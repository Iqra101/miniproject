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
    public partial class ViewAssessmentComponent : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public ViewAssessmentComponent()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function shows list of all assessment components in the gridview when form loads
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void ViewAssessmentComponent_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT * From dbo.AssessmentComponent";
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
        /// function Edit the Component or Delete the Component
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///checks if e.ColumnIndex is equal to edit index
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string fname = (dataGridView1.Rows[e.RowIndex].Cells["Name"].Value).ToString();
                    int marks = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["TotalMarks"].Value);
                    EditAssessmentComponent frm = new EditAssessmentComponent(ID, fname, marks);
                    this.Hide();
                    frm.Show();

                }
            }
            ///checks id e.column index is equal to delete index
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string query = "DELETE FROM dbo.AssessmentComponent WHERE Id = '" + ID + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    int x = cmd.ExecuteNonQuery();
           
                    ViewAssessmentComponent frm = new ViewAssessmentComponent();
                    this.Hide();
                    frm.Show();
                }
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
        /// function creates a new object of student form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
        {
            Student ad = new Student();
            this.Hide();
            ad.Show();

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
        private void button5_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }
        /// <summary>
        /// function creates a new object of assessmentComponent form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            AssessmentComponent a = new AssessmentComponent();
            this.Hide();
            a.Show();
        }
    }
}
