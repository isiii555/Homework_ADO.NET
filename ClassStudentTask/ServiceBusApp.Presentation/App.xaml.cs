using ServiceBusApp.Presentation.ViewModels;
using ServiceBusApp.Presentation.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SimpleInjector;
using ServiceBusApp.Presentation.Services;
using GalaSoft.MvvmLight.Messaging;
using ServiceBusApp.Data.Repos;
using ServiceBusApp.Models.Concretes;

namespace ServiceBusApp.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IRepository<Class> ClassRepo { get; set; }

        public static IRepository<Student> StudentRepo { get; set; }
        public static Container? Container { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            Register();
            ClassRepo = new Repository<Class>();
            StudentRepo = new Repository<Student>();
            var window = Container?.GetInstance<MainWindow>();
            window.WindowState = WindowState.Maximized;
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.DataContext = Container?.GetInstance<MainViewModel>();
            window.ShowDialog();
            Current.Shutdown();
        }

        void Register()
        {
            Container = new Container();
            Container.RegisterSingleton<INavigationService, NavigationService>();
            Container.RegisterSingleton<IMessenger, Messenger>();

            Container.RegisterSingleton<IRepository<Class>, Repository<Class>>();
            Container.RegisterSingleton<IRepository<Student>, Repository<Student>>();

            Container.RegisterSingleton<MainWindow>();
            Container.RegisterSingleton<StudentsView>();
            Container.RegisterSingleton<ClassesView>();
            Container.RegisterSingleton<AddStudentView>();
            Container.RegisterSingleton<EditStudentView>();
            Container.RegisterSingleton<AddClassView>();
            Container.RegisterSingleton<EditClassView>();

            Container.Register<MainViewModel>();
            Container.Register<StudentViewModel>();
            Container.Register<ClassViewModel>();
            Container.Register<AddStudentViewModel>();
            Container.RegisterSingleton<EditStudentViewModel>();
            Container.Register<AddClassViewModel>();
            Container.RegisterSingleton<EditClassViewModel>();
        }
    }
}
