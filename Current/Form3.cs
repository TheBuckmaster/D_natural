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
    public partial class Form3 : Form
    {
        enum FacFormState
        { 
            allcourses,
            mycourses,
            myadvisees,
            studentsched,
            myfutstudents,
            studentcurrent
        }


        FacFormState FormState; 
        UserFaculty Me;
        List<UserStudent> MyStudents = new List<UserStudent>();
        List<Course> stdCourses = new List<Course>(); 
        List<UserStudent> Stud;
        UserStudent little;
        List<Course> Crs = new List<Course>();

        public Form3(List<UserStudent> S, UserFaculty F, List<Course> C)
            :this(S,F,C,0)
        { 
        }

        public Form3(List<UserStudent> S, UserFaculty F, List<Course> C ,int number)
        {
            InitializeComponent();
            Me = F;
            Stud = S;
            Crs = C; 
            
            switch (number)
            {
                case 1: FormState = FacFormState.mycourses;
                        Text = Me.UserName + " is viewing his/her courses taught.";
                        AButton.Text = "View future Students";
                        Sbutton.Text = "View the full Course Schedule";
                        RareButton.Hide();
                        MeSchedule(); 
                    break;

                case 2: FormState = FacFormState.myadvisees;
                        Text = Me.UserName + " is viewing his/her Advising screen.";
                        AButton.Text = "Back";
                        RareButton.Text = "View Cur. Grades"; 
                        ADList();
                    break;

                case 4: FormState = FacFormState.myfutstudents;
                        Text = Me.UserName + " is viewing his/her Future students.";
                        AButton.Text = "Back";
                        Sbutton.Hide();
                        RareButton.Hide();
                        FutStdList();
                    break;

                default: FormState = FacFormState.allcourses;
                         Text = Me.UserName + " is viewing the Course List.";
                         RareButton.Hide();
                         AllSchedule();

                    break;
            }



        }
        
        public Form3(List<UserStudent> S, UserStudent s,  UserFaculty F, List<Course> C, int i)
        {
            Me = F;
            Stud = S;
            Crs = C;
            little = s;


            if (i == 0)
                FormState = FacFormState.studentsched;
            if (i == 1)
                FormState = FacFormState.studentcurrent;

            InitializeComponent();
            RareButton.Hide();
            Sbutton.Hide();

                //dataGridView1.Hide();
            if (FormState == FacFormState.studentsched)
            {
                foreach (Course C0 in Crs)
                    if (little.MyCourses.Contains(C0.CourseName))
                        stdCourses.Add(C0);
                AButton.Text = "Back";
                dataGridView1.DataSource = stdCourses;
            }
            if (FormState == FacFormState.studentcurrent)
            {
                List<PastCourse> relevant = new List<PastCourse>();
                foreach (PastCourse P in little.MyPastCourses)
                {
                    if (P.Term == "F12")
                    {
                        relevant.Add(P);
                    }                 
                }

                dataGridView1.DataSource = relevant;     
            
            }


            //dataGridView1.Refresh();
            //dataGridView1.Show(); 

        }

        

        private void AllSchedule()
        {
            dataGridView1.DataSource = Crs; 
        }


        private void MeSchedule()
        {
            List<Course> myCourses = new List<Course>();
            Me.classesFinder(Crs);
            foreach (Course C1 in Crs)
                if (Me.MyClasses.Contains(C1.CourseName))
                    myCourses.Add(C1);

            dataGridView1.DataSource = myCourses; 
        }

        private void ADList() 
        {

            foreach (UserStudent st in Stud)
                if (st.Advisor == Me.UserName)
                    MyStudents.Add(st);

            dataGridView1.DataSource = MyStudents; 
        
        }

        private void FutStdList()
        {
            List<String> UNs = Me.futStudentFinder(Crs);

            foreach (UserStudent student in Stud)
            { 
                foreach (String fsun in UNs)
                {
                    if (student.UserName == fsun)
                        MyStudents.Add(student);
                }
            }

            dataGridView1.DataSource = MyStudents;
        }


        private void Sbutton_Click(object sender, EventArgs e)
        {
            if (FormState == FacFormState.allcourses)
            {
                Form3 f = new Form3(Stud, Me, Crs, 1);
                f.Show();
                this.Close();
            }
            if (FormState == FacFormState.mycourses)
            {
                Form3 f = new Form3(Stud, Me, Crs, 0);
                f.Show();
                this.Close(); 
            }
            if (FormState == FacFormState.myadvisees)
            {
                Form3 f = new Form3(Stud, MyStudents[dataGridView1.SelectedRows[0].Index],Me, Crs,0);
                f.Show();
                this.Close();
            }

        }

        private void AButton_Click(object sender, EventArgs e)
        {
            if (FormState == FacFormState.allcourses)
            {
                Form3 advf = new Form3(Stud, Me, Crs, 2);
                advf.Show();
                this.Close(); 
            }

            if ((FormState == FacFormState.studentsched) || (FormState == FacFormState.studentcurrent))
            {
                Form3 dflt = new Form3(Stud, Me, Crs, 2);
                dflt.Show();
                this.Close();
            }
            if (FormState == FacFormState.myadvisees)
            {
                Form3 dflt = new Form3(Stud, Me, Crs, 0);
                dflt.Show();
                this.Close();
            }

            if (FormState == FacFormState.myfutstudents)
            {
                Form3 f = new Form3(Stud, Me, Crs, 1);
                f.Show();
                this.Close();
            }

            if (FormState == FacFormState.mycourses)
            {
                Form3 futstd = new Form3(Stud, Me, Crs, 4);
                futstd.Show();
                this.Close(); 
            }
        }

        private void LButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void RareButton_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3(Stud, MyStudents[dataGridView1.SelectedRows[0].Index],
                Me, Crs, 1);
            f.Show();
            this.Close(); 
        }


    }
}
