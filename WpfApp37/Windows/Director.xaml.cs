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
    /// Логика взаимодействия для Director.xaml
    /// </summary>
    public partial class Director : Window
    {
        BookShopEntities bs = new BookShopEntities();
        public Director()
        {
            InitializeComponent();
            Update();


        }
        public void Update()
        {
            bs.SaveChanges();
            DGShelf.ItemsSource = bs.ShelingUnitHall.ToList();
            DGStaff.ItemsSource = bs.Staff.ToList();
        }


        private void DGShelf_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            ShelingUnitHall t = DGShelf.SelectedItem as ShelingUnitHall;
            if (t != null)
            {

                Change change = new Change(t);
                change.ShowDialog();
                
            }
      
            Update();
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DGShelf_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            addWindow add = new addWindow();
            add.ShowDialog();
            Update();
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            AddStaff addStaff = new AddStaff();
            addStaff.ShowDialog();
            Update();
        }

        private void BTEdit_Click(object sender, RoutedEventArgs e)
        {
            Staff g = DGStaff.SelectedItem as Staff;
            if(g != null)
            {
                EditStaff editStaff = new EditStaff(g);
                editStaff.ShowDialog();
                Update();

            }
            else
            {
                MessageBox.Show("Выбери строку,дебил!!!");
            }
        }

        private void BTDell_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Staff staff = DGStaff.SelectedItem as Staff;
                if (staff == null)
                    return;
                MessageBoxResult msbr = MessageBox.Show("Вы уверены?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (msbr == MessageBoxResult.Yes)
                {
                    bs.Staff.Remove(staff);
                    Update();
                }
            }
            catch (InvalidOperationException)
            {

                MessageBox.Show("Этот консультант ответственный за шкаф.Переназначте ответственного консультанта у данного шкафа","Предупреждение");
            }
            
        }
    }
}
