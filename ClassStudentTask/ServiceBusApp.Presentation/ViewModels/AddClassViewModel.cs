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
    public class AddClassViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        public Class Class { get; set; }

        public AddClassViewModel(INavigationService navigationService)
        {
            Class = new();
            this.navigationService = navigationService;
        }
        public RelayCommand CreateCommand { get => new RelayCommand(() =>
        {
            try
            {
                if (Class.Name != string.Empty)
                {
                    Class.CreationTime = DateTime.Now;
                    Class.LastModifiedTime = DateTime.Now;
                    App.ClassRepo.Add(Class);
                    App.ClassRepo.SaveChanges();
                    navigationService.NavigateTo<ClassViewModel>();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception e)
            {
                MessageBox.Show("Data not inserted.");
            }
        });
        }
    }
}
