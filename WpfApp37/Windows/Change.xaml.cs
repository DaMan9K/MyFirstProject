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
    /// Логика взаимодействия для Change.xaml
    /// </summary>
    public partial class Change : Window
    {
        BookShopEntities bs = new BookShopEntities();
        ShelingUnitHall shelingUnit;
        List<int> Staff = new List<int>();
        public Change(ShelingUnitHall shelingUnitHall)
        {            
            InitializeComponent();
            shelingUnit = shelingUnitHall;
            List<Staff> vs = bs.Staff.Where(x => x.Post== "Консультант").ToList();
            foreach (var item in vs)
            {
                CBcons.Items.Add($"{item.LastName} {item.FirstName} {item.SecondName}");
                Staff.Add(item.IdStaff);
               
            }          
        }
        private void BTEdit_Click(object sender, RoutedEventArgs e)
        {
            shelingUnit.IdConsultant = Staff[CBcons.SelectedIndex];         
            this.Close();
        }
        
    }
}
