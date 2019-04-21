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
    public partial class ViewResult : Form
    {
        string connection = "Data Source=DESKTOP-APJ44CC;Initial Catalog=ProjectB;Integrated Security=True";

        public ViewResult()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function gives the list of all active students list when form loads in ComboBox
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void ViewResult_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(connection);
            //con.Open();
            //if (con.State == ConnectionState.Open)
            //{
            //    string query = "SELECT Id,RegistrationNumber From dbo.Student WHERE Status = '" + 5 + "'";
            //    SqlCommand cmd = new SqlCommand(query, con);
            //    SqlDataAdapter ad = new SqlDataAdapter();
            //    ad.SelectCommand = cmd;
            //    DataTable dt = new DataTable();
            //    ad.Fill(dt);
            //    comboBox1.DataSource = dt;
            //    comboBox1.DisplayMember = "RegistrationNumber";
            //    comboBox1.ValueMember = "Id";
            //}
           
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            ViewResult v = new ViewResult();
            this.Hide();
            v.Show();
        }
        /// <summary>
        /// function gives the Selected students Result when form loads in the GridView
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);
            con.Open();
            if (con.State == ConnectionState.Open)
            {
                string query = "Select Assessment.Title,Student.RegistrationNumber,AssessmentComponent.Name as Component, Rubric.Details as Rubrics, AssessmentComponent.TotalMarks as Component_Marks, RubricLevel.MeasurementLevel as Student_Rubric_Level , (Cast(RubricLevel.MeasurementLevel as float) / 4) * Cast(AssessmentComponent.TotalMarks as float) As Obtained FROM (((((StudentResult join AssessmentComponent ON StudentResult.AssessmentComponentId = AssessmentComponent.Id) join Rubric ON AssessmentComponent.RubricId = Rubric.Id) join RubricLevel ON StudentResult.RubricMeasurementId = RubricLevel.Id) join Student On StudentResult.StudentId = Student.Id) join Assessment On Assessment.Id = AssessmentComponent.AssessmentId)";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter ad = new SqlDataAdapter();
                ad.SelectCommand = cmd;
                DataTable dt = new DataTable();
                ad.Fill(dt);
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            this.Hide();
            s.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Assessment a = new Assessment();
            this.Hide();
            a.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rubrics r = new Rubrics();
            this.Hide();
            r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddClo c = new AddClo();
            this.Hide();
            c.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    SqlConnection con = new SqlConnection(connection);
        //    con.Open();
        //    if (con.State == ConnectionState.Open)
        //    {
        //        string query = "SELECT Clo.Name, Rubric.Details, RubricLevel.MeasurementLevel, RubricLevel.Details as 'Rubric level Details' From (((clo join Rubric ON clo.Id = Rubric.CloId) join RubricLevel On RubricLevel.RubricId = Rubric.Id) join StudentResult On StudentResult.RubricMeasurementId = RubricLevel.Id) Where StudentResult.StudentId = '"+comboBox1.SelectedValue+"'";
        //        SqlCommand cmd = new SqlCommand(query, con);
        //        SqlDataAdapter ad = new SqlDataAdapter();
        //        ad.SelectCommand = cmd;
        //        DataTable dt = new DataTable();
        //        ad.Fill(dt);
        //        BindingSource bs = new BindingSource();
        //        bs.DataSource = dt;
        //        dataGridView1.DataSource = bs;
        //    }
        //}
    }
}
