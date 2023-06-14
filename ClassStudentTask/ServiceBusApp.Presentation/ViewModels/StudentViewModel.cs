using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using ServiceBusApp.Data.Repos;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services;
using ServiceBusApp.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.Presentation.ViewModels
{
    public class StudentViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        private ObservableCollection<Student> students;

        public Student Student { get; set; } = new();

        public ObservableCollection<Student> Students { get => students; set => Set(ref students,value); }
        public StudentViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Students = new ObservableCollection<Student>(App.StudentRepo.GetAllQuery().Include(st => st.Class));
        }
        public RelayCommand AddStudentCommand { get => new RelayCommand(() =>
        {
            navigationService.NavigateTo<AddStudentViewModel>();
        });
        }

        public RelayCommand EditStudentCommand { get => new RelayCommand(() =>
        {
            App.Container.GetInstance<EditStudentViewModel>().Student = Student;
            var stud = App.Container.GetInstance<EditStudentViewModel>().TempStudent;
            stud.FirstName = Student.FirstName;
            stud.LastName = Student.LastName;
            stud.ParentName = Student.ParentName;
            stud.ClassId = Student.ClassId;
            App.Container.GetInstance<EditStudentViewModel>().Classes = App.ClassRepo.GetAll().ToList();
            navigationService.NavigateTo<EditStudentViewModel>();
        });
        }

        public RelayCommand RemoveStudentCommand
        {
            get => new RelayCommand(() =>
            {
                App.StudentRepo.Remove(Student);
                App.StudentRepo.SaveChanges();
                Students = new ObservableCollection<Student>(App.StudentRepo.GetAll());
            });
        }
    }
}
