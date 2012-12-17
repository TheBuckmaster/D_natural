using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BensCRS
{
    public class UserFaculty
    {
        public String UserName = "";
        private string password = "";
        public String FirstName;
        public String LastName;
        public String MiddleName;

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
    }

    public class UserStudent
    {
        public String UserName = "";
        private string password = "";
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }
        public String Advisor;

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
        
        public string BaseClass { get { return coursename.Substring(0, coursename.Length - 3); } }
        public string Section { get { return coursename.Substring(coursename.Length - 2); } }


        public Course()
        {
            Meeting meeting1;
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

        public bool checkConflict(Course C)
        {
            foreach (Meeting meet in Meetings)
            {
                foreach (Meeting meet2 in C.Meetings)
                {
                    foreach (char day in meet.days)

                    {
                        if (meet2.days.Contains(day))
                        {
                            int start1 = int.Parse(meet.time.Substring(2, 2));
                            int end1 = start1 + int.Parse(meet.time.Substring(4));
                            int start2 = int.Parse(meet2.time.Substring(2, 2));
                            int end2 = start1 + int.Parse(meet2.time.Substring(4));
                            if (((start1 <= start2) && (end1 > start2)) || ((start2 <= start1) && (end2 > start1)))
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        private void makeMeetings(List<String> ddttks)
        {

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
