using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// function creates a new object of Student form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Student stu = new Student();
            this.Hide();
            stu.Show();
        }
        /// <summary>
        /// function creates a new object of Addclo form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button3_Click(object sender, EventArgs e)
        {
            AddClo ac = new AddClo();
            this.Hide();
            ac.Show();
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
        /// function creates a new object of Assessment form and close the current form
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
        /// function creates a new object of assessmentcomponet form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button7_Click(object sender, EventArgs e)
        {
            AssessmentComponent ac = new AssessmentComponent();
            this.Hide();
            ac.Show();
        }
        /// <summary>
        /// function creates a new object of studentResult form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button8_Click(object sender, EventArgs e)
        {
            StudentResult sr = new StudentResult();
            this.Hide();
            sr.Show();
        }
        /// <summary>
        /// function creates a new object of classAttendance form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>
        private void button9_Click(object sender, EventArgs e)
        {
            ClassAttendance cs = new ClassAttendance();
            this.Hide();
            cs.Show();
        }
        /// <summary>
        /// function creates a new object of StudentAttendance form and close the current form
        /// </summary>
        /// <param name="sender">sender is the object sender that raised the event.</param>
        /// <param name="e"> e is the Event Argument of the object and basically contains the event data</param>

        private void button10_Click(object sender, EventArgs e)
        {
            StudentAttendance s = new StudentAttendance();
            this.Hide();
            s.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form2 r = new Form2();
            this.Hide();
            r.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form2 d = new Form2();
            d.Show();
        }
    }
}
