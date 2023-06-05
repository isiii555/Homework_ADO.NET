using AdoFirst.Model;
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
        private Category category;

        private DataTable data = new DataTable();

        private DataView view = new DataView();

        private Author author;
        public Author Author { get => author; set => Set(ref author, value); }
        public Category Category { get => category; set => Set(ref category, value); }

        public ObservableCollection<Author> Authors { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();

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
                    SqlDataAdapter sqlDataAdapter = new("Select * From Books Where (@C_id is null OR Id_Category = @C_id) And (@A_id = null OR Id_Author = @A_id)", Connection);
                    sqlDataAdapter.SelectCommand.Parameters.Add("@C_id", SqlDbType.Int).Value = Category.Id;
                    sqlDataAdapter.SelectCommand.Parameters.Add("@A_id", SqlDbType.Int).Value = Author.Id;
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
