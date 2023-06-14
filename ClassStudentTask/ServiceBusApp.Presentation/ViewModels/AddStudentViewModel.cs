using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Data.Repos;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services;
using ServiceBusApp.Presentation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.Presentation.ViewModels
{
    public class AddStudentViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private List<Class> classes;

        public List<Class> Classes { get => classes; set => Set(ref classes, value); }

        public Class Class { get; set; }

        public Student Student { get; set; }


        public AddStudentViewModel(IRepository<Class> classrepo, IRepository<Student> studrepo, INavigationService navigationService)
        {
            _navigationService = navigationService;
            Classes = App.ClassRepo.GetAll().ToList();
            Student = new();
        }

        public RelayCommand CreateCommand
        {
            get => new RelayCommand(() =>
        {
            try
            {
                if (Student.FirstName != string.Empty && Student.ParentName != string.Empty && Student.LastName != string.Empty)
                {
                    Student.ClassId = Class.Id;
                    Student.CreationTime = DateTime.Now;
                    Student.LastModifiedTime = DateTime.Now;
                    App.StudentRepo.Add(Student);
                    App.StudentRepo.SaveChanges();
                    _navigationService.NavigateTo<StudentViewModel>();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show("Data not inserted", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
        }


    }
}
