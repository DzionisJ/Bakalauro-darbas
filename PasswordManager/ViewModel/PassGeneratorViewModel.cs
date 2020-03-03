using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PasswordManager.Commands;
using PasswordManager.Model;

namespace PasswordManager.ViewModel
{
    class PassGeneratorViewModel
    {

        private ICommand _SubmitCommand;

        private PasswordGenDataModel _test = new PasswordGenDataModel();
        private string txtEmail;

        public PasswordGenDataModel test //change the name
        {
            get { return _test; }
            set { _test = value;}
        }
        public string TXTemail
        {
            get { return txtEmail; }
            set { txtEmail = value; }
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
            return new string(chars);


            // AllLoginDataList.Add(new DataModel(DecryptText(tempEmail, "a"), DecryptText(tempPassword, "a"), DecryptText(tempWebsite, "a")));
        }

        public ICommand SubmitNewpass
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.SubmitExecutetest(), this.CanSubmitExecute);

                }
                return _SubmitCommand;
            }
        }

        private void SubmitExecutetest()
        {
            genPas();
        }

        private bool CanSubmitExecute(object parameter)//checks if any textboxes are empty
        {
            if (string.IsNullOrEmpty(TXTemail))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
