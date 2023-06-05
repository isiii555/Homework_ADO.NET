using EF_Core_Task.Models;
using EF_Core_Task.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EF_Core_Task.ViewModels.CarViewModel
{
    public class CarViewModel : ViewModelBase
    {
        private List<Car> cars;

        public CarViewModel()
        {
            Cars = App.Context.Cars.ToList();
        }

        public List<Car> Cars { get => cars; set => Set(ref cars, value); }

        public Car SelectedCar { get; set; } = new();

        public RelayCommand AddCarCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new AddCarView();
                window.DataContext = new AddCarViewModel(window);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
                Cars = App.Context.Cars.ToList();
            });
        }

        public RelayCommand EditCarCommand
        {
            get => new RelayCommand(() =>
            {
                Window window = new EditCarView();
                window.DataContext = new EditCarViewModel(SelectedCar, window);
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                window.ShowDialog();
                Cars = App.Context.Cars.ToList();
            });
        }

        public RelayCommand RemoveCarCommand
        {
            get => new RelayCommand(() =>
            {
                App.Context.Cars.Remove(SelectedCar);
                App.Context.SaveChanges();
                Cars = App.Context.Cars.ToList();
            });
        }
    }
}
