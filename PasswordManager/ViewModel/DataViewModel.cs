using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using MySql.Data;
using System.Data;
using System.Windows;
using PasswordManager.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using PasswordManager.Commands;

namespace PasswordManager.ViewModel
{
    class DataViewModel : INotifyPropertyChanged
    {

        private DataModel stuff = new DataModel();
        private string txtEmail;
        private string txtPass;
        private string txtWebsite;

        public DataModel STUFF
        {
            get { return stuff; }
            set { stuff = value; }
        }
        public string TXTemail
        {
            get { return txtEmail; }
            set { txtEmail = value; }
        }
        public string TXTpass
        {
            get { return txtPass; }
            set { txtPass = value; }
        }
        public string TXTWebsite
        {
            get { return txtWebsite; }
            set { txtWebsite = value; }
        }

        private ObservableCollection<DataModel> AllLoginInfo = new ObservableCollection<DataModel>();

          public ObservableCollection<DataModel> LoginInfo
           {
               get { return AllLoginInfo; }
               set
               {
                   AllLoginInfo = value;
                   NOtifyPropertyChanged("DataModel");
               }
           }

        private ICommand _SubmitCommand;

        public ICommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new RelayCommand(param => this.SubmitExecute(), this.CanSubmitExecute);

                }
                return _SubmitCommand;
            }
        }

        private void SubmitExecute()
        {
            //Send to DataBase
            SqlConnection conn = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    string query = "INSERT INTO Saugomi_duom.dbo.MainInfo (Email,Password,Website) VALUES (@Email,@Password,@Website)";
                    SqlCommand sqlcmd = new SqlCommand(query, conn);
                    sqlcmd.Parameters.AddWithValue("@Email", stuff.AccEmail);
                    sqlcmd.Parameters.AddWithValue("@Password", stuff.AccPassword);
                    sqlcmd.Parameters.AddWithValue("@Website", stuff.AccWebsite);

                    int count = Convert.ToInt32(sqlcmd.ExecuteNonQuery());
                    if (count == 1)
                    {
                        MessageBox.Show("Data added");                     
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
                conn.Close();
            }

            //  LoginInfo.Add(stuff);
        }

        private bool CanSubmitExecute(object parameter)//checks if any textboxes are empty
        {
            if (string.IsNullOrEmpty(TXTemail) || string.IsNullOrEmpty(TXTpass) || string.IsNullOrEmpty(TXTWebsite))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NOtifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
