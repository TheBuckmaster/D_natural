using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BensCRS
{
    public partial class CourseParseForm : Form
    {
        List<UserAdmin> A = new List<UserAdmin>();
        List<UserFaculty> F = new List<UserFaculty>();
        List<UserStudent> S = new List<UserStudent>();
        List<Course> Courses = new List<Course>();

        private StreamReader filereader;
        //DialogResult result;
        //private string filename;
        //FileStream input;
        private string line;


        public CourseParseForm(List<Course> C, List<UserAdmin> ad, List<UserFaculty> fac, List<UserStudent> std)
        {
            InitializeComponent();
            Courses = C;
            A = ad;
            F = fac;
            S = std;
            UserAdmin a = new UserAdmin("Automated","*****","B","P","B");
            try
            {
                filereader = new StreamReader("ClassInput.txt");

                line = filereader.ReadLine();
                while (line != null)
                {
                    List<String> timeblocks = new List<string>();
                    cName.Text = line.Substring(0, 11).Trim();
                    cTitle.Text = line.Substring(11, 16).Trim();
                    cInst.Text = line.Substring(27, 11).Trim();
                    cCred.Text = line.Substring(38, 5).Trim();
                    cSeat.Text = line.Substring(43, 4).Trim();
                    cNumTimes.Text = line.Substring(47, 2).Trim();
                    string timeline = line.Substring(49).Trim();
                    int numTimes = Convert.ToInt16(cNumTimes.Text);

                    for (int i = 0; i < numTimes; i++)
                    {
                        int begin = (0 + (i * 6)); //changed
                                        // Needed to add one for the space
                        timeblocks.Add(timeline.Substring(begin, 5));
                        //MessageBox.Show(cName.Text + " " + timeblocks[i]); 
                    }
                     
 
                    Course myCourse = new Course(cName.Text, cTitle.Text, cInst.Text,
                        Convert.ToDouble(cCred.Text), Convert.ToInt16(cSeat.Text), timeblocks);
                    Courses.Add(myCourse);

                    //MessageBox.Show("There are " + Courses.Count + " Courses.");



                    line = filereader.ReadLine();
                }
                filereader.Close();
                //MessageBox.Show("File is now complete.");

            }
            catch
            {
                //MessageBox.Show("There was an Error");
            }

            try
            {
                filereader = new StreamReader("HistoryInput.txt");
                line = filereader.ReadLine();
                int times;
                string name;
                string title;
                string term;
                double credit;
                string grade;

                while (line != null)
                {
                    bool studentfound = false; 
                    name = line.Substring(0, 11).Trim();

                    UserStudent stud = new UserStudent();
                    foreach(UserStudent st in S)
                    {
                        if (name == st.UserName)
                        {
                            stud = st;
                            studentfound = true; 
                            break;
                        }
                    }
                    if (!studentfound)
                    {
                        line = filereader.ReadLine();
                        continue; 
                    }

                    times = int.Parse(line.Substring(11, 2).Trim());
                    int x = 13;
                    for (int i = 0; i < times; i++)
                    {
                        title = line.Substring(x, 11).Trim();
                        x += 11;
                        term = line.Substring(x, 4).Trim();
                        x += 4;
                        credit = double.Parse(line.Substring(x, 5));
                        x += 5;
                        grade = line.Substring(x, 4).Trim();
                        x += 4;

   //                     <user-name:10>S<num-courses:2>S
   // <course-name-1:10>S<term-1:3>S<course-credit-1:4>S<grade-1:3>…
   //S<course-name-N:10>S<term-N:3>S<course-credit-N:4>S<grade-N:3>

                        if (term == "S13")
                        {
                            foreach (Course Cn in Courses)
                            {
                                if (Cn.CourseName == title)
                                {
                                    benutil.AddStudenttoCourse(stud, Cn, a);
                                }
                            }
                        
                        }
                        else
                        {
                            PastCourse pst = new PastCourse(term, title, grade, credit);
                            stud.MyPastCourses.Add(pst);
                        }
                    }
                    line = filereader.ReadLine();
                }
                //MessageBox.Show("Complete");
            }
            catch (EndOfStreamException)
            { }


            try
            {

            }
            catch (EndOfStreamException)
            { }
            
            LoginForm lgn = new LoginForm(A, F, S, C);
            if (lgn.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new LoginForm(A, F, S, C));
                
            }
                this.Close();
        }

    }
}
