using MVVMDemo.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVMDemo.ViewModel
{
    public class StudentViewModel
    {
        private Student selectedStudent;
        public Student SelectedStudent
        {
            get
            {
                return selectedStudent;
            }

            set
            {
                selectedStudent = value;
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public MyICommand DeleteCommand { get; set; }

        // Constructor to load students
        public StudentViewModel()
        {
            LoadStudents();
            DeleteCommand = new MyICommand(OnDelete, CanDelete);
        }

        private void OnDelete()
        {
            Students.Remove(SelectedStudent);
        }

        private bool CanDelete()
        {
            return SelectedStudent != null;
        }

        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();

            students.Add(new Student { FirstName = "Mark", LastName = "Allain" });
            students.Add(new Student { FirstName = "Allen", LastName = "Brown" });
            students.Add(new Student { FirstName = "Linda", LastName = "Hamerski" });

            Students = students;
        }
    }
}