using System;
using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;

namespace FourthCoffee.MessageSafe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        const string _messageFileName = "protected_message.txt";

        Encryptor _encryptor;
        FileInfo _protectedFile;
        bool _isMessageLoaded;

        public MainWindow()
        {
            InitializeComponent();

            this._encryptor = new Encryptor("74519A8D-1519-4E14-A66A-9F9F9BE95860");
            this._protectedFile = new FileInfo(GetPathToProtectedMessageFile());

            this._isMessageLoaded = !this._protectedFile.Exists;
            this.ResetUI();

            this.status.Content = "Ready....";
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            this.SaveMessage();

            this.status.Content = "Message saved..";
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            bool loadSuccessful = false;

            try
            {
                if (string.IsNullOrEmpty(this.password.Password))
                {
                    this.status.Content = "Load unsuccessful. You must provide a password...";
                }
                else
                {
                    this.LoadMessage();
                    loadSuccessful = true;
                }
            }
            catch
            {
                this.status.Content = "Load unsuccessful. Please ensure you provide the correct password...";
            }

            if (loadSuccessful)
            {
                this._isMessageLoaded = true;
                this.ResetUI();
                this.status.Content = "Message loaded...";
            }
        }

        private static string GetPathToProtectedMessageFile()
        {
            var dataDirectory = ConfigurationManager.AppSettings["EncryptedFilePath"];

            var pathToProtectedFile
                = System.IO.Path.Combine(
                    dataDirectory,
                    _messageFileName);

            return pathToProtectedFile;
        }

        private void LoadMessage()
        {
            if (!this._protectedFile.Exists)
                return;

            var encryptedBytes = File.ReadAllBytes(_protectedFile.FullName);

            var decryptedBytes = this._encryptor.Decrypt(encryptedBytes, this.password.Password);

            var decryptedText = Encoding.Default.GetString(decryptedBytes);

            this.messageText.Text = decryptedText;
        }

        private void SaveMessage()
        {
            var decryptedBytes = Encoding.Default.GetBytes(this.messageText.Text);

            var encryptedBytes = this._encryptor.Encrypt(decryptedBytes, this.password.Password);

            File.WriteAllBytes(this._protectedFile.FullName, encryptedBytes);
        }

        private void ResetUI()
        {
            if (this._isMessageLoaded)
            {
                this.save.IsEnabled = true;
                this.messageText.IsEnabled = true;
                this.load.IsEnabled = false;

            }
            else
            {
                this.save.IsEnabled = false;
                this.messageText.IsEnabled = false;
                this.load.IsEnabled = true;
            }
        }

        #region IDisposable Members

        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                this._protectedFile = null;
                                
                if (this._encryptor != null)
                {
                    this._encryptor.Dispose();
                }
            }

        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
