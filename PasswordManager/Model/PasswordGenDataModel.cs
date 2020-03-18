using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Model
{
    class UsernameGenDataModel : INotifyPropertyChanged
    {

        private string _GenPass;
        private bool dontUseSpecialChars;
        private bool dontUseUpperCase;
        private bool dontUseLowerCase;
        private bool dontUseDigits;
        private int passlegth;

        public UsernameGenDataModel()
        {
        }

        public UsernameGenDataModel(string GeneratedPass)
        {
            this._GenPass = GeneratedPass;
        }

        public string GenPass
        {
            get { return _GenPass; }
            set { _GenPass = value; }
        }
        public bool DontUseSpecialChars
        {
            get { return dontUseSpecialChars; }
            set { dontUseSpecialChars = value; }
        }

        public bool DontUseUpperCase
        {
            get { return dontUseUpperCase; }
            set { dontUseUpperCase = value; }
        }
        public bool DontUseLowerCase
        {
            get { return dontUseLowerCase; }
            set { dontUseLowerCase = value; }
        }
        public bool DontUseDigits
        {
            get { return dontUseDigits; }
            set { dontUseDigits = value; }
        }
        public int Passlegth
        {
            get { return passlegth; }
            set { passlegth = value; }
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
