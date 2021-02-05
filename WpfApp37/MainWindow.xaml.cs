using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp37
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookShopEntities bs = new BookShopEntities();
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tb1.Text) || String.IsNullOrEmpty(pb1.Password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
               
                Staff staff = bs.Staff.Where(a => a.Login == tb1.Text & a.Password == pb1.Password).SingleOrDefault();
                if (staff == null)
                {
                    MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                
                else if (staff.Post == "Консультант")
                {
                    Windows.Window1 window = new Windows.Window1(staff.IdStaff);
                    window.Show();
                    this.Hide();

                }
                else if (staff.Post == "Работник склада")
                {
                    Windows.РаботникСклада window1 = new Windows.РаботникСклада();
                    window1.Show();
                    this.Hide();

                }
                else if (staff.Post == "Продавец")
                {
                    Windows.Продовец window2 = new Windows.Продовец();
                    window2.Show();
                    this.Hide();

                }
                else if (staff.Post == "Менеджер")
                {
                    Windows.Менеджер window3 = new Windows.Менеджер();
                    window3.Show();
                    this.Hide();

                }
                else if (staff.Post == "Директор")
                {
                    Windows.WindowSelection window3 = new Windows.WindowSelection();
                    window3.Show();
                    this.Hide();

                }
            }
        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void pb1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                 if (String.IsNullOrEmpty(tb1.Text) || String.IsNullOrEmpty(pb1.Password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                Staff staff = bs.Staff.Where(a => a.Login == tb1.Text & a.Password == pb1.Password).SingleOrDefault();
                if (staff == null)
                {
                    MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else if (staff.Post == "Консультант")
                {
                    Windows.Window1 window = new Windows.Window1(staff.IdStaff);
                    window.Show();
                    this.Hide();

                }
                else if (staff.Post == "Работник склада")
                {
                    Windows.РаботникСклада window1 = new Windows.РаботникСклада();
                    window1.Show();
                    this.Hide();

                }
                else if (staff.Post == "Продавец")
                {
                     Windows.Продовец window2 = new Windows.Продовец();
                     window2.Show();
                     this.Hide();

                }
                else if (staff.Post == "Менеджер")
                {
                     Windows.Менеджер window3 = new Windows.Менеджер();
                     window3.Show();
                     this.Hide();

                }
                    else if (staff.Post == "Директор")
                    {
                        Windows.WindowSelection window = new Windows.WindowSelection();
                        window.Show();
                        this.Hide();

                    }
                }
            }
        }

        private void pb1_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pb1.ToolTip = pb1.Password;
        }
    }
}
