
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using StudentManagementForm.Models;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace StudentManagementForm
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Student> users;
        [ObservableProperty]
        public Student? selectedUser = null;



        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddStudentWindowViewModel();
            vm.title = "ADD USER";
            AddStudentWindow window = new AddStudentWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is Deleted successfuly.", "DELETED \a ");

            }
            else
            {
                MessageBox.Show("Plese Select Student before Delete.", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddStudentWindowViewModel(selectedUser);
                vm.title = "EDIT USER";
                var window = new AddStudentWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please Select the student", "Warning!");
            }
        }
        [RelayCommand]
        public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }

        [RelayCommand]
        public void MinimizeMainWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        [RelayCommand]
        public void MaximizeMainWindow()
        {
            if (Application.Current.MainWindow.WindowState == WindowState.Normal)
            {
                Application.Current.MainWindow.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            }

        }





        public MainWindowViewModel()
        {
            users = new ObservableCollection<Student>();

            DateTime date1 = new DateTime(2000, 1, 10);
            BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            users.Add(new Student(23, "Sahaswari", "Senanyaka", date1, image1, "smsstg@gmail.com", "0763448956", "EE/2020/4185", 3.56, "Female"));

            DateTime date2 = new DateTime(2000, 10, 10);
            BitmapImage image2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
            users.Add(new Student(12, "Thanuja", "Weerakoon", date2, image2, "smsstukg@gmail.com", "0763448957", "EE/2020/4186", 3.45, "Male"));

            DateTime date3 = new DateTime(2000, 5, 15);
            BitmapImage image3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            users.Add(new Student(12, "Susuila", "Bandara", date3, image3, "stthustg@gmail.com", "0767448956", "EE/2020/4187", 2.31, "Female"));

            DateTime date4 = new DateTime(2000, 11, 30);
            BitmapImage image4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
            users.Add(new Student(12, "Shehani", "Senarathana", date4, image4, "tharikatg@gmail.com", "0764568956", "EE/2020/4188", 2.01, "Female"));

            DateTime date5 = new DateTime(2001, 9, 21);
            BitmapImage image5 = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative));
            users.Add(new Student(12, "Shehansa", "Ranaweera", date5, image5, "ranaweerag@gmail.com", "0761028956", "EE/2020/4190", 1.91, "Male"));

        }
    }
}
