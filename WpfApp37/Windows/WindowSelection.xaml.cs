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
    /// Логика взаимодействия для WindowSelection.xaml
    /// </summary>
    public partial class WindowSelection : Window
    {
        public WindowSelection()
        {
            InitializeComponent();
        }


        private void BTMan_Click(object sender, RoutedEventArgs e)
        {
            Менеджер window = new Менеджер();
            window.Show();
            this.Hide();
        }
        private void BTDir_Click(object sender, RoutedEventArgs e)
        {
            Director director = new Director();
            director.Show();
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        
    }
}
