using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace StudentManagementForm.Models
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public BitmapImage Image { get; set; }

        public DateTime DateOfBirth { get; set; }
        public double GPA { get; set; }

        public string MobileNo { get; set; }

        public string Email { get; set; }
        public string RegistationNo { get; set; }



        public String ImagePath
        {
            get { return $"/Models/Images/{Image}"; }
        }

        public string Gender { get; internal set; }

        public Student(int age, string firstName, string lastName, DateTime dateOfBirth, BitmapImage image,
            string email, string mobileNo, string registationNo, double gpa, string gender)
        {
            Age = age;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Image = image;
            Email = email;
            MobileNo = mobileNo;
            RegistationNo = registationNo;
            GPA = gpa;
            Gender = gender;

        }

        public Student()
        {
        }
    }
}
