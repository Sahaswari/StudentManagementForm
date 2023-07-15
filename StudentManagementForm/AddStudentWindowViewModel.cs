using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagementForm.Models;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace StudentManagementForm
{
    public partial class AddStudentWindowViewModel : ObservableObject

    {
        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public int age;

        [ObservableProperty]
        public string gender;

        [ObservableProperty]
        public DateTime dateofbirth;

        [ObservableProperty]
        public double gpa;

        [ObservableProperty]
        public string registationNo;

        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string mobileNo;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public BitmapImage selectedImage;

        public AddStudentWindowViewModel(Student u)
        {
            Student = u;

            firstname = Student.FirstName;
            lastname = Student.LastName;
            age = Student.Age;
            gpa = Student.GPA;
            dateofbirth = Student.DateOfBirth;
            selectedImage = Student.Image;
            registationNo = Student.RegistationNo;
            email = Student.Email;
            mobileNo = Student.MobileNo;
            gender = Student.Gender;


        }
        public AddStudentWindowViewModel()
        {
            Dateofbirth = DateTime.Today;
        }


        //get image 
        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            dialog.FilterIndex = 1;
            if (dialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(dialog.FileName));
                MessageBox.Show("Your Image successfuly uploded!", "successfull");
            }
        }

        public Student Student { get; private set; }
        public Action CloseAction { get; internal set; }

        [RelayCommand]
        public void Save()
        {
           
            

                if (gpa < 0 || gpa > 4)
                {
                    MessageBox.Show("GPA value must be between 0 - 4 ", "Error");
                    return;
                }
                if (Student == null)
                {
                if (registationNo == null || firstname == null)
                {
                    MessageBox.Show("Please Enter the Details.");
                }
                Student = new Student()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Age = age,
                        DateOfBirth = dateofbirth,
                        Image = selectedImage,
                        RegistationNo = registationNo,
                        Email = email,
                        MobileNo = mobileNo,
                        Gender = gender,
                        GPA = gpa

                    };


                }
                else
                {
                    Student.FirstName = firstname;
                    Student.LastName = lastname;
                    Student.Age = age;
                    Student.GPA = gpa;
                    Student.Image = selectedImage;
                    Student.DateOfBirth = dateofbirth;
                    Student.RegistationNo = registationNo;
                    Student.Email = email;
                    Student.MobileNo = mobileNo;
                    Student.Gender = gender;
                }
            

            if (Student.FirstName != null)
            {

                CloseAction();
            }
            Application.Current.MainWindow.Show();
        }



        [RelayCommand]
        public void PerformCloseWindow()
        {
            if (Student == null)
            {
                Student = new Student()
                {
                    FirstName = null,
                    LastName = null,
                    Age = 0,
                    DateOfBirth = DateTime.Today,
                    Image = null,
                    RegistationNo = null,
                    Email = null,
                    MobileNo = null,
                    Gender = null,
                    GPA = 0.00
                };
            }
            else
            {
                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.Age = age;
                Student.GPA = gpa;
                Student.Image = selectedImage;
                Student.DateOfBirth = dateofbirth;
                Student.RegistationNo = registationNo;
                Student.Email = email;
                Student.MobileNo = mobileNo;
                Student.Gender = gender;
            }
            CloseAction();
            Application.Current.MainWindow.Show();
        }
    }
}

