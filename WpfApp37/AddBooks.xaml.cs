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
    /// Логика взаимодействия для AddBooks.xaml
    /// </summary>
    public partial class AddBooks : Window
    {
        
        BookShopEntities bs = new BookShopEntities();
        
        public AddBooks()
        {
            InitializeComponent();
            List<Author> vs = bs.Author.ToList();
            foreach (var item in vs)
            {
                cbAuthor.Items.Add($"{item.Lastame} {item.FirstName} {item.SecondName}");
            }
            CBGener1.ItemsSource = bs.Gener.Select(x => x.Gener1).ToList();
            CBShell.ItemsSource = bs.shulf.Select(x => x.IdShelf).ToList();
            Update();

        }
        public void Update()
        {
            
            
            bs.SaveChanges();

        }

        private void CBAuthor_Checked(object sender, RoutedEventArgs e)
        {
            BTAddAuthor.Visibility = Visibility.Visible;
            LBFNameAuthor.Visibility = Visibility.Visible;
            LBLNameAuthor.Visibility = Visibility.Visible;
            LBSNameAuthor.Visibility = Visibility.Visible;
            LBTitle.Visibility = Visibility.Visible;
            TBFNameAuthor.Visibility = Visibility.Visible;
            TBLNameAuthor.Visibility = Visibility.Visible;
            TBSNameAuthor.Visibility = Visibility.Visible;
            CBGener.IsChecked = false;
        }
        
        private void CBAuthor_Unchecked(object sender, RoutedEventArgs e)
        {
            BTAddAuthor.Visibility = Visibility.Hidden;
            LBFNameAuthor.Visibility = Visibility.Hidden;
            LBLNameAuthor.Visibility = Visibility.Hidden;
            LBSNameAuthor.Visibility = Visibility.Hidden;
            LBTitle.Visibility = Visibility.Hidden;
            TBFNameAuthor.Visibility = Visibility.Hidden;
            TBLNameAuthor.Visibility = Visibility.Hidden;
            TBSNameAuthor.Visibility = Visibility.Hidden;
        }
        private void CBGener_Unchecked(object sender, RoutedEventArgs e)
        {
            BTGenerAdd.Visibility = Visibility.Hidden;
            LBGenerAdd.Visibility = Visibility.Hidden;
            LBTitleGenerAdd.Visibility = Visibility.Hidden;
            TBGenerAdd.Visibility = Visibility.Hidden;
        }

        private void CBGener_Checked(object sender, RoutedEventArgs e)
        {
            BTGenerAdd.Visibility = Visibility.Visible;
            LBGenerAdd.Visibility = Visibility.Visible;
            LBTitleGenerAdd.Visibility = Visibility.Visible;
            TBGenerAdd.Visibility = Visibility.Visible;
            CBAuthor.IsChecked = false;
        }

        private void BTAddAuthor_Click(object sender, RoutedEventArgs e)
        {
            Author author = new Author
            {
                Lastame = TBLNameAuthor.Text,
                FirstName = TBFNameAuthor.Text,
                SecondName = TBSNameAuthor.Text

            };
            TBFNameAuthor.Clear();
            TBLNameAuthor.Clear();
            TBSNameAuthor.Clear();
         
            bs.Author.Add(author);
            cbAuthor.Items.Add($"{author.Lastame} {author.FirstName} {author.SecondName}");
            Update();
        }

        private void BTGenerAdd_Click(object sender, RoutedEventArgs e)
        {
            Gener gener = new Gener
            {
                Gener1 = TBGenerAdd.Text
            };
            bs.Gener.Add(gener);
            
            Update();
            CBGener1.ItemsSource = bs.Gener.Select(x => x.Gener1).ToList();
            TBGenerAdd.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            Books books = new Books
            {
                NameBook = TBNameBook.Text,
                NameAuth = cbAuthor.SelectedIndex+1,
                YearBook = Convert.ToDateTime(DPStart.Text),
                Genre = CBGener1.Text,
                Price = Convert.ToDecimal(TBMoney.Text),
                Status = "Нет в наличии",
                NumberShelf = int.Parse(CBShell.Text)
                
            };
            bs.Books.Add(books);
            Update();
            this.Close();
        }

      
    }
}
