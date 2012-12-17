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
            studentsched
        }


        //int state = 0; //Will eventually replace this with a FacFormState, but other problems first. 
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
                        Sbutton.Text = "View the full Course Schedule"; 
                        MeSchedule(); 
                    break;

                case 2: FormState = FacFormState.myadvisees;
                        Text = Me.UserName + " is viewing his/her Advising screen.";
                        AButton.Text = "Back";
                        ADList();
                    break;

                default: FormState = FacFormState.allcourses;
                         Text = Me.UserName + " is viewing the Course List.";
                         AllSchedule();
                    break;
            }



        }
        
        public Form3(List<UserStudent> S, UserStudent s,  UserFaculty F, List<Course> C)
        {
            Me = F;
            Stud = S;
            Crs = C;
            little = s;

            InitializeComponent(); 

                //dataGridView1.Hide();

            foreach (Course C0 in Crs)
                if (little.MyCourses.Contains(C0.CourseName))
                    stdCourses.Add(C0);

            dataGridView1.DataSource = stdCourses;
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
                Form3 f = new Form3(Stud, MyStudents[dataGridView1.SelectedRows[0].Index],Me, Crs);
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

            if (FormState == FacFormState.studentsched)
            {
                Form3 dflt = new Form3(Stud, Me, Crs, 0);
                dflt.Show();
                this.Close();
            }
            if (FormState == FacFormState.myadvisees)
            {
                Form3 dflt = new Form3(Stud, Me, Crs, 0);
                dflt.Show();
                this.Close(); 
            
            }
        }

        private void LButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }


    }
}
