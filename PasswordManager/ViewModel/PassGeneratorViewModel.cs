using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PasswordManager.Commands;
using PasswordManager.Model;

namespace PasswordManager.ViewModel
{
    class PassGeneratorViewModel : INotifyPropertyChanged
    {

        private ICommand _SubmitCommand2;

        private PasswordGenDataModel _test = new PasswordGenDataModel();
        private string txtpas;

        public event PropertyChangedEventHandler PropertyChanged;

        public PasswordGenDataModel test 
        {
            get { return _test; }
            set { _test = value;}
        }
        public string Password
        {
            get { return txtpas; }
            set { txtpas = value; NotifyPropertyChanged("Password"); }
        }

        public PassGeneratorViewModel()
        {
            
        }
        public string genPas()
        {
            
            string Usable_Symbols = "QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
            Random rnd = new Random();

            char[] chars = new char[20];
            for (int i = 0; i < 20; i++)
            {
                chars[i] = Usable_Symbols[rnd.Next(0, Usable_Symbols.Length)];
            }
            string Generated_pass = new string(chars);

            return Password = Generated_pass;
        }

        public ICommand SubmitNewpass
        {
            get
            {
                if (_SubmitCommand2 == null)
                {
                    _SubmitCommand2 = new RelayCommand(param => this.SubmitExecutetest(), this.CanSubmitExecute);

                }
                return _SubmitCommand2;
            }
        }

        private void SubmitExecutetest()
        {
            genPas();
        }

        private bool CanSubmitExecute(object parameter)//checks if any textboxes are empty need to rid of it
        {
            if (string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
