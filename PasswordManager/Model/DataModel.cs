﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PasswordManager.Model
{
    class DataModel : INotifyPropertyChanged
    {
        private string Email;
        private string Password;
        private string Website;

        public DataModel()
        {
        }

        public DataModel(string Email, string Password, string Website)
        {
            this.Email = Email;
            this.Password = Password;
            this.Website = Website;
        }

        public string AccEmail
        {
            get {return Email; }
            set { Email = value;
                OnPropertyChanged(AccEmail); }
        }
        public string AccPassword
        {
            get { return Password; }
            set { Password = value;
                OnPropertyChanged(AccPassword); }
        }
        public string AccWebsite
        {
            get { return Website; }
            set { Website = value;
                OnPropertyChanged(AccWebsite); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }
    }
}
