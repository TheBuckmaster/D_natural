using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace BensCRS
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StreamReader filereader;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //UserAdmin u1 = new UserAdmin();
            //UserFaculty u2 = new UserFaculty();
            //UserStudent u3 = new UserStudent();

            List<UserAdmin> ads = new List<UserAdmin>();
            //ads.Add(u1);
            List<UserFaculty> fcs = new List<UserFaculty>();
            //fcs.Add(u2);
            List<UserStudent> std = new List<UserStudent>();
            //std.Add(u3);
            List<String> timeblocks = new List<string>();
            List<Course> Courses = new List<Course>();
            List<PastCourse> past = new List<PastCourse>();
            
            //crs.Add(new Course()); 

            try
            {
                filereader = new StreamReader("UserInput.txt");
                string line = "Yes";
                string username;
                string password;
                string firstn;
                string middlen;
                string lastn;
                string status;

                while (line != null)
                {
                    line = filereader.ReadLine();
                    if (line != null)
                    {
                        username = line.Substring(0, 10).Trim();
                        password = line.Substring(10, 10).Trim();
                        firstn = line.Substring(20, 15).Trim();
                        middlen = line.Substring(35, 15).Trim();
                        lastn = line.Substring(50, 15).Trim();
                        status = line.Substring(65).Trim();

                        if (status.Contains("admin"))
                        {
                            UserAdmin A = new UserAdmin(username, password, firstn, middlen, lastn);
                            ads.Add(A);
                        }
                        else if (status.Contains("faculty"))
                        {
                            UserFaculty F = new UserFaculty(username, password, firstn, middlen, lastn);
                            fcs.Add(F);
                        }
                        else
                        {
                            UserStudent S = new UserStudent(username, password, firstn, middlen, lastn, status);
                            std.Add(S);
                        }
                    }
                    else
                    {
                        filereader.Close();
                        //button1.Visible = false;
                        //MessageBox.Show("File");
                    }

                }
            }
            catch (EndOfStreamException)
            { }



            //try
            //{
            //    StreamReader freader;
            //    freader = new StreamReader("ClassInput.txt");
            //    string line = "Yes";
            //    string cName;
            //    string itle;
            //    string cInst;
            //    string cSeat;
            //    string cCred;
            //    string cNumTimes;
            //    line = freader.ReadLine();

            //    while (line != null)
            //    {
            //        if (line != null)
            //        {
            //            cName = line.Substring(0, 11).Trim();
            //            itle = line.Substring(11, 16).Trim();
            //            cInst = line.Substring(27, 11).Trim();
            //            cCred = line.Substring(38, 5).Trim();
            //            cSeat = line.Substring(43, 4).Trim();
            //            cNumTimes = line.Substring(47, 2).Trim();
            //            string timeline = line.Substring(49).Trim();
            //            int numTimes = Convert.ToInt16(cNumTimes);

            //            for (int i = 0; i < numTimes; i++)
            //            {
            //                int begin = (0 + (i * 5));
            //                timeblocks.Add(timeline.Substring(begin, 5));
            //            }

            //            Course myCourse = new Course(cName, itle, cInst,
            //                Convert.ToDouble(cCred), Convert.ToInt16(cSeat), timeblocks);
            //            Courses.Add(myCourse);

            //            //MessageBox.Show("There are " + Courses.Count + " Courses.");

            //        }

            //        line = freader.ReadLine();
            //    }
            //    freader.Close();
            //    MessageBox.Show("File is now complete.");

            //}
            //catch
            //{
            //    MessageBox.Show("There was an Error");
            //}

            //Application.Run(new Form4(ads, std,fcs));
            Application.Run(new CourseParseForm(Courses, ads, fcs, std));
            //Application.Run(new Sloppyform(ads, std, fcs)); 
            //Application.Run(new LoginForm(ads,fcs,std,crs));
        }

    }

    static class benutil
    {
        public static void AddStudenttoCourse(UserStudent S, Course C)
        {
            if (C.AddStudent(S))
            {
                S.MyCourses.Add(C.CourseName);
                MessageBox.Show("You've successfully registered for " + C.CourseName + " ."); 
            }
            else
            {
                if (C.Students >= C.Seats)
                    MessageBox.Show("Class is Full!");
                if (S.MyCourses.Contains(C.CourseName))
                    MessageBox.Show("You've Already Registered for this Course!");
            }
        }

        public static void AddStudenttoCourse(UserStudent S, Course C, UserAdmin Me)
        {
            C.AddStudent(S, Me); 
        }

        public static void RemoveStudentfromCourse(UserStudent S, Course C)
        {
            MessageBox.Show("Removing " + S.UserName + " from " + C.CourseName + " ."); 
            C.RemoveStudent(S);
            S.MyCourses.Remove(C.CourseName);
            MessageBox.Show("You are no longer registered for " + C.CourseName + " ."); 
        
        }

        public static List<Char> MeetingDaysBySwitch(int dd)
        {
            List<Char> theList = new List<Char>();

            switch (dd)
            {
                case 1: theList.Add('M');
                        break;
                
                case 2: theList.Add('T');
                        break;
                
                case 3: theList.Add('M');
                        theList.Add('T'); 
                        break;
                
                case 4: theList.Add('W'); 
                        break;
                
                case 5: theList.Add('M');
                        theList.Add('W');
                        break;
                
                case 6: theList.Add('T');
                        theList.Add('W'); 
                        break;
                
                case 7: theList.Add('M');
                        theList.Add('T');
                        theList.Add('W');
                        break;
                
                case 8: theList.Add('H');
                        break;
                
                case 9: theList.Add('M');
                        theList.Add('H');
                        break;
                
                case 10: theList.Add('T');
                        theList.Add('H');
                        break;
                
                case 11: theList.Add('M');
                        theList.Add('T');
                        theList.Add('H');
                        break;
                
                case 12: theList.Add('W');
                        theList.Add('H');
                        break;
                
                case 13: theList.Add('M');
                        theList.Add('W');
                        theList.Add('H');
                        break;
                
                case 14: theList.Add('T');
                        theList.Add('W');
                        theList.Add('H');
                        break;
                
                case 15: theList.Add('M');
                        theList.Add('T');
                        theList.Add('W');
                        theList.Add('H');
                        break;
                
                case 16: theList.Add('F');
                        break;
                
                case 17: theList.Add('M');
                        theList.Add('F');
                        break;
                
                case 18: theList.Add('T');
                        theList.Add('F');
                        break;
                
                case 19: theList.Add('M'); 
                        theList.Add('T');
                        theList.Add('F');
                        break;
                
                case 20: theList.Add('W');
                        theList.Add('F');
                        break;
                
                case 21: theList.Add('M');
                        theList.Add('W');
                        theList.Add('F');
                        break;
                
                case 22: theList.Add('T');
                        theList.Add('W');
                        theList.Add('F');
                        break;
                
                case 23: theList.Add('M');
                        theList.Add('T');
                        theList.Add('W');
                        theList.Add('F');
                        break;
                
                case 24: theList.Add('H');
                        theList.Add('F');
                        break;
                
                case 25: theList.Add('M'); 
                        theList.Add('H');
                        theList.Add('F');
                        break;
                
                case 26: theList.Add('T');
                        theList.Add('H');
                        theList.Add('F');
                        break;
                
                case 27: theList.Add('M');
                        theList.Add('T');
                        theList.Add('H');
                        theList.Add('F');
                        break;
                
                case 28: theList.Add('W');
                        theList.Add('H');
                        theList.Add('F');
                        break;
                
                case 29: theList.Add('M');
                        theList.Add('W');
                        theList.Add('H');
                        theList.Add('F');
                        break;
                
                case 30: theList.Add('T'); 
                        theList.Add('W');
                        theList.Add('H');
                        theList.Add('F'); 
                        break;
                
                case 31: theList.Add('M');
                        theList.Add('T'); 
                        theList.Add('W');
                        theList.Add('H');
                        theList.Add('F'); 
                        break;

                default: break; 
            }
            return theList; 
        
        }
    }

}
