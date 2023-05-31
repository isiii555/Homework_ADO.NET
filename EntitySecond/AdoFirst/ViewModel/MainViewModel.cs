using AdoFirst.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
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

        private int author;
        public int Author { get => author; set => Set(ref author, value); }
        public int Category { get => category; set => Set(ref category, value); }

        public ObservableCollection<int> AuthorsId { get; set; } = new();
        public ObservableCollection<int> CategoriesId { get; set; } = new();

        public ObservableCollection<Book> Books { get; set; } = new();

        public RelayCommand AuthorChangedCommand
        {
            get => new RelayCommand(async () =>
            {
                try
                {
                    Books.Clear();
                    List<Book> source = await App.context.Books.Where(book => book.IdAuthor == Author && book.IdCategory == Category).ToListAsync();
                    source.ForEach(book => Books.Add(book));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data not found");
                }
            });
        }
    }
}
