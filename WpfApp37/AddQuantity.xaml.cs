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
    /// Логика взаимодействия для AddQuantity.xaml
    /// </summary>
    public partial class AddQuantity : Window
    {
        BookShopEntities bs = new BookShopEntities();
        Books MZ;
        public AddQuantity(Books k)
        {
            InitializeComponent();
            cb1.ItemsSource = bs.Provider.Select(x => x.NameCompany).ToList();
            MZ = k;
        }

        private void BT1_Click(object sender, RoutedEventArgs e)
        {
            Magazine mg = new Magazine
            {
                IdBook = MZ.IdBook,
                Provider = cb1.Text,
                Quantity = int.Parse(TB1.Text)
            };
            bs.Magazine.Add(mg);
            MZ.Status = "Заказано";
            bs.SaveChanges();
            this.Close();
        }
    }
}
