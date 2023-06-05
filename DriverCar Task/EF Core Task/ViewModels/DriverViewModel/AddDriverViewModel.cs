using EF_Core_Task.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EF_Core_Task.ViewModels.DriverViewModel
{
    public class AddDriverViewModel : ViewModelBase
    {
        private Driver? driver;
        public Driver? Driver
        {
            get { return driver; }
            set { Set(ref driver, value); }
        }
        public List<Car> Cars { get; set; }

        public Car? SelectedItem { get; set; }

        public Window CurrentWindow { get; set; }
        public AddDriverViewModel(Window currentWindow)
        {
            Driver = new();
            Cars = App.Context.Cars.ToList();
            CurrentWindow = currentWindow;
        }

        public RelayCommand CreateCommand
        {
            get => new RelayCommand(() =>
            {
                if (driver!.Adress != null && driver.Name != null && driver.Surname != null && SelectedItem != null)
                {
                    Driver.Car = SelectedItem;
                    App.Context.Update(SelectedItem);
                    App.Context.Add(driver);
                    App.Context.SaveChanges();
                    CurrentWindow.Close();
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }

    }
}