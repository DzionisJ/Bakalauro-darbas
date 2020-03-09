using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordManager.ViewModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager.View
{
    /// <summary>
    /// Interaction logic for UserNameGeneratorWindow.xaml
    /// </summary>
    public partial class UserNameGeneratorWindow : Window
    {
        public UserNameGeneratorWindow()
        {
            InitializeComponent();
            this.DataContext = new UserNameGenViewModel();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
    }
}
