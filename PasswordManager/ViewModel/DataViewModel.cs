using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using MySql.Data;
using System.Data;
using System.Windows;
using PasswordManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManager.Commands;

namespace PasswordManager.ViewModel
{
    class DataViewModel : INotifyPropertyChanged
    {

        private DataModel stuff = new DataModel();
        private string txtEmail;
        private string txtPass;
        private string txtWebsite;

        public DataModel STUFF
        {
            get { return stuff; }
            set { stuff = value; }
        }

        public string TXTemail
        {
            get { return txtEmail; }
            set { txtEmail = value; }
        }
        public string TXTpass
        {
            get { return txtPass; }
            set { txtPass = value; }
        }
        public string TXTWebsite
        {
            get { return txtWebsite; }
            set { txtWebsite = value; }
        }

        private ObservableCollection<DataModel> AllLoginInfo = new ObservableCollection<DataModel>();

          public ObservableCollection<DataModel> LoginInfo
           {
               get { return AllLoginInfo; }
               set
               {
                   AllLoginInfo = value;
                   NOtifyPropertyChanged("DataModel");
               }
           }

        private ICommand _SubmitCommand;

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                }
                return _SubmitCommand;
            }
        }

        private void SubmitExecute(object parameter)
        {
            LoginInfo.Add(stuff);
        }

        private bool CanSubmitExecute(object parameter)//checks if any textboxes are empty
        {
            if (string.IsNullOrEmpty(stuff.AccEmail) || string.IsNullOrEmpty(stuff.AccPassword) || string.IsNullOrEmpty(stuff.AccWebsite))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NOtifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
