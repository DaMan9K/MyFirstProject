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
    /// Логика взаимодействия для AddStaff.xaml
    /// </summary>
    public partial class AddStaff : Window
    {
        BookShopEntities bs = new BookShopEntities();
        public AddStaff()
        {
            InitializeComponent();
            CBPost.ItemsSource = bs.Post.Select(x => x.PostName).ToList();
            Update();
        }
        public void Update()
        {
            bs.SaveChanges();
        }
        public static bool CheckEmpty(TextBox tb)
        {
            if (String.IsNullOrEmpty(tb.Text))
            {
                tb.BorderBrush = Brushes.Red;
                return true;
            }
            else
            {
                tb.BorderBrush = Brushes.Gray;
                return false;
            }
                
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            if ( CheckEmpty(TBLastName) || CheckEmpty(TBFirstName) || CheckEmpty(TBSecondName) || CheckEmpty(TBLogin) ||
                CheckEmpty(TBPassword))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Staff staff = new Staff
                {
                    FirstName = TBFirstName.Text,
                    SecondName = TBSecondName.Text,
                    LastName = TBLastName.Text,
                    Login = TBLogin.Text,
                    Password = TBPassword.Text,
                    Post = CBPost.Text


                };
                bs.Staff.Add(staff);
                Update();
                this.Close();
            }
        }
    }
}
