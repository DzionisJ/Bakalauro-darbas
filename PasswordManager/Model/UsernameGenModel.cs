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
