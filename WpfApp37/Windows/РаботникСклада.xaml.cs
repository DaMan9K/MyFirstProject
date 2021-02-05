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
    /// Логика взаимодействия для РаботникСклада.xaml
    /// </summary>
    public partial class РаботникСклада : Window
    {
        
        BookShopEntities bs = new BookShopEntities();
        public РаботникСклада()
        {   
            
            InitializeComponent();
            Update();


        }
        public void Update()
        {
            bs.SaveChanges();
            DGWHW.ItemsSource = bs.ShelingWarehouse.ToList();
            

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
           Application.Current.Shutdown();
            
        }

        private void BtUpdata_Click(object sender, RoutedEventArgs e)
        {
            ПроверкаХоллаРБ window = new ПроверкаХоллаРБ();
            window.ShowDialog();
            
        }
    }
}
