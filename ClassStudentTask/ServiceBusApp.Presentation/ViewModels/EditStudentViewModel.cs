using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ServiceBusApp.Presentation.ViewModels
{
    public class EditStudentViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public Student TempStudent { get; set; }

        public Class Class { get; set; }

        public List<Class> Classes { get; set; }

        public Student Student { get; set; }
        public EditStudentViewModel(INavigationService navigationService) {
            TempStudent = new Student();
            Classes = App.ClassRepo.GetAll().ToList();
            this.navigationService = navigationService;
        }

        public RelayCommand SaveCommand { get => new RelayCommand(() =>
        {
            try
            {
                if (TempStudent?.FirstName != string.Empty && TempStudent?.LastName != string.Empty && TempStudent?.ParentName != string.Empty && Class != null)
                {
                    Student.ClassId = Class.Id;
                    Student.FirstName = TempStudent.FirstName;
                    Student.LastName = TempStudent.LastName;
                    Student.ParentName = TempStudent.ParentName;
                    Student.LastModifiedTime = DateTime.Now;
                    App.StudentRepo.Update(Student);
                    App.StudentRepo.SaveChanges();
                    navigationService.NavigateTo<StudentViewModel>();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception e)
            {
                MessageBox.Show("Data not modified!", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        });
        }
    }
}
