using System;
using System.Windows;

namespace Fourth_Coffee_Contact_Finder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SalesDataLoader _dataLoader;

        public MainWindow()
        {
            InitializeComponent();
            this._dataLoader = new SalesDataLoader(
                new Uri("http://localhost:8090/SalesService.svc/GetSalesPerson"));
        }

        private void go_Click(object sender, RoutedEventArgs e)
        {
            var result = this._dataLoader.GetPersonByEmail(searchName.Text);

            if (result == null)
            {
                MessageBox.Show("Could not find a record.", "Search Failed", MessageBoxButton.OK);
            }
            else
            {
                this.name.Content = string.Format("{0} {1}", result.FirstName, result.Surname);
                this.area.Content = result.Area;
                this.emailAddress.Content = result.EmailAddress;


                MessageBox.Show("Record loaded.", "Search Successful", MessageBoxButton.OK);
            }
        }
    }
}
