using AdoFirst.Context;
using AdoFirst.View;
using AdoFirst.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AdoFirst
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static LibraryContext context = new();
        protected override async void OnStartup(StartupEventArgs e)
        {
            var view = new MainView();
            view.Show();
            var viewModel = new MainViewModel();
            var Authors = await context.Authors.ToListAsync();
            Authors.ForEach(x => viewModel.Authors.Add(x));
            var Categories = await context.Categories.ToListAsync();
            Categories.ForEach(x => viewModel.Categories.Add(x));
            view.DataContext = viewModel;
        }
    }
}
