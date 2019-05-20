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
    public partial class RubricLevel : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public int ID;
        public RubricLevel()
        {
            InitializeComponent();
        }
        /// <summary>
        /// parameterized Consturctor
        /// </summary>
        /// <param name="id">takes id of rubric against which the level is Added</param>
        public RubricLevel(int id)
        {
            InitializeComponent();
            ID = id;
        }
        /// <summary>
        /// function inserts the rubriclevel data in the database
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
                if(comboBox1.SelectedIndex==0)
                {
                    x = 1;
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    x = 2;
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    x = 3;
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    x = 4;
                }
                string query = "INSERT INTO dbo.RubricLevel(RubricId,Details,MeasurementLevel) VALUES('" + ID + "','" + textBox1.Text + "','" + x + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data saved");
                textBox1.Text = "";
                

            }
        }
        /// <summary>
        /// function delete of edit the rubric level
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {

                if (con.State == ConnectionState.Open)
                {
                    int ID1 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string query = "DELETE FROM dbo.RubricLevel WHERE Id = '" + ID1 + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Date Deleted");
                    RubricLevel rl = new RubricLevel(ID);
                    this.Hide();
                    rl.Show();

                    
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {

                if (con.State == ConnectionState.Open)
                {
                    int ID1 = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string detail = dataGridView1.Rows[e.RowIndex].Cells["Details"].Value.ToString();
                    int multi= Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["MeasurementLevel"].Value);
                    EditRubricLevel ed = new EditRubricLevel(ID,ID1, detail, multi);
                    this.Hide();
                    ed.Show();

                }
            }
        }
        /// <summary>
        /// function shows list of all rubric level of the selected rubric in gridview
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT * From dbo.RubricLevel WHERE RubricId = '" + ID + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns["Edit"].DisplayIndex = 5;
                dataGridView1.Columns["Delete"].DisplayIndex = 4;
                
            }
        }
        /// <summary>
        /// function creates a new object of rubric form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
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
        /// function creates a new object of Assessment form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button8_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }

        private void RubricLevel_Load(object sender, EventArgs e)
        {

        }
    }
}
