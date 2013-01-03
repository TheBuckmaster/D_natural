using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BensCRS
{
    public partial class Form2 : Form
    {
        List<Course> Courses = new List<Course>();
        UserStudent StudentUser; 
        int state;
        List<Course> stdCourses = new List<Course>();

        public Form2(List<Course> C, UserStudent S1, int number)
        {
            InitializeComponent();

            Courses = C;
            StudentUser = S1;
            state = number; 

            if (state == 0)
            {
                Text = "Course List";
                CourseViewer();
}
            if (state == 1)
            {
                Text = "Schedule";
                RegisterButton.Text = "Un-Register from Selected Course"; 
                LogoutButton.Text = "Return to Course List";
                ScheduleButton.Text = "View Course History";

                SchedViewer();
            
            }

            if (state == 2)
            {
                Text = "Course History"; 
                HistViewer();
                LogoutButton.Text = "Return to Schedule";
                ScheduleButton.Hide();
                if (StudentUser.GPA().ToString().Length > 4)
                    GPAtxtbox.Text = StudentUser.GPA().ToString().Substring(0, 4);
                else
                    GPAtxtbox.Text = StudentUser.GPA().ToString();

                CreditTxtBox.Text = StudentUser.EarnedCredits().ToString();
                GPAtxtbox.Show();
                CreditTxtBox.Show();
                label1.Show();
                Credits.Show();
                RegisterButton.Hide();
            }

  
        }


        private void CourseViewer()
        {
            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView1.Hide();
            dataGridView1.DataSource = Courses;
            dataGridView1.Refresh();
            dataGridView1.Show(); 
        }
        
        private void SchedViewer()
        {
            dataGridView1.Hide();

            if (state == 1)
            {
                foreach (Course C0 in Courses)
                    if (StudentUser.MyCourses.Contains(C0.CourseName))
                        stdCourses.Add(C0);
            }

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 
            dataGridView1.DataSource = stdCourses;
            dataGridView1.Refresh();
            dataGridView1.Show(); 
        
        }

        private void HistViewer()
        {
            dataGridView1.DataSource = StudentUser.MyPastCourses;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (state == 0)
            {
                bool conflict = false;
                double creds = Courses[dataGridView1.SelectedRows[0].Index].credits;
                List<String> ConflictCs = new List<String>();
                foreach (Course C in Courses)
                {
                    if (StudentUser.MyCourses.Contains(C.CourseName))
                    {
                        creds += C.credits;
                        if (C.checkConflict(Courses[dataGridView1.SelectedRows[0].Index]))
                        {
                            if (!conflict)
                                conflict = true;
                            ConflictCs.Add(C.CourseName);
                        }
                    }
                }

                if (creds < 5.0)
                {
                    benutil.AddStudenttoCourse(StudentUser, Courses[dataGridView1.SelectedRows[0].Index]);
                    CourseViewer();
                }
                else MessageBox.Show("Can't enroll for 5 or more credits!");

                if (conflict)
                {
                    ConflictCs.Add(Courses[dataGridView1.SelectedRows[0].Index].CourseName);

                    foreach (String CC in ConflictCs)
                    {
                        if (StudentUser.CoursesThatConflict.Contains(CC))
                            continue;
                        else
                            StudentUser.CoursesThatConflict.Add(CC);
                    }

                    MessageBox.Show("Course has a scheduling conflict!");
                }
            }

            if (state == 1)
            {
                benutil.RemoveStudentfromCourse(StudentUser, stdCourses[dataGridView1.SelectedRows[0].Index]);
                SchedViewer(); 
            }
        }

        private void ScheduleButton_Click(object sender, EventArgs e)
        {

            if (state == 0)
            {
                Form2 it = new Form2(Courses, StudentUser, 1);
                it.Show();
                this.Close();
            }

            if (state == 1)
            {
                Form2 it = new Form2(Courses, StudentUser, 2);
                it.Show();
                this.Close();            
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            if (state == 2)
            {
                Form2 it = new Form2(Courses, StudentUser, 1);
                it.Show();
                this.Close();
            }
            if (state == 1)
            {
                Form2 it = new Form2(Courses, StudentUser, 0);
                it.Show();
                this.Close();
            }

            if (state == 0)
            {
                this.Close(); 
            }
        }



    }
}
