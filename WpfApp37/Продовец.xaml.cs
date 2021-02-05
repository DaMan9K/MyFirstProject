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
    /// Логика взаимодействия для Продовец.xaml
    /// </summary>
    public partial class Продовец : Window
    {
        BookShopEntities bs = new BookShopEntities();
        public Продовец()
        {

            InitializeComponent();
            Update();
        }
        public void Update()
        {
            bs.SaveChanges();
            DGBook.ItemsSource = bs.Books.Where(x => x.Status == "В зале").ToList();

        }


        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtSell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Books books = DGBook.SelectedItem as Books;
                if(books.QuantityWH > 0)
                    books.Status = "На складе";
                else
                    books.Status = "Нет в наличии";

                Update();
            }
            catch (NullReferenceException)
            {

                MessageBox.Show("Выберите книгу");
            }
            
        }   
    }
}
