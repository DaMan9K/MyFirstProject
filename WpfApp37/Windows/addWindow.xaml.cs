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
    /// Логика взаимодействия для addWindow.xaml
    /// </summary>
    public partial class addWindow : Window
    {
        BookShopEntities bs = new BookShopEntities();
        List<int> Staff = new List<int>();
        public addWindow()
        {
            InitializeComponent();
            List<Staff> vs = bs.Staff.Where(x => x.Post == "Консультант").ToList();
            foreach (var item in vs)
            {
                CBCons.Items.Add($"{item.LastName} {item.FirstName} {item.SecondName}");
                Staff.Add(item.IdStaff);

            }

        }

        private void BTAddShell_Click(object sender, RoutedEventArgs e)
        {
            ShelingUnitHall sh = new ShelingUnitHall();
            sh.IdConsultant = Staff[CBCons.SelectedIndex];
            sh.Thema = "Не назначена";
            bs.ShelingUnitHall.Add(sh);
            bs.SaveChanges();
            this.Close();

        }
    }
}
