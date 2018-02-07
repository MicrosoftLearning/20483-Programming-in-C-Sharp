using System.Reflection;
using System.Windows;
using FourthCoffee.Core.CustomAttributes;
using Microsoft.Win32;
using System.Linq;
using FourthCoffee.Core;
using System;

namespace FourthCoffee.MetaDataExtractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ExtractAssemblyAttributes();
                load.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fatal Error");
            }
        }

        private void ExtractAssemblyAttributes()
        {
            var type = typeof(Encryptor);

            // TODO: 01: Invoke the Type.GetCustomAttribute method.
            

            results.Items.Add(this.FormatComment(typeAttribute, type.Name, "Type"));

            foreach (var member in type.GetMembers())
            {
                // TODO: 02: Invoke the MemberInfo.GetCustomAttribute method.
                

                results.Items.Add(this.FormatComment(memberAttribute, member.Name, member.MemberType.ToString()));
            }
        }

        private string FormatComment(DeveloperInfo attribute, string codeElement, string elementType)
        {
            if (attribute == null)
            {
                return string.Format(
                    "{0}: {1}, No DeveloperInfo attribute",
                    elementType,
                    codeElement);
            }
            else
            {
                return string.Format(
                 "{0}: {1}, Developed By: {2}, Revision: {3}",
                 elementType,
                 codeElement,
                 attribute.EmailAddress,
                 attribute.Revision);
            }
        }
    }
}
