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
    public partial class Rubrics : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public Rubrics()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// function loads the list of all clos in the combobox
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void Rubrics_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT Id,Name From dbo.Clo";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
                string query1 = "SELECT dbo.Rubric.*,dbo.Clo.Name From dbo.Rubric JOIN dbo.Clo ON dbo.Rubric.CloId = Clo.Id";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter ad1 = new SqlDataAdapter();
                ad1.SelectCommand = cmd1;
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = dt1;
                dataGridView1.DataSource = bs1;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;

            }
        }
        /// <summary>
        /// function shows list of rubrics and clo names against them in gridview
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query1 = "SELECT dbo.Rubric.*,dbo.Clo.Name From dbo.Rubric JOIN dbo.Clo ON dbo.Rubric.CloId = Clo.Id";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter ad1 = new SqlDataAdapter();
                ad1.SelectCommand = cmd1;
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                BindingSource bs1 = new BindingSource();
                bs1.DataSource = dt1;
                dataGridView1.DataSource = bs1;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[5].Visible = false;

            }
        }
        /// <summary>
        /// function edit or delete the rubric or insert a level against the rubric
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {

                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    if (MessageBox.Show("Deleting this item will cause other items to delete. Are You Sure you Want to Delete?","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                        string query1 = "DELETE FROM dbo.RubricLevel WHERE RubricId = '" + ID + "'";
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        cmd1.ExecuteNonQuery();
                        string query2 = "DELETE FROM dbo.AssessmentComponent WHERE RubricId = '" + ID + "'";
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        cmd2.ExecuteNonQuery();
                        string query = "DELETE FROM dbo.Rubric WHERE Id = '" + ID + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Deleted");
                        Rubrics r = new Rubrics();
                        this.Hide();
                        r.Show();
                    }
                    

                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string Details = (dataGridView1.Rows[e.RowIndex].Cells["Details"].Value).ToString();
                    string name = (dataGridView1.Rows[e.RowIndex].Cells["Name"].Value).ToString();

                    EditRubric frm = new EditRubric(ID, Details,name);
                    this.Hide();
                    frm.Show();

                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["RubricLevel"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    RubricLevel frm = new RubricLevel(ID);
                    this.Hide();
                    frm.Show();

                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
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
        /// function creates a new object of Addclo form and close the current form
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
        /// function inserts rubric data in the database
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "INSERT INTO dbo.Rubric( Details,CloId) VALUES('" + textBox1.Text.ToString() + "','" + comboBox1.SelectedValue + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved");
                textBox1.Text = "";


            }
        }
        /// <summary>
        /// function creates a new object of assessment form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button8_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }
    }
}
