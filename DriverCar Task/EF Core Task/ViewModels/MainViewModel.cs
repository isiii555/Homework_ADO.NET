using EF_Core_Task.Views;
using EF_Core_Task.Views.DriverView;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EF_Core_Task.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Page currentPage;

        public Page CurrentPage
        {
            get => currentPage;
            set => Set(ref currentPage, value);
        }

        public MainViewModel()
        {
            CurrentPage = new Page() { DataContext = this };
        }

        public RelayCommand CarPageCommand
        {
            get => new RelayCommand(() =>
            {
                CurrentPage = App.Container.GetInstance<CarView>();
                CurrentPage.DataContext = new CarViewModel.CarViewModel();
            });
        }

        public RelayCommand DriverPageCommand
        {
            get => new RelayCommand(() =>
            {
                CurrentPage = App.Container.GetInstance<DriverView>();
                CurrentPage.DataContext = new DriverViewModel.DriverViewModel();
            });
        }
    }
}
