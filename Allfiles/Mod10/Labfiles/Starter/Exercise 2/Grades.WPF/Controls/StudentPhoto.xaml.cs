using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Grades.WPF
{
    public partial class StudentPhoto : UserControl
    {
        #region Constructor
        public StudentPhoto()
        {
            InitializeComponent();
        }
        #endregion

        #region Storyboard
        public void OnMouseEnter()
        {
            // Trigger the mouse enter animation to grow the size of the photograph currently under the mouse pointer
            (this.Resources["sbMouseEnter"] as Storyboard).Begin();
        }

        public void OnMouseLeave()
        {
            // Trigger the mouse leave animation to shrink the size of the photograph currently under the mouse pointer to return it to its original size
            (this.Resources["sbMouseLeave"] as Storyboard).Begin();
        }
        #endregion
    }
}
