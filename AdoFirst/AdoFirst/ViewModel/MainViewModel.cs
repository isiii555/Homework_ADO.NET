using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdoFirst.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private int category;

        private DataTable data = new DataTable();

        private DataView view = new DataView();

        private int author;
        public int Author { get => author; set => Set(ref author, value); }
        public int Category { get => category; set => Set(ref category, value); }

        public ObservableCollection<int> AuthorsId { get; set; } = new();
        public ObservableCollection<int> CategoriesId { get; set; } = new();

        public DataTable Data { get => data; set => Set(ref data, value); }

        public DataView View { get => view; set => Set(ref view,value); }

        public SqlConnection Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString);

        public RelayCommand AuthorChangedCommand
        {
            get => new RelayCommand(() =>
            {
                try
                {
                    Data.Clear();
                    SqlDataAdapter sqlDataAdapter = new("Select * From Books Where Id_Category = @C_id And Id_Author = @A_id", Connection);
                    sqlDataAdapter.SelectCommand.Parameters.Add("@C_id", SqlDbType.Int).Value = Category;
                    sqlDataAdapter.SelectCommand.Parameters.Add("@A_id", SqlDbType.Int).Value = Author;
                    sqlDataAdapter.Fill(dataTable: Data);
                    View = Data.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data not found");
                }
            });
        }
    }
}
