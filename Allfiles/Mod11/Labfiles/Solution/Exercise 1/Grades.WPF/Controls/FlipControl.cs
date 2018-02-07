using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Grades.WPF
{
    public class FlipControl : Control
    {
        #region Data Members
        private bool _isFront = true;
        #endregion

        #region Event Members
        public event EventHandler FlipComplete;
        #endregion

        #region Properties
        public bool IsFacingFront
        {
            get { return _isFront; }
        }

        public UIElement FrontContent
        {
            get { return (UIElement)GetValue(FrontContentProperty); }
            set { SetValue(FrontContentProperty, value); }
        }

        public UIElement BackContent
        {
            get { return (UIElement)GetValue(BackContentProperty); }
            set { SetValue(BackContentProperty, value); }
        }

        public static readonly DependencyProperty FrontContentProperty =
            DependencyProperty.Register("FrontContent", typeof(UIElement), typeof(FlipControl), new PropertyMetadata(null));

        public static readonly DependencyProperty BackContentProperty =
            DependencyProperty.Register("BackContent", typeof(UIElement), typeof(FlipControl), new PropertyMetadata(null));
        #endregion

        #region Constructor
        public FlipControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipControl), new FrameworkPropertyMetadata(typeof(FlipControl))); 
        }
        #endregion

        #region Template
        public override void OnApplyTemplate()
        {
            ScaleTransform st = GetTemplateChild("PART_BackScale") as ScaleTransform;
            st.ScaleX = -1;
            st.ScaleY = 1;           

            base.OnApplyTemplate();
        }
        #endregion

        #region Events
        void mainGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Flip();
        }

        private void Flip_Complete(object sender, EventArgs e)
        {
            if (FlipComplete != null)
                FlipComplete(sender, e);
        }
        #endregion
        
        #region Flip
        public void Flip()
        {
            if (_isFront)
                VisualStateManager.GoToState(this, "FlipToBack", true);
            else
                VisualStateManager.GoToState(this, "FlipToFront", true);

            _isFront = !_isFront;
        }

        public void ToFront()
        {
            if (_isFront)
                return;

            Flip();
        }

        public void ToBack()
        {
            if (!_isFront)
                return;

            Flip();
        }
        #endregion

    }
}