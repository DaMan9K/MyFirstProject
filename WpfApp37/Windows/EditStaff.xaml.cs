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
    /// Логика взаимодействия для EditStaff.xaml
    /// </summary>
    public partial class EditStaff : Window
    {
        BookShopEntities bs = new BookShopEntities();
        Staff gesica;
        public EditStaff(Staff staff)
        {
            InitializeComponent();
            gesica = staff;
            CBPost.ItemsSource = bs.Post.Select(x => x.PostName).ToList();
            Update();
        }

        public void Update()
        {
            TBLastName.Text = gesica.LastName;
            TBFirstName.Text = gesica.FirstName;
            TBSecondName.Text = gesica.SecondName;
            TBLogin.Text = gesica.Login;
            TBPassword.Text = gesica.Password;
            CBPost.Text = gesica.Post;
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            if (AddStaff.CheckEmpty(TBLastName) || AddStaff.CheckEmpty(TBFirstName) || AddStaff.CheckEmpty(TBSecondName) || AddStaff.CheckEmpty(TBLogin) || AddStaff.CheckEmpty(TBPassword))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (gesica.Post == "Консультант" && CBPost.Text != "Консультант")
                {
                    MessageBox.Show("Этот консультант ответственный за шкаф.Переназначте ответственного консультанта у данного шкафа", "Предупреждение");
                }
                else
                {
                    gesica.LastName = TBLastName.Text;
                    gesica.FirstName = TBFirstName.Text;
                    gesica.SecondName = TBSecondName.Text;
                    gesica.Login = TBLogin.Text;
                    gesica.Password = TBPassword.Text;
                    gesica.Post = CBPost.Text;
                    bs.SaveChanges();
                    this.Close();
                }
            }
           
            
        }
    }
}
