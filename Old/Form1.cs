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
    public partial class LoginForm : Form
    {
        List<UserAdmin> Admins;
        List<UserFaculty> Faculty;
        List<UserStudent> Students;
        List<Course> Courses;

        public LoginForm(List<UserAdmin> A, List<UserFaculty> F, List<UserStudent> S, List<Course> C)
        {
            Admins = A;
            Faculty = F;
            Students = S;
            Courses = new List<Course>(C);
            InitializeComponent();
            textBox2.PasswordChar = '•';
            Text = "Welcome";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            bool success = false;
            foreach (UserAdmin a in Admins)
                if (textBox1.Text == a.UserName)
                { 
                    if (a.isPassword(textBox2.Text))
                    {

                        //launch admin form
                        //but for now:

                        Text = "Welcome " + a.UserName + ". " ;

                        AdminForm adm = new AdminForm(Faculty, Students, Courses, a);
                        adm.Show();

                        textBox1.Text = textBox2.Text = "";
                        //end form.
                    } 

                    else 
                    {
                        textBox2.Text = "";
                        label3.Show();
                        success = true;
                    } //tell user login failed.
                }

            foreach (UserFaculty f in Faculty)
                if (textBox1.Text == f.UserName)
                {
                    if (f.isPassword(textBox2.Text))
                    {

                        //launch faculty form
                        Text = "Welcome " + f.UserName + ". ";

                        Form3 formm = new Form3(Students,f,Courses,0);
                        formm.Show();
                        //this.Close();
                        textBox1.Text = textBox2.Text = "";

                        success = true;
                    }

                    else
                    {
                        textBox2.Text = "";
                        label3.Show();
                    } //tell user login failed.
                }

            foreach (UserStudent s in Students)
                if (textBox1.Text == s.UserName)
                {
                    if (s.isPassword(textBox2.Text))
                    {

                        //launch student form
                        Text = "Welcome " + s.UserName + ". ";
                        Form2 SF = new Form2(Courses, s, 0);
                        SF.Show();
                        textBox1.Text = textBox2.Text = "";
                        //this.Close(); 
                        success = true;
                    }

                    else
                    {
                        textBox2.Text = "";
                        label3.Show();
                    } //tell user login failed.
                }
            if (!success)
            {
                textBox2.Text = "";
                label3.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}
