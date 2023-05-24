using AdoFirst.View;
using AdoFirst.ViewModel;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            var view = new MainView();
            view.Show();
            var viewModel = new MainViewModel();
            SqlDataReader reader = null;
            try
            {
                viewModel.Connection.Open();
                SqlCommand command = new SqlCommand("Select Id From Authors", viewModel.Connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.AuthorsId.Add(Convert.ToInt32(reader[0]));
                }
                command = new SqlCommand("Select Id From Categories", viewModel.Connection);
                reader.Close();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.CategoriesId.Add(Convert.ToInt32(reader[0]));
                }
            }
            finally
            {
                reader.Close();
                viewModel.Connection.Close();
            }
            view.DataContext = viewModel;
        }
    }
}
