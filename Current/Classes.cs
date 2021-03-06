﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BensCRS
{
    public class UserFaculty
    {
        public String UserName = "";
        private string password = "";
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }

        public List<String> MyClasses = new List<String>();  //CourseNames of my classes

        public UserFaculty(String UN, String PW, String FN, String MN, String LN)
        {
            UserName = UN;
            password = PW;
            FirstName = FN;
            MiddleName = MN;
            LastName = LN; 
        }

        public UserFaculty(UserFaculty F)
        {
            UserName = F.UserName;
            password = F.password;         
        }

        public bool isPassword(String maybePWD)
        {
            return (maybePWD == password);
        }

        public void classesFinder(List<Course> crs)
        {
            foreach (Course c in crs)
            {
                if (c.Instructor == UserName)
                    MyClasses.Add(c.CourseName);
            }
        }

        public List<String> futStudentFinder(List<Course> crs)
        {
            List<String> Students = new List<String>();
            List<String> someStudents = new List<String>();
            classesFinder(crs);
            foreach (Course C in crs)
            {
                if (MyClasses.Contains(C.CourseName))
                {
                    someStudents = C.GetStudentUNs();
                    foreach (String name in someStudents)
                    {
                        if(!Students.Contains(name))
                        {
                            Students.Add(name);
                        }
                    }
                }
            }
            return Students;
        }
    }

    public class UserStudent
    {
        public struct conflictpair
        {
            public string firstclass;
            public string secondclass;
        };


        public String UserName = "";
        private string password = "";
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
        public String Advisor;
        public bool hasConflicts { get { return !(coursesthatConflict.Count == 0); } }
        public List<conflictpair> coursesthatConflict = new List<conflictpair>(); 

        public List<String> MyCourses = new List<String>();
        public List<PastCourse> MyPastCourses = new List<PastCourse>(); 

        public UserStudent(String UN, String PW, String FN, String MN, String LN, String ADV)
        {
            UserName = UN;
            password = PW;
            FirstName = FN;
            MiddleName = MN;
            LastName = LN;
            Advisor = ADV; 
        }

        public UserStudent()
        { }

        public UserStudent(UserStudent A)
        {
            UserName = A.UserName;
            password = A.password; 
        }

        public bool isPassword(String maybePWD)
        {
            return (maybePWD == password);
        }

        public double EarnedCredits()
        {
            double credits = 0.00;

            foreach (PastCourse course in MyPastCourses)
            {
                if (course.Earned)
                {
                    bool retaken = false;
                    foreach (PastCourse course2 in MyPastCourses)
                    {
                        if ((course != course2) && (course.BaseClass == course2.BaseClass))
                        {
                            if ((course.Year == course2.Year && course.Semester != 'F')
                                || (course.Year < course2.Year))
                                retaken = true;
                        }
                    }

                    if(!retaken)
                        credits += course.Credit;
                }
            }

            return credits;
        }

        public double GPA()
        {
            double total = 0.000;
            double creds = 0.000;

            foreach (PastCourse course in MyPastCourses)
            {
                // if a gpa factor
                if (course.GPAble)
                {
                    // check if later retaken
                    bool retaken = false;
                    foreach (PastCourse course2 in MyPastCourses)
                    {
                        if ((course != course2) && (course.BaseClass == course2.BaseClass))
                        {
                            if ((course.Year == course2.Year && course.Semester != 'F')
                                || (course.Year < course2.Year))
                                retaken = true;
                        }
                    }

                    // skip retaken classes
                    if (!retaken)
                    {
                        total += course.GPoints;
                        creds += course.Credit;
                    }
                }
            }

            return total / creds;
        }

        /// <summary>
        /// Sends a MessageBox for any conflicts the student's schedule has. 
        /// </summary>
        public void ShowConflicts()
        {
            StringBuilder s1 = new StringBuilder();

            foreach (UserStudent.conflictpair pair in coursesthatConflict)
            {
                s1.Append(pair.firstclass + " conflicts with " + pair.secondclass + ".");
            }
            
            MessageBox.Show(s1.ToString());
        }
    
    }

    public class UserAdmin
    {
        public String UserName = "";
        private string password = "";
        public String FirstName;
        public String LastName;
        public String MiddleName; 

        public UserAdmin(String UN, String PW, String FN, String MN, String LN)
        {
            UserName = UN;
            password = PW;
            FirstName = FN;
            MiddleName = MN;
            LastName = LN; 
        }

        public bool isPassword(String maybePWD)
        {
            return (maybePWD == password);
        }
    }

    public class Course
    {
        private struct Meeting
        {
            public String ddttk; // Source string. 
            public List<Char> days; //dd, translated
            public String time; //ttk, translated
        }
        private string coursename; 
        public String CourseTitle { get; set; }
        public String CourseName { get {return coursename;} }
        public String Instructor { get; set; }
        public double credits { get; set; } 
        private List<Meeting> Meetings = new List<Meeting>();
        private int seats;
        public int Seats { get { return seats; } }
        private List<String> studentNames = new List<String>();
        public int Students { get { return studentNames.Count; } }
        public string Enrollment { get { return Students + " / " + Seats; } }
        
        //public string BaseClass { get { return coursename.Substring(0, coursename.Length - 3); } }
        //public string Section { get { return coursename.Substring(coursename.Length - 2); } }

        public String Time { get; set; }   
        

        public Course()
        {
            Meeting meeting1;
            meeting1.ddttk = "21201";
            meeting1.days = new List<char>();
            meeting1.days.Add('M');
            meeting1.days.Add('W');
            meeting1.days.Add('F');
            meeting1.time = "201";
            Meetings.Add(meeting1);

            CourseTitle = "Special Topics";
            coursename = "MTH-000-00";
            Instructor = "Staff";
            credits = 1.0;
            seats = 20; 

            studentNames.Add("JWhite");
            studentNames.Add("CVanNiewaal");
            studentNames.Add("DCurtis"); 

        
        }

        public Course(String cName, String cTitle, String cInst, Double cCred,
            int cSeat, List<String> timeblocks)
        {
            coursename = cName;
            CourseTitle = cTitle;
            Instructor = cInst;
            credits = cCred;
            seats = cSeat;
            makeMeetings(timeblocks);
            Time = showMeetings();
            //MessageBox.Show(showMeetings().ToString()); 
        
        }

        public bool AddStudent(UserStudent S)
        {
            if (Students > Seats)
                return false; 
            if (studentNames.Contains(S.UserName))
                return false;
            if (S.MyCourses.Contains(CourseName))
                return false;

            studentNames.Add(S.UserName);
            return true;         
        }

        public bool AddStudent(UserStudent S, UserAdmin A)
        {
            if (!studentNames.Contains(S.UserName))
                studentNames.Add(S.UserName);
            if (!S.MyCourses.Contains(coursename))
                S.MyCourses.Add(coursename);
            return true;
        }

        public void RemoveStudent(UserStudent S)
        {
            if (studentNames.Contains(S.UserName))
                studentNames.Remove(S.UserName);
        }

        public List<String> GetStudentUNs()
        {
            return studentNames; 
        }


        /// <summary>
        /// Returns true if there exists a conflict between the two courses and false otherwise.
        /// </summary>
        /// <param name="C">The course to compare meetings to.</param>
        /// <returns></returns>
        public bool checkConflict(Course C)
        {
            foreach (Meeting Mn in Meetings)
            {
                foreach (Char dayn in Mn.days)
                {
                    foreach (Meeting Mx in C.Meetings)
                    {
                        foreach (Char dayx in Mx.days)
                        {
                            if (dayx == dayn)
                            {
                                int t1 = int.Parse(Mn.ddttk.Substring(2));
                                int t2 = int.Parse(Mx.ddttk.Substring(2));
                                if (t1 == t2) //Does this course meet at exactly the same time
                                //on this day? If so: conflict. 
                                {
                                    return true;
                                }

                                int tt1a = (t1 / 10);
                                int tt1b = (t1 / 10) + t1 % 10;
                                int tt2 = (t2 / 10);
                                if ((tt2 > tt1a) && (tt2 < tt1b))
                                {
                                    //Does C start inside Course's time on this day? If so: conflict.
                                    return true;
                                }

                                int tt2a = tt2;
                                int tt2b = tt2 + t2 % 10;
                                int tt1 = tt1a;
                                if ((tt1 > tt2a) && (tt1 < tt2b))
                                    //Does This course start inside C's time on this day? If so: conflict. 
                                {
                                    return true;
                                }
                                
                            }
                        }
                    }
                }
            }


            return false; 
        }

        /// <summary>
        /// Converts the ddttks strings into the appropriate number of correct meetings.
        /// </summary>
        /// <param name="ddttks"></param>
        private void makeMeetings(List<String> ddttks)
        {
            for (int i = 0; i < ddttks.Count; i++)
            {
                
                Meeting nth;
                nth.ddttk = ddttks[i]; 
                string dd = ddttks[i].Substring(0, 2);
                string tt = ddttks[i].Substring(2, 2);
                string k = ddttks[i].Substring(4, 1);

                int daysint = int.Parse(dd);
                int timeint = int.Parse(tt);
                double timedouble = timeint;
                string hourstring;
                string minutestring;
                string postfix;
                int halfhours = int.Parse(k);


                // turn daysint into adds to Meeting.days
                nth.days = benutil.MeetingDaysBySwitch(daysint);

                //MessageBox.Show(timedouble.ToString()); 
                // generate hours and minutes for start time
                timedouble = timedouble / 2.0;
                if (timedouble % 1.0 == 0.0)
                    //On the hour start. 
                    minutestring = "00"; 
                else
                {
                    timedouble = timedouble - .5;
                    minutestring = "30";
                }

                // generate postfix for start time
                if (timedouble < 12.0)
                {
                    postfix = "AM";
                    if (timedouble == 0.0)
                        timedouble += 12.0; 
                }
                else
                {
                    postfix = "PM";
                    if (timedouble != 12.0)
                        timedouble -= 12.0;
                }

                hourstring = timedouble.ToString();

                // note start time
                nth.time = hourstring + ":" + minutestring + " " + postfix;

                //MessageBox.Show(this.CourseName + " " + nth.time); 

                // generate hours and minutes for end time
                timedouble = timeint + halfhours;
                timedouble = timedouble / 2.0;
                if (timedouble % 1.0 == 0.0)
                    // on the hour end.
                    minutestring = "00";
                else
                {
                    timedouble = timedouble - .5; 
                    minutestring = "30";
                }
                
                if (timedouble < 12.0)
                {
                    postfix = "AM";
                    if (timedouble == 0.0)
                        timedouble += 12.0;
                }
                else
                {
                    postfix = "PM";
                    if (timedouble != 12.0)
                        timedouble -= 12.0; 
                }
                hourstring = timedouble.ToString();


                // note end time
                nth.time += " - " + hourstring + ":" + minutestring + " " + postfix;

                //StringBuilder s = new StringBuilder();
                //foreach (Char C in nth.days)
                //    s.Append(C);
                //MessageBox.Show(this.CourseName + " " + s.ToString() + " " + nth.time);
                Meetings.Add(nth); 
            }
        }

        private String showMeetings() 
        {
            StringBuilder output = new StringBuilder();

            foreach (Meeting M in Meetings)
            {
                String A = "";
                foreach (Char c in M.days)
                    A += c;
                A += " ";
                A += M.time;
                //MessageBox.Show(A); 
                output.Append(A);
                output.Append("\n"); 
            
            }
            //MessageBox.Show(output.ToString()); 
            return output.ToString(); 
        }

        /// <summary>
        /// This is a superpowered administrator function. 
        /// Use with caution. 
        /// </summary>
        /// <param name="newCourseName"></param>
        /// <param name="newCourseTitle"></param>
        /// <param name="newInstructor"></param>
        /// <param name="newCredits"></param>
        /// <param name="newTimeBlocks"></param>
        /// <param name="Admin">The responsible administrator.</param>
        public void AdministerCourse(String newCourseName, String newCourseTitle, 
            String newInstructor, Double newCredits, //List<String> newTimeBlocks, 
            UserAdmin Admin)
        {
            coursename = newCourseName;
            CourseTitle = newCourseTitle;
            Instructor = newInstructor;
            credits = newCredits;
            //List<String> timeblocks = newTimeBlocks;
            //makeMeetings(timeblocks);
            Time = showMeetings();
        }

    }

    public class PastCourse
    {
        public String Term { get; set; }
        private string coursename;
        public String CourseName { get { return coursename; } }
        public String Grade { get; set; }
        public double Credit { get; set; }

        public char Semester { get { return Term[0]; } }
        public int Year { get { return int.Parse(Term.Substring(1)); } }
        public string BaseClass { get { return coursename.Substring(0, coursename.Length - 3); } }
        public string Section { get { return coursename.Substring(coursename.Length - 2); } }
        public double GPoints;
        public bool Earned;
        public bool GPAble;

        public PastCourse(String term, String name, String grade, double credit)
        {
            Term = term;
            coursename = name;
            Grade = grade;
            Credit = credit;

            if (Grade.Contains("F"))
            {
                Earned = false;
                GPAble = true;
                GPoints = 0.0;
            }
            else if (Grade.Contains("N") || Grade.Contains("W") || Grade.Contains("U") || Grade.Contains("X") || Grade.Contains("I") || Grade.Contains("O") || Grade.Contains("EQ"))
            {
                Earned = false;
                GPAble = false;
                GPoints = 0.0;
            }
            else if (Grade.Contains("S"))
            {
                Earned = true;
                GPAble = false;
                GPoints = 0.0;
            }
            else
            {
                Earned = true;
                GPAble = true;

                if (Grade.Contains("A-"))
                    GPoints = Credit * 3.7;
                else if (Grade.Contains("A"))
                    GPoints = Credit * 4.0;

                else if (Grade.Contains("B+"))
                    GPoints = Credit * 3.3;
                else if (Grade.Contains("B-"))
                    GPoints = Credit * 2.7;
                else if (Grade.Contains("B"))
                    GPoints = Credit * 3.0;

                else if (Grade.Contains("C+"))
                    GPoints = Credit * 2.3;
                else if (Grade.Contains("C-"))
                    GPoints = Credit * 1.7;
                else if (Grade.Contains("C"))
                    GPoints = Credit * 2.0;

                else if (Grade.Contains("D+"))
                    GPoints = Credit * 1.3;
                else if (Grade.Contains("D-"))
                    GPoints = Credit * 0.7;
                else if (Grade.Contains("D"))
                    GPoints = Credit * 1.0;
            }
        }
    }

}
