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
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Configuration;
using System.Data;

using PasswordManager.Model;
using System.IO;
using PasswordManager.ViewModel;
using PasswordManager.View;

namespace PasswordManager 
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataViewModel();

        }

        private void Password_Generator_Click(object sender, RoutedEventArgs e)
        {
            PassGeneratorWindow dash = new PassGeneratorWindow();
            dash.Show();
        }
    }
}
