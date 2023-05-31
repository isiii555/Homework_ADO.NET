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
            var AuthorsId = await context.Authors.Select(x => x.Id).ToListAsync();
            AuthorsId.ForEach(x => viewModel.AuthorsId.Add(x));
            var CategoriesId = await context.Categories.Select(x => x.Id).ToListAsync();
            CategoriesId.ForEach(x => viewModel.CategoriesId.Add(x));
            view.DataContext = viewModel;
        }
    }
}
