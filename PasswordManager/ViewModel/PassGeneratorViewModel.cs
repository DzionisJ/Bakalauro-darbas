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

        public PasswordGenDataModel test //change the name
        {
            get { return _test; }
            set { _test = value;}
        }
        public string passssss
        {
            get { return txtpas; }
            set { txtpas = value; NotifyPropertyChanged("passssss"); }
        }

        public PassGeneratorViewModel()
        {

        }
        public string genPas()
        {
            /*string[] symmbols = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "Y", "W", "X", "Z",
                                  "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","x","y","z","w",
                                   "1","2","3","4","5","6","7","8","9"};*/

            string symmbols = "QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
            Random rnd = new Random();

            char[] chars = new char[12];
            for (int i = 0; i < 12; i++)
            {
                chars[i] = symmbols[rnd.Next(0, symmbols.Length)];
            }
            //  return new string(chars);
            return passssss = "utycyrx";//chars.ToString();

            // AllLoginDataList.Add(new DataModel(DecryptText(tempEmail, "a"), DecryptText(tempPassword, "a"), DecryptText(tempWebsite, "a")));
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

        private bool CanSubmitExecute(object parameter)//checks if any textboxes are empty
        {
            if (string.IsNullOrEmpty(passssss))
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
