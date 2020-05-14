using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PasswordManager.Commands;
using PasswordManager.Model;

namespace PasswordManager.ViewModel
{
    class PassGeneratorViewModel : INotifyPropertyChanged
    {
        #region variables
        private ICommand _SubmitCommand2;

        private UsernameGenDataModel _test = new UsernameGenDataModel();
        private string txtpas;
        private bool cannotUseSpecial;
        private bool cannotUseUpper;
        private bool cannotUseLower;
        private bool cannotUseDigit;
        private int passlegth;


        public event PropertyChangedEventHandler PropertyChanged;

        public UsernameGenDataModel test 
        {
            get { return _test; }
            set { _test = value;}
        }
        public string Password
        {
            get { return txtpas; }
            set { txtpas = value; NotifyPropertyChanged("Password"); }
        }
        public bool CanUseSpecial
        {
            get { return cannotUseSpecial; }
            set { cannotUseSpecial = value; NotifyPropertyChanged("CanUseSpecial"); }
        }

        public bool CanUseUpper
        {
            get { return cannotUseUpper; }
            set { cannotUseUpper = value; NotifyPropertyChanged("CanUseUpper"); }
        }
        public bool CanUseLower
        {
            get { return cannotUseLower; }
            set { cannotUseLower = value; NotifyPropertyChanged("CanUseLower"); }
        }
        public bool CanUseDigit
        {
            get { return cannotUseDigit; }
            set { cannotUseDigit = value; NotifyPropertyChanged("CanUseDigit"); }
        }

        public int Passlegth
        {
            get { return passlegth; }
            set { passlegth = value; NotifyPropertyChanged("Passlegth"); }
        }
        #endregion
        public PassGeneratorViewModel()
        {
            
        }
        public string genPas()
        {
            
            string AllUsable_Symbols = "QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
            string Usable_Symbols_NoSpecial = "QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz0123456789";
            string Usable_Symbols_NoSpecialordigit = "QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz";
            string Usable_Symbols_NoSpecialLowercase = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789";
            string Usable_Symbols_NoSpecialUpperCase = "abcdefghijklmnopqrstuvwxyz0123456789";
            string nospecilaslowerdigit = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string nospecilaslupperdigit = "abcdefghijklmnopqrstuvwxyz";
            string nospecialslowerupper = "0123456789";
            string nodigitslowerupper = "!@#$%^&*?";
            string Usable_Symbols_NoUpperCase = "abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?";
            string Usable_Symbols_NoLowerCase = "QWERTYUIOPASDFGHJKLZXCVBNM0123456789!@#$%^&*?";
            string AllUsable_NoDigits = "QWERTYUIOPASDFGHJKLZXCVBNMabcdefghijklmnopqrstuvwxyz!@#$%^&*?";
            string AllUsable_NoDigitsLower = "QWERTYUIOPASDFGHJKLZXCVBNM!@#$%^&*?";
            string AllUsable_NoDigitsUpper = "abcdefghijklmnopqrstuvwxyz!@#$%^&*?";
            string WithoutLowerorupper = "0123456789!@#$%^&*?";

            if (Passlegth <= 0)
            {
                Passlegth = 6;
            }
            if (Passlegth > 30)
            {
                MessageBox.Show("Password cannot exeed 30 characters!");
                Passlegth = 30;
            }


            Random rnd = new Random();

            char[] chars = new char[30];

            //Symbols only without special chars
            if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == false && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecial[rnd.Next(0, Usable_Symbols_NoSpecial.Length)];
                }
            }
            //Symbols only without digits
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == false && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = AllUsable_NoDigits[rnd.Next(0, AllUsable_NoDigits.Length)];
                }
            }
            //Symbols only without Lower case letters
            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == true && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = Usable_Symbols_NoLowerCase[rnd.Next(0, Usable_Symbols_NoLowerCase.Length)];
                }
            }
            //Symbols only without Upper case letters
            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == false && CanUseUpper == true)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = Usable_Symbols_NoUpperCase[rnd.Next(0, Usable_Symbols_NoUpperCase.Length)];
                }
            }

            // symbols witout speclials and digits
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == false && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecialordigit[rnd.Next(0, Usable_Symbols_NoSpecialordigit.Length)];
                }
            }
            // symbols witout speclials and lower case
            else if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == true && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecialLowercase[rnd.Next(0, Usable_Symbols_NoSpecialLowercase.Length)];
                }
            }
            // symbols witout speclials and uppercase
            else if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == false && CanUseUpper == true)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecialUpperCase[rnd.Next(0, Usable_Symbols_NoSpecialUpperCase.Length)];
                }
            }

            // symbols witout digits and lower
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == true && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = AllUsable_NoDigitsLower[rnd.Next(0, AllUsable_NoDigitsLower.Length)];
                }
            }
            // symbols witout digits and lower
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == false && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = AllUsable_NoDigitsLower[rnd.Next(0, AllUsable_NoDigitsLower.Length)];
                }
            }
            // symbols witout digits and upper
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == false && CanUseUpper == true)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = AllUsable_NoDigitsUpper[rnd.Next(0, AllUsable_NoDigitsUpper.Length)];
                }
            }

            // symbols witout lower or upper
            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == true && CanUseUpper == true)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = WithoutLowerorupper[rnd.Next(0, WithoutLowerorupper.Length)];
                }
            }


            // symbols witout specials, digits or lower
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == true && CanUseUpper == false)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = nospecilaslowerdigit[rnd.Next(0, nospecilaslowerdigit.Length)];
                }
            }
            // symbols witout specials, digits or upper
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == false && CanUseUpper == true)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = nospecilaslupperdigit[rnd.Next(0, nospecilaslupperdigit.Length)];
                }
            }
            // symbols witout specials, lower or upper
            else if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == true && CanUseUpper == true)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = nospecialslowerupper[rnd.Next(0, nospecialslowerupper.Length)];
                }
            }
            // symbols witout digits, lower or upper
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == true && CanUseUpper == true)
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = nodigitslowerupper[rnd.Next(0, nodigitslowerupper.Length)];
                }
            }
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == true && CanUseUpper == true)
            {
                MessageBox.Show("Make sure to leave at least one checkbox open!");
            }
            // All symbols used
            else
            {
                for (int i = 0; i < Passlegth; i++)
                {
                    chars[i] = AllUsable_Symbols[rnd.Next(0, AllUsable_Symbols.Length)];
                }
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
