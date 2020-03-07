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
using System.Security.Cryptography;

using System.IO;
using CsvHelper;
using System.Globalization;

namespace PasswordManager.ViewModel
{
    class DataViewModel : INotifyPropertyChanged
    {
        #region variables
        private DataModel stuff = new DataModel();
        private string txtEmail;
        private string txtPass;
        private string txtWebsite;

        public DataModel STUFF //change the name
        {
            get { return stuff; }
            set { stuff = value; NotifyPropertyChanged("STUFF"); }
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

        private ICommand _SubmitCommand;
        private ICommand ExportCSVCommand;
        #endregion
        public ICommand SubmitNewDataCommand
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

        public ICommand SubmitCSVExportCommand
        {
            get
            {
                if (ExportCSVCommand == null)
                {
                    ExportCSVCommand = new RelayCommand(param => this.ExportCSV(), this.CanSubmitExecute);

                }
                return ExportCSVCommand;
            }
        }

        private void SubmitExecute() 
        {
            //function to send data to DB
            sendtoDB();
        }

        //string eencrypt
        public static string EncryptText(string input, string password)
        {
            /*Entered info is sent here with the password as strings*/
            // Getting the bytes of the strings

            byte[] bytesToBeEncrypted = Encoding.UTF8.GetBytes(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Hashing the password with SHA256
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] Encryptedbytes = AES_Encrypt(bytesToBeEncrypted, passwordBytes);

            string resultencrypted = Convert.ToBase64String(Encryptedbytes);

            return resultencrypted;

        }

        public static byte[] AES_Encrypt(byte[] bytesToBeEncrypted, byte[] passwordBytes)
        {
            byte[] encryptedBytes = null;

            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000); //derrives the key
                    AES.Key = key.GetBytes(AES.KeySize / 8);//key for the symetric algorithm
                    AES.IV = key.GetBytes(AES.BlockSize / 8); //initialization vector

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                        cs.Close();
                    }

                    encryptedBytes = ms.ToArray(); // ms = memory stream
                }
            }
            return encryptedBytes;
        }

        public static string DecryptText(string input, string password)
        {
            // Get the bytes of the string
            byte[] bytesToBeDecrypted = Convert.FromBase64String(input);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            passwordBytes = SHA256.Create().ComputeHash(passwordBytes);

            byte[] bytesDecrypted = AES_Decrypt(bytesToBeDecrypted, passwordBytes);

            string result = Encoding.UTF8.GetString(bytesDecrypted);

            return result;
        }

        public static byte[] AES_Decrypt(byte[] bytesToBeDecrypted, byte[] passwordBytes)
        {
            byte[] decryptedBytes = null;

            // Set your salt here, change it to meet your flavor:
            // The salt bytes must be at least 8 bytes.
            byte[] saltBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            using (MemoryStream ms = new MemoryStream())
            {
                using (RijndaelManaged AES = new RijndaelManaged())
                {
                    AES.KeySize = 256;
                    AES.BlockSize = 128;

                    var key = new Rfc2898DeriveBytes(passwordBytes, saltBytes, 1000);
                    AES.Key = key.GetBytes(AES.KeySize / 8);
                    AES.IV = key.GetBytes(AES.BlockSize / 8);

                    AES.Mode = CipherMode.CBC;

                    using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                        cs.Close();
                    }
                    decryptedBytes = ms.ToArray();
                }
            }

            return decryptedBytes;
        }

        private void sendtoDB()
        {
            //Send to DataBase
            SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = master; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            string EncryptionPass = "YB6/**ij";
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                    string query = "INSERT INTO Saugomi_duom.dbo.MainInfo (Email,Password,Website) VALUES (@Email,@Password,@Website)";
                    SqlCommand sqlcommand = new SqlCommand(query, connection);

                    //Encrypt the data before sending to DB
                    sqlcommand.Parameters.AddWithValue("@Email", EncryptText(stuff.AccEmail, EncryptionPass));
                    sqlcommand.Parameters.AddWithValue("@Password", EncryptText(stuff.AccPassword, EncryptionPass));
                    sqlcommand.Parameters.AddWithValue("@Website", EncryptText(stuff.AccWebsite, EncryptionPass));

                    int count = Convert.ToInt32(sqlcommand.ExecuteNonQuery());
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
                connection.Close();
            }
        }


        private ObservableCollection<DataModel> AllLoginDataList = new ObservableCollection<DataModel>();
        public ObservableCollection<DataModel> list
        {
            get { return AllLoginDataList; }
            set
            {
                AllLoginDataList = value;
                NotifyPropertyChanged("list");
            }
        }

        public DataViewModel()
        {
            list = new ObservableCollection<DataModel>();
            SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Saugomi_duom;Integrated Security=True");
            string EncryptionPass = "YB6/**ij";
            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                    string query = "SELECT * FROM MainInfo";
                    SqlCommand sqlcmd = new SqlCommand(query, Connection);
                    using (SqlDataReader dataRead = sqlcmd.ExecuteReader())
                    {
                        if (dataRead != null)
                        {
                            while (dataRead.Read())
                            {
                                string tempEmail; 
                                string tempPassword;
                                string tempWebsite;

                                tempEmail = dataRead["Email"].ToString();
                                tempPassword = dataRead["Password"].ToString();
                                tempWebsite = dataRead["Website"].ToString();
                                 
                                AllLoginDataList.Add(new DataModel(DecryptText(tempEmail, EncryptionPass), DecryptText(tempPassword, EncryptionPass), DecryptText(tempWebsite, EncryptionPass)));
                            }
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
                Connection.Close();
            }
        }

        private void ExportCSV()
        {

            if (MessageBox.Show("Are you sure you wish all of your Login data to be exported to the Desktop?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
               // IF NO = Do nothing
            }
            else
            {
                //If YES = sends all of the stored data to the desktop
                //Perfect if you want to use the same data in a different Password Manager quickly
                string deviceUserName = Environment.UserName;

                using (var writer = new StreamWriter("C:\\Users\\" + deviceUserName + "\\Desktop\\ExportedLoginData.csv"))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(AllLoginDataList);
                    writer.Flush(); //ensure that all the data in the writer's internal buffer has been flushed to the file
                }
            }
           
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

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
