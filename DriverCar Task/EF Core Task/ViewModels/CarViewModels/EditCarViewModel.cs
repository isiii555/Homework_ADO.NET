using EF_Core_Task.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace EF_Core_Task.ViewModels.CarViewModel
{
    public class EditCarViewModel : ViewModelBase
    {
        public Car? car;

        public Car? Car
        {
            get { return car; }
            set { Set(ref car, value); }
        }

        public Car TempCar { get; set; } = new();
        public Window CurrentWindow { get; set; }
        public EditCarViewModel(Car tempCar, Window currentWindow)
        {
            Car = new();
            TempCar = tempCar;
            Car.Vendor = TempCar.Vendor;
            Car.Model = TempCar.Model;
            Car.SerialNumber = TempCar.SerialNumber;
            Car.SeatCount = TempCar.SeatCount;
            CurrentWindow = currentWindow;
        }

        public RelayCommand SaveCommand
        {
            get => new RelayCommand(
            () =>
            {
                Regex regex = new("([A-Za-z0-9]+(-[A-Za-z0-9]+)+)");
                if (Car.SerialNumber != string.Empty && Car.Vendor != string.Empty && Car.Model != string.Empty)
                {
                    if (regex.IsMatch(Car.SerialNumber) && Car.SeatCount > 0 && Car.Vendor != string.Empty && Car.Model != string.Empty)
                    {
                        TempCar.SerialNumber = Car.SerialNumber;
                        TempCar.Vendor = Car.Vendor;
                        TempCar.SeatCount = Car.SeatCount;
                        TempCar.Model = Car.Model;
                        App.Context.Update(TempCar);
                        App.Context.SaveChanges();
                        CurrentWindow.Close();
                    }
                    else
                        MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                    MessageBox.Show("Invalid input", "ServiceBusApp", MessageBoxButton.OK, MessageBoxImage.Error);
            });
        }
    }
}
