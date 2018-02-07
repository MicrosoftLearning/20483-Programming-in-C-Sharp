using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Grades.WPF
{
    public partial class GrungeButton : ContentControl
    {
        #region Data Members
        public event RoutedEventHandler Click;
        #endregion Data Members

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #region Constructor
        public GrungeButton()
        {
            InitializeComponent();
            this.MouseLeftButtonUp += new MouseButtonEventHandler(GrungeButton_MouseLeftButtonUp);
        }
        #endregion Constructor

        #region VSM Events
        void GrungeButton_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (Click != null)
                Click(this, new RoutedEventArgs());
        }
        #endregion VSM Events
    }
}
