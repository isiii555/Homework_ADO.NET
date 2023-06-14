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
    public class EditClassViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public Class TempClass { get; set; }
        public Class Class { get; set; }
        public EditClassViewModel(INavigationService navigationService)
        {
            TempClass = new Class();
            this.navigationService = navigationService;
        }

        public RelayCommand SaveCommand
        {
            get => new RelayCommand(() =>
            {
                try
                {
                    if (TempClass.Name != String.Empty)
                    {
                        Class.Name = TempClass.Name;
                        Class.LastModifiedTime = DateTime.Now;
                        App.ClassRepo.Update(Class);
                        App.ClassRepo.SaveChanges();
                        navigationService.NavigateTo<ClassViewModel>();
                    }
                    else
                        MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Data not modified!", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
        }
    }
}
