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
    public partial class ViewClo : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";
        public ViewClo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function gives the list of all Clos in gridview when form loads
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void ViewClo_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "SELECT * From dbo.Clo";
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
        /// function Edit the CLO
        /// Function also delete the sleected CLO and Rubrics againast the CLO 
        /// and Rubriclevel and Assesment component against that Rubric According to user permission
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ///checks if e.columnindex is equal to the edit column index
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                    string name = (dataGridView1.Rows[e.RowIndex].Cells["Name"].Value).ToString();

                    EditClo frm = new EditClo(ID, name);
                    this.Hide();
                    frm.Show();

                }
            }
            ///checks if e.columnindex is equal to delete index
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    ///Confirms from the user
                    if (MessageBox.Show("Deleting this item will cause other items to delete. Are You Sure you Want to Delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Delete the whole hierarchy 
                        int ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                        SqlCommand comm = new SqlCommand("SELECT Id FROM dbo.Rubric Where  CloId = '" + ID + "' ", con);
                       
                        SqlDataReader reader = comm.ExecuteReader();
                        List<string> str = new List<string>();
                        int i = 0;
                        while (reader.Read())
                        {
                            str.Add(reader.GetValue(i).ToString());
                            i++;
                        }
                        reader.Close();
                        for (int j = 0; j < str.Count; j++)
                        {
                            SqlCommand com = new SqlCommand("SELECT Id FROM dbo.RubricLevel Where  RubricId = '" + str[j] + "' ", con);

                            SqlDataReader reader1 = com.ExecuteReader();
                            List<string> str1 = new List<string>();
                            int k = 0;
                            while (reader1.Read())
                            {
                                str1.Add(reader1.GetValue(k).ToString());
                                k++;
                            }
                            reader1.Close();
                            for (int f = 0; f < str1.Count; f++)
                            {
                                
                                string query4 = "DELETE FROM dbo.StudentResult WHERE RubricMeasurementId = '" + str1[f] + "'";
                                SqlCommand cmd4 = new SqlCommand(query4, con);
                                cmd4.ExecuteNonQuery();
                            }
                          
                            string query2 = "DELETE FROM dbo.RubricLevel WHERE RubricId = '" + str[j] + "'";
                                SqlCommand cmd3 = new SqlCommand(query2, con);
                                cmd3.ExecuteNonQuery();
                            
                        }
                        for (int j = 0; j < str.Count; j++)
                        {
                            string query2 = "DELETE FROM dbo.AssessmentComponent WHERE RubricId = '" + str[j] + "'";
                            SqlCommand cmd3 = new SqlCommand(query2, con);
                            cmd3.ExecuteNonQuery();
                        }
                        string query1 = "DELETE FROM dbo.Rubric WHERE CloId = '" + ID + "'";
                        SqlCommand cmd1 = new SqlCommand(query1, con);
                        cmd1.ExecuteNonQuery();
                        string query = "DELETE FROM dbo.Clo WHERE Id = '" + ID + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        ViewClo frm = new ViewClo();
                        this.Hide();
                        frm.Show();
                        MessageBox.Show("Date Deleted");
                    }
                }
            }
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
        /// function creates a new object of Student form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Student ad = new Student();
            this.Hide();
            ad.Show();
        }
        /// <summary>
        /// function creates a new object of AddClo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click(object sender, EventArgs e)
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
        /// function creates a new object of Student form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button2_Click_1(object sender, EventArgs e)
        {
        
            Student ad = new Student();
            this.Hide();
            ad.Show();

        }
        /// <summary>
        /// function creates a new object of AddClo form and close the current form
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
    }
}
