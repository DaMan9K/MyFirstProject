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
    /// Логика взаимодействия для ПроверкаХоллаРБ.xaml
    /// </summary>
    public partial class ПроверкаХоллаРБ : Window
    {
        BookShopEntities bs = new BookShopEntities();
        public ПроверкаХоллаРБ()
        {

            InitializeComponent();
            Update();
        }
        public void Update()
        {
            bs.SaveChanges();
            DGBooks.ItemsSource = bs.Books.Where(x => x.Status == "На складе").ToList();
        }

        private void BTMove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Books books = DGBooks.SelectedItem as Books;
                books.Status = "В зале";
                books.QuantityWH = books.QuantityWH - 1;
                ShelingWarehouse shw = new ShelingWarehouse();
                shw.Quantity = shw.Quantity - 1;
                Update();
                
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Выберите книгу для перемешения в холл");
            }
        }

        private void BtExit_Click(object sender, RoutedEventArgs e)
        {
            РаботникСклада window = new РаботникСклада();
            window.Show();
            this.Hide();
        }
    }
}
