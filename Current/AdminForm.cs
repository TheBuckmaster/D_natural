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
        private List<Course> facCourse = new List<Course>();
        private Course thisCourse;
        List<UserFaculty> FacultyList = new List<UserFaculty>();
        List<UserStudent> StudentList = new List<UserStudent>();
        List<Course> Courses = new List<Course>();
        private adminstate state;
        private studentstate studstate;
        private courseadminstate cadst;
        private List<String> newNames = new List<String>();
        private List<String> ddkkss;


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

        private enum courseadminstate
        {
            viewall,
            name,
            title,
            instructor,
            credits,
            time
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
            TrueNo.Hide();
            DetailBox2.Hide();
            YesButton2.Hide();
            NoButton2.Hide();
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
                case adminstate.faculty:
                    {
                        asthisfaculty = FacultyList[dataGridView1.SelectedRows[0].Index];
                        List<String> myCrsStringList = asthisfaculty.MyClasses;

                        foreach (Course c in Courses)
                        {
                            if (c.Instructor == asthisfaculty.UserName)
                            {
                                facCourse.Add(c);
                            }
                        }
                        dataGridView2.DataSource = facCourse;
                        dataGridView2.Show();
                    }
                    break;
                case adminstate.crs:
                    {
                        newNames = new List<String>(); //This prevents a hilarious error. 
                        cadst = courseadminstate.name;
                        thisCourse = Courses[dataGridView1.SelectedRows[0].Index];
                        DetailBox.Text = "Course Name = " + thisCourse.CourseName + ".";
                        YesButton.Text = "Change?";
                        NoButton.Text = "Cancel Changes";
                        TrueNo.Show();
                        showDetail();
                    }
                    break;
                default: //MessageBox.Show("CASE 3");
                    break;
            }
        }

        private void ViewStudents(object sender, EventArgs e)
        {
            switch (state)
            {
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
            TrueNo.Hide();
        }

        private void FastRegButton_Click(object sender, EventArgs e)
        {
            if (state == adminstate.student)
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

            if (state == adminstate.crs)
            {
                hideDetail();
                dataGridView2.Hide();
                FastRegButton.Hide();
                ActualRegButton.Hide(); 
                coursebase();
            }
        }

        private void ActualRegButton_Click(object sender, EventArgs e)
        {
            if (state == adminstate.student)
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
            if (state == adminstate.crs)
            {
                newNames.Add(FacultyList[dataGridView2.SelectedRows[0].Index].UserName);
                cadst = courseadminstate.credits;
                this.Text = "Changing a course."; 
                DetailBox.Text = thisCourse.CourseName + "is worth " + thisCourse.credits + " credits.";
                showDetail();
                TrueNo.Show();
                dataGridView2.Hide();
                ActualRegButton.Hide();
                FastRegButton.Hide(); 
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

            if (state == adminstate.faculty) 
            {
                //FacultyList.RemoveAt(dataGridView1.SelectedRows[0].Index);
                //As above...
                hideDetail();

            };

            if (state == adminstate.crs)
            {
                switch (cadst)
                {
                    case courseadminstate.name:
                        {
                            hideDetail();
                            DetailBox2.Text = "Type new CourseName here.";
                            YesButton2.Text = "Change.";
                            DetailBox2.Show();
                            YesButton2.Show();
                            NoButton2.Show();
                        }
                        break;
                    case courseadminstate.title: 
                        {
                            hideDetail();
                            DetailBox2.Text = "Type new CourseTitle here.";
                            YesButton2.Text = "Change.";
                            DetailBox2.Show();
                            YesButton2.Show();
                            NoButton2.Show();                            
                        }    
                    break;
                    case courseadminstate.instructor: 
                        {
                            hideDetail();
                            dataGridView2.DataSource = FacultyList;
                            this.Text = "Setting a new instructor for " + thisCourse.CourseName;
                            dataGridView2.Show();
                            FastRegButton.Text = "Abort Changes";
                            ActualRegButton.Text = "Set Instructor";
                            FastRegButton.Show();
                            ActualRegButton.Show(); 
                        } 
                        break;
                    case courseadminstate.credits: 
                        {
                            hideDetail();
                            DetailBox2.Text = "Type new Credit value (i.e. 1.0) here.";
                            YesButton2.Text = "Change.";
                            DetailBox2.Show();
                            YesButton2.Show();
                            NoButton2.Show();   
                        } 
                    break;
                    case courseadminstate.time: {
                    MessageBox.Show("Editing Time is not currently supported. Press the No button to continue.");} break;
                
                    case courseadminstate.viewall:
                        MessageBox.Show("Deleting Courses is not currently supported."); 
                        break;
                }


            }
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            if (state == adminstate.student)
            {
                hideDetail();
                IVS();
            }

            if (state == adminstate.crs)
            {
                hideDetail();
                coursebase();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case adminstate.dflt:
                    {
                        state = adminstate.faculty;
                        dataGridView1.DataSource = FacultyList;
                        dataGridView1.Show();
                        this.Text = "Viewing Faculty List";
                        StudentButton.Enabled = false;
                        button4.Enabled = false;
                        killButton.Show();
                        button1.Show();
                    } break;
                case adminstate.faculty:
                    {
                        state = adminstate.dflt;
                        StudentButton.Enabled = true;
                        button4.Enabled = true;
                        hidethings();
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
                YesButton.Text = "Yes";
                NoButton.Text = "No";
                showDetail();
                DetailBox.Text = "Delete " + StudentList[studentindex].UserName + "?";
            }
            if (state == adminstate.faculty)
            {
                button1.Enabled = false;
                AdvisorButton.Enabled = false;
                asthisfaculty = FacultyList[dataGridView1.SelectedRows[0].Index];
                DetailBox.Text = "Delete " + asthisfaculty.UserName + "?";
                YesButton.Text = "Yes";
                NoButton.Text = "No"; 
                showDetail(); 
            
            }

            if (state == adminstate.crs)
            {
                button1.Enabled = false;
                AdvisorButton.Enabled = false;
                thisCourse = Courses[dataGridView1.SelectedRows[0].Index];
                DetailBox.Text = "Delete " + thisCourse.CourseTitle + "?";
                YesButton.Text = "Yes";
                NoButton.Text = "No";
                showDetail(); 
            }
        }

        private void coursebase()
        {
            cadst = courseadminstate.viewall;
            dataGridView1.DataSource = Courses;
            dataGridView1.Show();
            this.Text = "Viewing Course List";
            StudentButton.Enabled = false;
            button3.Enabled = false;
            killButton.Show();
            killButton.Enabled = true;
            button1.Enabled = true; 
            button1.Text = "Modify Course";
            button1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (state)
            {
                case adminstate.dflt:
                    {
                        state = adminstate.crs;
                        coursebase();
                    } break;
                case adminstate.crs:
                    {
                        state = adminstate.dflt;
                        StudentButton.Enabled = true;
                        button3.Enabled = true;
                        hidethings();
                    } break;
            }
        }

        private void TrueNo_Click(object sender, EventArgs e)
        {
            switch (cadst)
            {
                case courseadminstate.name:
                    {
                        cadst = courseadminstate.title;
                        DetailBox.Text = "The Course is titled " + thisCourse.CourseTitle + ".";
                        newNames.Add(thisCourse.CourseName);
                    }
                    break;
                case courseadminstate.title: 
                    {
                        cadst = courseadminstate.instructor;
                        DetailBox.Text = thisCourse.CourseName + "'s instructor is " + thisCourse.Instructor + ".";
                        newNames.Add(thisCourse.CourseTitle);
                    } 
                    break;
                case courseadminstate.instructor: 
                    {
                        cadst = courseadminstate.credits;
                        DetailBox.Text = thisCourse.CourseName + "is worth " + thisCourse.credits + " credits.";
                        newNames.Add(thisCourse.Instructor);
                    } 
                    break;
                case courseadminstate.credits: 
                    {
                        cadst = courseadminstate.time;
                        DetailBox.Text = thisCourse.CourseName + "meets " + thisCourse.Time;
                        newNames.Add(thisCourse.credits.ToString());  
                    }
                    break;
                case courseadminstate.time: 
                    {
                        double s = double.Parse(newNames[3]); 
                        thisCourse.AdministerCourse(newNames[0], newNames[1], newNames[2], s, admin);
                        
                        dataGridView1.Refresh(); 
                        hideDetail();
                        coursebase(); 
                    } 
                    break; 
                        
                    


            }
        }

        private void YesButton2_Click(object sender, EventArgs e)
        {
            switch (cadst)
            {
                case courseadminstate.name:
                    {
                        newNames.Add(DetailBox2.Text);
                        cadst = courseadminstate.title;
                        DetailBox.Text = "The Course is titled " + thisCourse.CourseTitle + ".";
                        showDetail();
                        TrueNo.Show();
                        YesButton2.Hide();
                        NoButton2.Hide();
                        DetailBox2.Hide();
                    }
                    break;

                case courseadminstate.title: 
                    {
                        newNames.Add(DetailBox2.Text);
                        cadst = courseadminstate.instructor;
                        DetailBox.Text = thisCourse.CourseName + "'s instructor is " + thisCourse.Instructor + ".";
                        showDetail();
                        TrueNo.Show();
                        YesButton2.Hide();
                        NoButton2.Hide();
                        DetailBox2.Hide();
                    } 
                    break;

                case courseadminstate.credits: 
                    {
                        newNames.Add(DetailBox2.Text);
                        cadst = courseadminstate.time; 
                        DetailBox.Text = thisCourse.CourseName + "meets " + thisCourse.Time; 
                        showDetail();
                        TrueNo.Show();
                        YesButton2.Hide();
                        NoButton2.Hide();
                        DetailBox2.Hide();
                    } break;
                case courseadminstate.time: { } break;
            }


        }

        private void NoButton2_Click(object sender, EventArgs e)
        {
            hideDetail();
            YesButton2.Hide();
            NoButton2.Hide();
            DetailBox2.Hide();
            coursebase();
        }
    }
}
