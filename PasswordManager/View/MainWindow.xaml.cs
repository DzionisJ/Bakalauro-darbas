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
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            this.DataContext = new DataViewModel();

        }

        private void Password_Generator_Click(object sender, RoutedEventArgs e)
        {
            PassGeneratorWindow dash = new PassGeneratorWindow();
            dash.Show();
        }

        private void Username_generator_Click(object sender, RoutedEventArgs e)
        {
            UserNameGeneratorWindow dash = new UserNameGeneratorWindow();
            dash.Show();
        }

        int a = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button currentButton = sender as Button;

            if (a == 0)
            {
                passcollumn.FontFamily = new FontFamily("Comic Sans MS");
                a = 1;
            }
            else if (a == 1)
            {
                passcollumn.FontFamily = new FontFamily ("pack://application:,,,/Resources/#password");
                a = 0;

            }
        }
    }
}
