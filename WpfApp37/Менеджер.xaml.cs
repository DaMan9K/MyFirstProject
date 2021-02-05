using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Менеджер.xaml
    /// </summary>
    public partial class Менеджер : Window
    {
        BookShopEntities bs = new BookShopEntities();
        public Менеджер()
        {
            InitializeComponent();
            Update();
        }
        public void Update()
        {
            
            bs.SaveChanges();
            DGBook.ItemsSource = bs.Books.ToList();
            DGMagazine.ItemsSource = bs.Magazine.ToList();
            DGEnd.ItemsSource = bs.Books.Where(x => x.Status == "Нет в наличии").ToList();

        }
        private void DGEnd_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
            Books mz = DGEnd.SelectedItem as Books;
            if (mz != null)
            {
                AddQuantity aq = new AddQuantity(mz);
                aq.ShowDialog();
            }
        }
        private void BTCom_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Magazine mg = DGMagazine.SelectedItem as Magazine;
                Books books = bs.Books.Where(X => X.IdBook == mg.IdBook).SingleOrDefault();
                if (books != null)
                {
                    books.QuantityWH = mg.Quantity;
                    books.Status = "На складе";
                    bs.Magazine.Remove(mg);
                    Update();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Выбери заказ", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
            
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }

        private void BTAddBooks_Click(object sender, RoutedEventArgs e)
        {
            AddBooks ab = new AddBooks();
            ab.ShowDialog();
            Update();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


    }

}
