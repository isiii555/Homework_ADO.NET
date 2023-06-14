using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ServiceBusApp.Data.Repos;
using ServiceBusApp.Models.Concretes;
using ServiceBusApp.Presentation.Services;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ServiceBusApp.Presentation.ViewModels
{
    public class ClassViewModel : ViewModelBase
    {
        private INavigationService navigationService;
        private ObservableCollection<Class> classes;

        public Class Class { get; set; }
        public ObservableCollection<Class> Classes { get => classes; set => Set(ref classes,value); }
        public ClassViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            Classes = new ObservableCollection<Class>(App.ClassRepo.GetAll());
        }

        public RelayCommand AddClassCommand
        {
            get => new RelayCommand(() =>
        {
            navigationService.NavigateTo<AddClassViewModel>();
        });
        }

        public RelayCommand EditClassCommand
        {
            get => new RelayCommand(() =>
            {
                EditClassViewModel viewModel = App.Container.GetInstance<EditClassViewModel>();
                viewModel.Class = Class;
                viewModel.TempClass.Name = Class.Name;
                viewModel.TempClass.CreationTime = Class.CreationTime;
                navigationService.NavigateTo<EditClassViewModel>();
            });
        }

        public RelayCommand RemoveClassCommand
        {
            get => new RelayCommand(() =>
            {
                App.ClassRepo.Remove(Class);
                App.ClassRepo.SaveChanges();
                Classes = new ObservableCollection<Class>(App.ClassRepo.GetAll());
            });
        }

    }
}
