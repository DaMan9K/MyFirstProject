using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp37.Windows
{
   
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int idC;
        BookShopEntities bs = new BookShopEntities();
        public Window1(int id)
        {
            idC = id;
            InitializeComponent();
            Update();
            
        }
        public void Update()
        {
            bs.SaveChanges();
            DGShelingHall.ItemsSource = bs.ShelingUnitHall.Where(x => x.IdConsultant == idC ).ToList();
            DGShulf.ItemsSource = bs.shulf.ToList();
            DGBook.ItemsSource = bs.Books.ToList();
            CBShell.ItemsSource = bs.shulf.Select(x => x.IdShelf).ToList();
            CBGener.ItemsSource = bs.Gener.Select(x => x.Gener1).ToList();
            CBTheme.ItemsSource = bs.ThemeName.Select(x => x.NameTheme).ToList();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Books books = DGBook.SelectedItem as Books;
            books.NumberShelf = int.Parse(CBShell.Text);
            books.Genre = CBGener.Text;

            Update();
        }

        private void DGBook_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            Books books = DGBook.SelectedItem as Books;
            CBShell.SelectedItem = books.NumberShelf;
            CBGener.SelectedItem = books.Genre;
        }

        private void DGShelingHall_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ShelingUnitHall suh = DGShelingHall.SelectedItem as ShelingUnitHall;
            CBTheme.SelectedItem = suh.Thema;
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            ShelingUnitHall suh = DGShelingHall.SelectedItem as ShelingUnitHall;
            suh.Thema= CBTheme.Text;
            Update();
        }
    }
}
