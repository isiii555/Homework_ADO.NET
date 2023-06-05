using EF_Core_Task.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace EF_Core_Task.ViewModels.CarViewModel
{
    public class AddCarViewModel : ViewModelBase
    {
        private Car car = new();
        public Window CurrenWindow { get; set; }
        public AddCarViewModel(Window currenWindow)
        {
            CurrenWindow = currenWindow;
        }

        public Car Car
        {
            get { return car; }
            set { Set(ref car, value); }
        }

        public RelayCommand CreateCommand
        {
            get => new RelayCommand(() =>
            {
                Regex regex = new("([A-Za-z0-9]+(-[A-Za-z0-9]+)+)");
                if (car.SerialNumber != null && car.Vendor != null && car.Model != null)
                {
                    if (regex.IsMatch(car.SerialNumber) && car.SeatCount > 0 && car.Vendor != string.Empty && car.Model != string.Empty)
                    {
                        App.Context.Add(Car);
                        App.Context.SaveChanges();
                        CurrenWindow.Close();
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
