using EF_Core_Task.Models;
using EF_Core_Task.Views.DriverView;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EF_Core_Task.ViewModels.DriverViewModel
{
    public class DriverViewModel : ViewModelBase
    {
        private List<Driver> drivers = new();

        public List<Driver> Drivers { get => drivers; set => Set(ref drivers,value); }
        public Driver? SelectedDriver { get; set; }

        public DriverViewModel()
        {
            Drivers = App.Context.Drivers.Include(driver => driver.Car).ToList();
        }

        public RelayCommand AddDriverCommand
        {
            get => new RelayCommand(
                () =>
                {
                    Window window = new AddDriverView();
                    window.DataContext = new AddDriverViewModel(window);
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.ShowDialog();
                    Drivers = App.Context.Drivers.ToList();
                });
        }

        public RelayCommand EditDriverCommand
        {
            get => new RelayCommand(
                () =>
                {
                    Window window = new EditDriverView();
                    window.DataContext = new EditDriverViewModel(SelectedDriver, window);
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.ShowDialog();
                    Drivers = App.Context.Drivers.ToList();
                });
        }

        public RelayCommand RemoveDriverCommand
        {
            get => new RelayCommand(
                () =>
                {
                    App.Context.Remove(SelectedDriver);
                    App.Context.SaveChanges();
                    Drivers = App.Context.Drivers.ToList();
                });
        }
    }
}
