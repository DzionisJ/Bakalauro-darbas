using PasswordManager.Model;
using PasswordManager.ViewModel;
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

namespace PasswordManager.View
{
    /// <summary>
    /// Interaction logic for PassGeneratorWindow.xaml
    /// </summary>
    public partial class PassGeneratorWindow : Window
    {
        public PassGeneratorWindow()
        {
            InitializeComponent();
            this.DataContext = new PassGeneratorViewModel();

           // DataContext = new 
        }
    }
}
