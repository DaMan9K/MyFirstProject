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
        List<int> Authors = new List<int>();
        int res;
        Books bookEdit;
        public AddBooks(Books book, int func, string name)
        {
            InitializeComponent();
            
            List<Author> vs = bs.Author.ToList();
            foreach (var item in vs)
            {
                cbAuthor.Items.Add($"{item.Lastame} {item.FirstName} {item.SecondName}");
                Authors.Add(item.IdAuthor);
            }
            CBGener1.ItemsSource = bs.Gener.Select(x => x.Gener1).ToList();
            CBShell.ItemsSource = bs.shulf.Select(x => x.IdShelf).ToList();
            res = func;
            bookEdit = book;
            Update();
            BTAddAll.Content = name;


        }
        public void Update()
        {

            int c = bookEdit.NameAuth;
            int g = 0;
            for (int i = 0; i < Authors.Count; i++)
            {
                if (Authors[i] == c)
                    g = i;
            }
            bs.SaveChanges();
            if (res == 2)
            {
                TBNameBook.Text = bookEdit.NameBook;
                cbAuthor.SelectedIndex = g;
                DPStart.Text = bookEdit.YearBook.ToString();
                CBGener1.Text = bookEdit.Genre;
                TBMoney.Text = bookEdit.Price.ToString();
                CBShell.Text = bookEdit.NumberShelf.ToString();
            }
            
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
            
            if (res == 1)
            {
                Books books = new Books
                {
                    NameBook = TBNameBook.Text,
                    NameAuth = Authors[cbAuthor.SelectedIndex],
                    YearBook = Convert.ToDateTime(DPStart.Text),
                    Genre = CBGener1.Text,
                    Price = Convert.ToDecimal(TBMoney.Text),
                    Status = "Нет в наличии",
                    NumberShelf = int.Parse(CBShell.Text),
                    QuantityWH = 0,



                };
                bs.Books.Add(books);
            }
            else
            {
                bookEdit.NameBook = TBNameBook.Text;
                bookEdit.NameAuth = Authors[cbAuthor.SelectedIndex];
                bookEdit.YearBook = Convert.ToDateTime(DPStart.Text);
                bookEdit.Genre = CBGener1.Text;
                bookEdit.Price = Convert.ToDecimal(TBMoney.Text);
                bookEdit.Status = "Нет в наличии";
                bookEdit.NumberShelf = int.Parse(CBShell.Text);
                bookEdit.QuantityWH = 0;
            }
            Update();
            this.Close();

        }

      
    }
}
