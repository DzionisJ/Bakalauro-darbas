using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Model
{
    class SignUpDataModel : INotifyPropertyChanged
    {

        private string _Username;
        private string _Password;

        public string UserName
        {
            get { return _Username; }
            set { _Username = value; } //OnPropertyChanged(AccEmail); }
        }

        public string PassWord
        {
            get { return _Password; }
            set { _Password = value; } //OnPropertyChanged(AccEmail); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string p)
        {
            PropertyChangedEventHandler ph = PropertyChanged;

            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(p));
            }
        }
    }
}
