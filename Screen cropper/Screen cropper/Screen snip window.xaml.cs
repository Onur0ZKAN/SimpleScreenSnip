using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Screen_cropper
{
    /// <summary>
    /// Interaction logic for Screen_snip_window.xaml
    /// </summary>
    public partial class Screen_snip_window : Window
    {
        public double left, top, right, bottom;
        public bool positiveSnip;

        double beginX, beginY, endX, endY;
        bool mouseMoveUpdate;
        bool moveStarted;
        public double exitMousePositionX, exitMousePositionY;



        public Screen_snip_window()
        {
            InitializeComponent();
            mouseMoveUpdate = false;
            positiveSnip = false;
            moveStarted = false;
        }
        public Screen_snip_window(BitmapSource mbp)
        {
            InitializeComponent();

            ScreenShotImage.Source = mbp;
             System.Drawing.Rectangle r = Screen.PrimaryScreen.Bounds;
            ScreenShotImage.Width = r.Width;
            ScreenShotImage.Height = r.Height;

            beginX = 0;
            beginY = 0;
            endX = 0;
            endY = 0;
            left = 0;
            top = 0;
            right = 0;
                bottom = 0;
            mouseMoveUpdate = false;
            positiveSnip = false;
            moveStarted = false;

            this.Topmost = true;
            this.Activate();


        }

        private void KeyboardHit(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (Key.Escape == e.Key)
                Close();
            if(Key.Enter == e.Key)
            {

                Point p = new Point(endX, endY);
                exitMousePositionX = p.X;
                exitMousePositionY = p.Y;

                    positiveSnip = true;
                Close();
            }
        }

   private void AutoCancel(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(this);
            exitMousePositionX = p.X;
            exitMousePositionY = p.Y;
            positiveSnip = false;
            Close();
            

        }

        private void Mousemove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            if(mouseMoveUpdate)
            {
                moveStarted = true;
                // Draw rectangle
                double x = p.X;
                double y = p.Y;

                endX = x;
                endY = y;

                // Set button 2 coordinate

                if(endX < beginX)
                {

                    left = endX;
                    right = beginX;
                }
                else
                {
                    left = beginX;
                    right = endX;
                }
                if(endY < beginY)
                {
                    top = endY;
                    bottom = beginY;
                }
                else
                {
                    top = beginY;
                    bottom =endY ;
                }

                selectionRectangle.Margin = new Thickness(left, top, 0, 0);
                selectionRectangle.Width = AbsoluteDouble(left, right);
                selectionRectangle.Height = AbsoluteDouble(top, bottom);
            }
        }

        private double AbsoluteDouble(double a, double b)
        {
            double r = a - b;
            if (r < 0) r *= -1;
            return r;
        }
        private void BeginDraw(object sender, MouseButtonEventArgs e)
        {
            if(e.ClickCount > 1)
            {
                Point p = new Point(endX, endY);
                exitMousePositionX = p.X;
                exitMousePositionY = p.Y;

                if (AbsoluteDouble(left, right) > 1 && AbsoluteDouble(top, bottom) > 1)
                {
                    positiveSnip = true;
                }
                else positiveSnip = false;
                Close();
            }
            else
            {

            if(mouseMoveUpdate)
            {
                mouseMoveUpdate = false;
                    moveStarted = false; 
            }
            else
            {

            Point p = e.GetPosition(this);
            double x = p.X;
            double y = p.Y;

            beginX = x;
            beginY = y;
            mouseMoveUpdate = true;
            }

            
            }

        }

    }
}
