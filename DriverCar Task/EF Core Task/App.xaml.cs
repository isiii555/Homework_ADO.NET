using EF_Core_Task.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using EF_Core_Task.ViewModels;
using EF_Core_Task.Views.DriverView;
using Microsoft.EntityFrameworkCore;
using EF_Core_Task.Context;

namespace EF_Core_Task
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SchoolBusDbContext Context { get; set; } = new();
        public static SimpleInjector.Container? Container { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            var window = Container.GetInstance<MainView>();
            window.DataContext = new MainViewModel();
            window.VerticalAlignment = VerticalAlignment.Center;
            window.HorizontalAlignment = HorizontalAlignment.Center;
            window.ShowDialog();
            Current.Shutdown();
        }
        private void Register()
        {
            Container = new();

            Container.RegisterSingleton<MainView>();
            Container.RegisterSingleton<CarView>();
            Container.Register<AddCarView>();
            Container.RegisterSingleton<DriverView>();

            Container.Verify();
        }
    }
}
