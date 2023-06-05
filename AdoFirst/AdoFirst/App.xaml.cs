using AdoFirst.Model;
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
                SqlCommand command = new SqlCommand("Select * From Authors", viewModel.Connection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.Authors.Add(new Author(Convert.ToInt32(reader[0]), reader[1].ToString() + reader[2].ToString()));
                }
                command = new SqlCommand("Select * From Categories", viewModel.Connection);
                reader.Close();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.Categories.Add(new Category(Convert.ToInt32(reader[0]), reader[1].ToString()));
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
