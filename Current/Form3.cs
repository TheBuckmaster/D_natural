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
        int state = 0;
        UserFaculty Me;
        List<UserStudent> MyStudents = new List<UserStudent>();
        List<Course> stdCourses = new List<Course>(); 
        List<UserStudent> Stud;
        UserStudent little;
        List<Course> Crs = new List<Course>(); 

        public Form3(List<UserStudent> S, UserFaculty F, List<Course> C ,int number)
        {
            Me = F;
            Stud = S;
            Crs = C; 
            state = number;

            InitializeComponent();

            if (state == 0)
            {
                Text = Me.UserName + " is viewing the Course List."; 
                AllSchedule(); 
            }
            if (state == 1)
            {
                Text = Me.UserName + " is viewing his/her courses taught.";
                Sbutton.Text = "View the full Course Schedule"; 
                MeSchedule(); 
            }

            if (state == 2)
            {
                Text = Me.UserName + " is viewing his/her Advising screen.";
                ADList();
            }

        }
        
        public Form3(List<UserStudent> S, UserStudent s,  UserFaculty F, List<Course> C, int number)
        {
            Me = F;
            Stud = S;
            Crs = C;
            state = number;
            little = s;

            if (state == 3)
            {
                //dataGridView1.Hide();

                foreach (Course C0 in Crs)
                    if (little.MyCourses.Contains(C0.CourseName))
                        stdCourses.Add(C0);

                dataGridView1.DataSource = stdCourses;
                //dataGridView1.Refresh();
                //dataGridView1.Show(); 
            
            }
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
            if (state == 0)
            {
                Form3 f = new Form3(Stud, Me, Crs, 1);
                f.Show();
                this.Close();
            }
            if (state == 1)
            {
                Form3 f = new Form3(Stud, Me, Crs, 0);
                f.Show();
                this.Close(); 
            }
            if (state == 2)
            {
                Form3 f = new Form3(Stud, MyStudents[dataGridView1.SelectedRows[0].Index],Me, Crs,3);
                f.Show();
                this.Close();
            }
        }

        private void AButton_Click(object sender, EventArgs e)
        {
            if (state == 0)
            {
                Form3 advf = new Form3(Stud, Me, Crs, 2);
                advf.Show();
                this.Close(); 
            }

            if (state == 3)
            {
                Form3 dflt = new Form3(Stud, Me, Crs, 0);
                dflt.Show();
                this.Close();
            }
            if (state == 2)
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
