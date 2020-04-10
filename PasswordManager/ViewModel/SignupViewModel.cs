using PasswordManager.Commands;
using PasswordManager.Model;
using PasswordManager.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordManager.ViewModel
{
    class SignupViewModel : INotifyPropertyChanged
    {

        #region variables

        private SignUpDataModel _signmode;
        private string _txtUsername;
        private string _txtPassword;

        public SignUpDataModel signmode
        {
            get { return _signmode; }
            set { _signmode = value; } //OnPropertyChanged(AccEmail); }
        }

        public string txtUsername
        {
            get { return _txtUsername; }
            set { _txtUsername = value; } //OnPropertyChanged(AccEmail); }
        }

        public string txtPassword
        {
            get { return _txtPassword; }
            set { _txtPassword = value; } //OnPropertyChanged(AccEmail); }
        }

        private ICommand signupCommand;

        #endregion

        public ICommand SignupCommand
        {
            get
            {
                if (signupCommand == null)
                {
                    signupCommand = new LoginRelayCommand(param => this.BtnSubmit_Click(), null);

                }
                return signupCommand;
            }
        }

        /* private static byte[] PassHashwithPBKDF2(string txtPassword)
         {
             const int salt_size = 24; //this size would be in bytes
             const int hash_size = 24;
             const int PBKDF2_Iterations = 100000;

             //making of the salt
             RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
             byte[] salt = new byte[salt_size];
             provider.GetBytes(salt);

             //making of the hash
             Rfc2898DeriveBytes PBKDF2 = new Rfc2898DeriveBytes(txtPassword, salt, PBKDF2_Iterations);
             return PBKDF2.GetBytes(hash_size);
         }
         */


        private void BtnSubmit_Click()
        {
            SqlConnection Conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True");

            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                    string query = "INSERT INTO LoginPasswordManager (Email, Password) VALUES (@Email, @Password)";
                    SqlCommand sqlcmd = new SqlCommand(query, Conn);
                    sqlcmd.Parameters.AddWithValue("@Email", txtUsername);
                    sqlcmd.Parameters.AddWithValue("@Password", PasswordHash.HashPassword(txtPassword));
                    int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                    if (count == 1)
                    {
                        MessageBox.Show("Das");
                        LoginWindow dashboard = new LoginWindow();
                        dashboard.Show();

                        SignUpWindow dash = new SignUpWindow();
                        dash.Close();
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                Conn.Close();
            }

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
