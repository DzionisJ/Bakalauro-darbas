using PasswordManager.Commands;
using PasswordManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.ViewModel
{
    class UserNameGenViewModel : INotifyPropertyChanged
    {

        private ICommand _submitnewusernamecommand;

        private UsernameGenModel username = new UsernameGenModel();
        private string txtusername;

        public UsernameGenModel User
        {
            get { return username; }
            set { username = value; }
        }
        public string Username
        {
            get { return txtusername; }
            set { txtusername = value; NotifyPropertyChanged("Username"); }
        }
 
        public string genUser()
        {

            string Usable_Symbols = "QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz0123456789";
            Random rnd = new Random();

            char[] chars = new char[20];
            for (int i = 0; i < 20; i++)
            {
                chars[i] = Usable_Symbols[rnd.Next(0, Usable_Symbols.Length)];
            }
            string Generated_pass = new string(chars);

            return Username = Generated_pass;
        }

        public ICommand SubmitNewUsername
        {
            get
            {
                if (_submitnewusernamecommand == null)
                {
                    _submitnewusernamecommand = new RelayCommand(param => this.SubmitExecutetest(), this.CanSubmitExecute);

                }
                return _submitnewusernamecommand;
            }
        }

        private void SubmitExecutetest()
        {
            genUser();
        }

        private bool CanSubmitExecute(object parameter)//checks if any textboxes are empty need to rid of it
        {
            if (string.IsNullOrEmpty(Username))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
