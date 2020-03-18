using PasswordManager.Commands;
using PasswordManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordManager.ViewModel
{
    class UserNameGenViewModel : INotifyPropertyChanged
    {

        private ICommand _submitnewusernamecommand;

        #region variables
        private UsernameGenModel username = new UsernameGenModel();
        private string txtusername;
        private bool cannotUseSpecial;
        private bool cannotUseUpper;
        private bool cannotUseLower;
        private bool cannotUseDigit;
        private int urNameLegth;
        private bool noAmobiguossymbols;

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

        public bool NoAmobiguossymbols
        {
            get { return noAmobiguossymbols; }
            set { noAmobiguossymbols = value; NotifyPropertyChanged("NoAmobiguossymbols"); }
        }

        public int UsrNameLegth
        {
            get { return urNameLegth; }
            set { urNameLegth = value; NotifyPropertyChanged("UsrNameLegth"); }
        }

        #endregion

        public string genUser()
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

            string noambiguossymbols = "QWERTYUPASDFGHJKLZXCVBNMabcdefghijkmnopqrstuvwxyz23456789!@#$%^&*?";
            string Usable_Symbols_NoSpecialandambiguos = "QWERTYUPASDFGHJKLZXCVBNMabcdefghijkmnopqrstuvwxyz23456789";
            string Usable_Symbols_Nodigirsambiguos = "QWERTYUPASDFGHJKLZXCVBNMabcdefghijkmnpqrstuvwxyz!@#$%^&*?";
            string AllUsable_NoDigitsLowerambiguous = "QWERTYUPASDFGHJKLZXCVBNM!@#$%^&*?";
            string Usable_Symbols_Nolowerambiguos = "QWERTYUPASDFGHJKLZXCVBNM23456789!@#$%^&*?";
            string nodigitsupperambiguous = "abcdefghijkmnpqrstuvwxyz!@#$%^&*?";
            string lowerupperambi = "23456789!@#$%^&*?";




            if (UsrNameLegth <= 0)
            {
                UsrNameLegth = 6;
            }
            if (UsrNameLegth > 50)
            {
                MessageBox.Show("Username cannot exeed 50 characters!");
                UsrNameLegth = 50;
            }


            Random rnd = new Random();

            char[] chars = new char[50];

            //Symbols only without special chars
            if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == false && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecial[rnd.Next(0, Usable_Symbols_NoSpecial.Length)];
                }
            }

            //Symbols only without I,1,l,0,O
            if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == false && CanUseUpper == false && NoAmobiguossymbols == true)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = noambiguossymbols[rnd.Next(0, noambiguossymbols.Length)];
                }
            }

            //Symbols only without digits
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == false && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = AllUsable_NoDigits[rnd.Next(0, AllUsable_NoDigits.Length)];
                }
            }
            //Symbols only without Lower case letters 
            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == true && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_NoLowerCase[rnd.Next(0, Usable_Symbols_NoLowerCase.Length)];
                }
            }
            //Symbols only without Upper case letters
            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == false && CanUseUpper == true && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_NoUpperCase[rnd.Next(0, Usable_Symbols_NoUpperCase.Length)];
                }
            }

            // symbols witout speclials and digits
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == false && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecialordigit[rnd.Next(0, Usable_Symbols_NoSpecialordigit.Length)];
                }
            }

            // symbols witout speclials and  I,1,l,0,O
            else if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == false && CanUseUpper == false && NoAmobiguossymbols == true)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecialandambiguos[rnd.Next(0, Usable_Symbols_NoSpecialandambiguos.Length)];
                }
            }

            // symbols witout speclials and lower case
            else if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == true && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecialLowercase[rnd.Next(0, Usable_Symbols_NoSpecialLowercase.Length)];
                }
            }
            // symbols witout speclials and uppercase
            else if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == false && CanUseUpper == true && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_NoSpecialUpperCase[rnd.Next(0, Usable_Symbols_NoSpecialUpperCase.Length)];
                }
            }

            // symbols witout digits and lower
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == true && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = AllUsable_NoDigitsLower[rnd.Next(0, AllUsable_NoDigitsLower.Length)];
                }
            }
            // symbols witout digits and lower
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == false && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = AllUsable_NoDigitsLower[rnd.Next(0, AllUsable_NoDigitsLower.Length)];
                }
            }
            // symbols witout digits and upper
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == false && CanUseUpper == true && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = AllUsable_NoDigitsUpper[rnd.Next(0, AllUsable_NoDigitsUpper.Length)];
                }
            }

            // symbols witout digits and I,1,l,0,O
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == false && CanUseUpper == false && NoAmobiguossymbols == true)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_Nodigirsambiguos[rnd.Next(0, Usable_Symbols_Nodigirsambiguos.Length)];
                }
            }

            // symbols witout lower or upper
            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == true && CanUseUpper == true && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = WithoutLowerorupper[rnd.Next(0, WithoutLowerorupper.Length)];
                }
            }
            // symbols witout lower or  I,1,l,0,O

            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == true && CanUseUpper == false && NoAmobiguossymbols == true)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = Usable_Symbols_Nolowerambiguos[rnd.Next(0, Usable_Symbols_Nolowerambiguos.Length)];
                }
            }

            // symbols witout specials, digits or lower
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == true && CanUseUpper == false && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = nospecilaslowerdigit[rnd.Next(0, nospecilaslowerdigit.Length)];
                }
            }
            // symbols witout specials, digits or upper
            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == false && CanUseUpper == true && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = nospecilaslupperdigit[rnd.Next(0, nospecilaslupperdigit.Length)];
                }
            }
            // symbols witout specials, lower or upper
            else if (CanUseSpecial == true && CanUseDigit == false && CanUseLower == true && CanUseUpper == true && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = nospecialslowerupper[rnd.Next(0, nospecialslowerupper.Length)];
                }
            }
            // symbols witout digits, lower or upper
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == true && CanUseUpper == true && NoAmobiguossymbols == false)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = nodigitslowerupper[rnd.Next(0, nodigitslowerupper.Length)];
                }
            }
            // symbols witout digits, lower or  I,1,l,0,O
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == true && CanUseUpper == false && NoAmobiguossymbols == true)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                   chars[i] = AllUsable_NoDigitsLowerambiguous[rnd.Next(0, AllUsable_NoDigitsLowerambiguous.Length)];
                }
            }

            // symbols witout digits, upper or  I,1,l,0,O
            else if (CanUseSpecial == false && CanUseDigit == true && CanUseLower == false && CanUseUpper == true && NoAmobiguossymbols == true)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                      chars[i] = nodigitsupperambiguous[rnd.Next(0, nodigitsupperambiguous.Length)];
                }
            }

            // symbols witout lower, upper or  I,1,l,0,O
            else if (CanUseSpecial == false && CanUseDigit == false && CanUseLower == true && CanUseUpper == true && NoAmobiguossymbols == true)
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                      chars[i] = lowerupperambi[rnd.Next(0, lowerupperambi.Length)];
                }
            }     

            else if (CanUseSpecial == true && CanUseDigit == true && CanUseLower == true && CanUseUpper == true && NoAmobiguossymbols == true)
            {
                MessageBox.Show("Make sure to leave at least one checkbox open!");
            }
            // All symbols used
            else
            {
                for (int i = 0; i < UsrNameLegth; i++)
                {
                    chars[i] = AllUsable_Symbols[rnd.Next(0, AllUsable_Symbols.Length)];
                }
            }

            string Generated_username = new string(chars);

            return Username = Generated_username;
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
