using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Model
{
    class UsernameGenModel : INotifyPropertyChanged
    {
        private string _GenUsername;
        private bool dontUseSpecialChars;
        private bool dontUseUpperCase;
        private bool dontUseLowerCase;
        private bool dontUseDigits;
        private int usrNamelegth;
        private bool noAmobiguossymbols;

        public UsernameGenModel()
        {
        }

        public UsernameGenModel(string GeneratedUsername)
        {
            this._GenUsername = GeneratedUsername;
        }

        public string GenPass
        {
            get { return _GenUsername; }
            set { _GenUsername = value; }
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
        public int UsrNamelegth
        {
            get { return usrNamelegth; }
            set { usrNamelegth = value; }
        }

        public bool NoAmobiguossymbols
        {
            get { return noAmobiguossymbols; }
            set { noAmobiguossymbols = value; }
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
