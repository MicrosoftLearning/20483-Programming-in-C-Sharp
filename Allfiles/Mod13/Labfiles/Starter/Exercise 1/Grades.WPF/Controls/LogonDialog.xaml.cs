using System;
using System.Windows;
using System.Web.ClientServices.Providers;

namespace WoodgroveGradesWPF
{
    /// <summary>
    /// Interaction logic for LoginDialog.xaml
    /// </summary>
    public partial class LoginDialog : Window, IClientFormsAuthenticationCredentialsProvider
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        public ClientFormsAuthenticationCredentials GetCredentials()
        {
            if (this.ShowDialog() == true)
            {
                if (username.Text == String.Empty && password.Password == String.Empty)
                    return null;

                return new ClientFormsAuthenticationCredentials(username.Text, password.Password, true);
            }
            else
            {
                return null;
            }
        }
    }

}
