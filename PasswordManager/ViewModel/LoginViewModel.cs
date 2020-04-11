using PasswordManager.Commands;
using PasswordManager.Model;
using PasswordManager.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Security.Cryptography;

namespace PasswordManager.ViewModel
{
    class LoginViewModel : INotifyPropertyChanged
    {
        #region variables

        private LoginDataModel _logmode;
        private string _txtUsername;
        private string _txtPassword;

        public LoginDataModel logmode
        {
            get { return _logmode; }
            set { _logmode = value; } //OnPropertyChanged(AccEmail); }
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

        private ICommand loginCommand;

        #endregion
        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new LoginRelayCommand(param => this.BtnSubmit_Click(), null);

                }
                return loginCommand;
            }
        }

        private void BtnSubmit_Click()
        {
            SqlConnection Conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True");

            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                    string query = "SELECT COUNT(1) FROM LoginPasswordManager WHERE Email=@Email";
                    SqlCommand sqlcmd = new SqlCommand(query, Conn);
                    sqlcmd.Parameters.AddWithValue("@Email", txtUsername);
                   // sqlcmd.Parameters.AddWithValue("@Password",txtPassword);
                    int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                    if (count == 1)
                    {
                        if (PasswordHash.ValidatePassword(txtPassword, getstoredhash()) == true)
                        {
                            MainWindow dashboard = new MainWindow();
                            dashboard.Show();

                            LoginWindow dash = new LoginWindow();
                            dash.Close();
                        }
                        else
                        {
                            MessageBox.Show("Incorrect password");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect");
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

        public string getstoredhash()
        {
            SqlConnection Conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LoginDB;Integrated Security=True");
            string firstVariable = string.Empty;
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                    string query = "SELECT Password FROM LoginPasswordManager WHERE Email=@Email";
                    SqlCommand sqlcmd = new SqlCommand(query, Conn);
                    sqlcmd.Parameters.AddWithValue("@Email", txtUsername);

                    using (SqlDataReader reader = sqlcmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            firstVariable = reader[0].ToString();
                        }
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
            return firstVariable;

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
