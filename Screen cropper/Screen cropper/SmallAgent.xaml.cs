using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Screen_cropper
{
    /// <summary>
    /// Interaction logic for SmallAgent.xaml
    /// </summary>
    public partial class SmallAgent : Window
    {
        private SnippedWindow _owner;
        private bool movingAlong;

        private double lastLeft;
        private double lastTop;

        public SmallAgent()
        {
            InitializeComponent();
        }

        public SmallAgent(SnippedWindow owner)
        {
            InitializeComponent();

            this.Topmost = true;
            _owner = owner;
            Tooltipper.Text = _owner.WndName.Text;
            SmallName.Text = _owner.WndName.Text;
        }

        /// <summary>
        /// Closes all windows.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseW(object sender, MouseButtonEventArgs e)
        {
            _owner.Close();
            this.Close();
        }

        private void Revert(object sender, RoutedEventArgs e)
        {
            _owner.DisableAgentMode();
            this.Close();
        }

        private void ToggleTransparency(object sender, RoutedEventArgs e)
        {
            if (_owner.ImageContainer.Opacity == 0.3)
            {
                _owner.CroppedImage.Opacity = 0.92;
                _owner.ImageContainer.Opacity = 0.92;
            }
            else
            {
                _owner.CroppedImage.Opacity = 0.01;
                _owner.ImageContainer.Opacity = 0.3;
            }
            _owner.TransparencyValue.Value = _owner.Opacity;

        }

        private void MoveAlong(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                lastLeft = this.Left;
                lastTop = this.Top;

                movingAlong = true;
                DragMove();
                movingAlong = false;
            }
        }

        private void ClickDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void TestMovingAlong(object sender, EventArgs e)
        {
            if(movingAlong)
            {
                _owner.Left += this.Left - lastLeft;
                _owner.Top += this.Top - lastTop;

                lastLeft = this.Left;
                lastTop = this.Top;
            }
        }
    }
}
