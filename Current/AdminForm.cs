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
    public partial class AdminForm : Form
    {
        UserAdmin admin;
        private UserStudent asthisstudent;
        private UserFaculty asthisfaculty;
        private Course thisCourse; 
        List<UserFaculty> FacultyList = new List<UserFaculty>();
        List<UserStudent> StudentList = new List<UserStudent>();
        List<Course> Courses = new List<Course>();
        private adminstate state;
        private studentstate studstate;

        private enum adminstate 
        { 
            dflt,
            student,
            faculty,
            crs
        }

        private enum studentstate
        { 
            sviewall,
            ssched,
            salcourses,
            sadvisor,
            skill
        }

        public AdminForm(List<UserFaculty> fl, List<UserStudent> sl, List<Course> cl, UserAdmin adm)
        {
            state = adminstate.dflt; 
            InitializeComponent();
            admin = adm;
            FacultyList = fl;
            StudentList = sl;
            Courses = cl;
            hidethings(); 
            
        }

        private void hidethings()
        {
            button1.Hide();
            killButton.Hide(); 
            dataGridView1.Hide(); 
            AdvisorButton.Hide();
            dataGridView2.Hide();
            FastRegButton.Hide();
            ActualRegButton.Hide(); 
            hideDetail(); 
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
                this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            switch (state)
            {

                case adminstate.dflt: { } break; //Do nothing.
                case adminstate.student:
                    if (studstate == studentstate.sviewall)
                    {
                        asthisstudent = StudentList[dataGridView1.SelectedRows[0].Index];
                        //MessageBox.Show("Student : " + asthisstudent.FirstName + " " + asthisstudent.LastName); 
                        studstate = studentstate.ssched;
                        this.Text = "View/Change " + asthisstudent.UserName + "'s course schedule.";
                        List<Course> StdCrs = new List<Course>();
                        foreach (Course C in Courses)
                        {
                            if (asthisstudent.MyCourses.Contains(C.CourseName))
                            {
                                StdCrs.Add(C);
                            }
                        }
                        dataGridView1.DataSource = StdCrs;
                        AdvisorButton.Hide(); 
                        button1.Text = "Student List";
                        FastRegButton.Text = "View all courses";
                        FastRegButton.Show();
                    }
                    else
                    {
                        //state = adminstate.dflt;
                        //AdvisorButton.Show();
                        //MessageBox.Show("State 2b");
                        IVS(); 

                    }
                    break;
                default: //MessageBox.Show("CASE 3");
                                        break;
            }
        }

        private void ViewStudents(object sender, EventArgs e)
        {
            switch (state){
                case adminstate.student:
                    {
                        state = adminstate.dflt;
                        button3.Enabled = true;
                        button4.Enabled = true;
                        hidethings(); 
                                        } break; 
                case adminstate.dflt:
                    {
                        button3.Enabled = false;
                        button4.Enabled = false; 
                        IVS();
                                        } break; 
        }
        }

        private void IVS() //"Inner View Students." I wanted to call it without event arguments.
        {
            this.Text = "Viewing List of Students"; 
            state = adminstate.student;
            studstate = studentstate.sviewall;
            dataGridView1.DataSource = StudentList;
            dataGridView1.Show(); 
            FastRegButton.Hide();
            button1.Enabled = true; 
            button1.Text = "View Student Courses";
            button1.Show();
            killButton.Show();
            AdvisorButton.Enabled = true; 
            AdvisorButton.Show();
        }


        private void AdvisorButton_Click(object sender, EventArgs e)
        {
            studstate = studentstate.sadvisor;
            asthisstudent = StudentList[dataGridView1.SelectedRows[0].Index];
            this.Text = "View/Change " + asthisstudent.UserName + "'s advisor.";
            StringBuilder OutString = new StringBuilder();
            OutString.Append(asthisstudent.UserName);
            OutString.Append("'s advisor is ");
            OutString.Append(asthisstudent.Advisor);
            OutString.Append(". Change?");
            DetailBox.Text = OutString.ToString(); 
            showDetail(); 
        }

        private void showDetail()
        {
            DetailBox.Show();
            YesButton.Show();
            NoButton.Show();
        }

        private void hideDetail()
        {
            DetailBox.Hide();
            YesButton.Hide();
            NoButton.Hide();
        }

        private void FastRegButton_Click(object sender, EventArgs e)
        {
            if (studstate == studentstate.ssched)
            {
                studstate = studentstate.salcourses;
                FastRegButton.Text = "Cancel";
                dataGridView2.DataSource = Courses;
                dataGridView2.Show();
                ActualRegButton.Text = "Register"; 
                ActualRegButton.Show(); 
            }
            else
            {
                if (studstate == studentstate.salcourses)
                {
                    studstate = studentstate.ssched;
                    dataGridView2.Hide();
                    ActualRegButton.Hide(); 

                    FastRegButton.Text = "Add Student to Course";
                }
            }
        }

        private void ActualRegButton_Click(object sender, EventArgs e)
        {
            if (studstate == studentstate.salcourses)
            {
                thisCourse = Courses[dataGridView2.SelectedRows[0].Index];
                benutil.AddStudenttoCourse(asthisstudent, thisCourse, admin);
            }

            if (studstate == studentstate.sadvisor) 
            {
                asthisstudent.Advisor = FacultyList[dataGridView2.SelectedRows[0].Index].UserName;
                ActualRegButton.Hide();
                dataGridView2.Hide(); 
                IVS(); 
            }
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            if (state == adminstate.student)
            {
                if (studstate == studentstate.sadvisor)
                {
                    hideDetail();
                    dataGridView2.DataSource = FacultyList;
                    dataGridView2.Show();
                    ActualRegButton.Text = "Set Advisor";
                    ActualRegButton.Show();
                }

                if (studstate == studentstate.skill)
                {
                    int studentindex = dataGridView1.SelectedRows[0].Index;

                    //StudentList.RemoveAt(studentindex);
                    //This causes a dataerror in the DGV1 and I don't know how to handle it. 

                    hideDetail();
                    IVS();


                }
            }

            if (state == adminstate.faculty) { };
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            hideDetail();
            IVS(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (state){
                case adminstate.dflt:
                    {
                        state = adminstate.faculty;
                        dataGridView1.DataSource = FacultyList;
                        dataGridView1.Show();
                        this.Text = "Viewing Faculty List";
                        StudentButton.Enabled = false;
                        button4.Enabled = false;
                    } break; 
                case adminstate.faculty:
                    {
                        state = adminstate.dflt;
                        StudentButton.Enabled = true;
                        button4.Enabled = true;
                        dataGridView1.Hide(); 
                    } break; 
            }
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            if (state == adminstate.student)
            {
                studstate = studentstate.skill;
                button1.Enabled = false;
                AdvisorButton.Enabled = false;
                int studentindex = dataGridView1.SelectedRows[0].Index;
                showDetail();
                DetailBox.Text = "Delete " + StudentList[studentindex].UserName + "?";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case adminstate.dflt:
                    {
                        state = adminstate.crs;
                        dataGridView1.DataSource = Courses;
                        dataGridView1.Show();
                        this.Text = "Viewing Course List";
                        StudentButton.Enabled = false;
                        button3.Enabled = false;
                    } break;
                case adminstate.crs:
                    {
                        state = adminstate.dflt;
                        StudentButton.Enabled = true;
                        button3.Enabled = true;
                        dataGridView1.Hide();
                    } break;
            }
        }








    }
}
