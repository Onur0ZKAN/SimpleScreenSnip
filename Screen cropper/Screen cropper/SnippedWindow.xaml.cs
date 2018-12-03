using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace Screen_cropper
{
    /// <summary>
    /// Interaction logic for SnippedWindow.xaml
    /// </summary>
    public partial class SnippedWindow : Window
    {
        double w, h;
        Bitmap croppedOriginal;
        MainWindow _parent;

        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int GWL_EXSTYLE = (-20);

        IntPtr hwnd;

        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hwnd, int index);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hwnd, int index, int newStyle);

        public SnippedWindow()
        {
            InitializeComponent();
            this.Topmost = true;
            w = 0;
            h = 0;
        }

        private void SaveImage(object sender, MouseButtonEventArgs e)
        {
            // We need double click
            if (e.ClickCount < 2)
                return;

            string probableFileName = WndName.Text;



            string regexSearch = new string(System.IO.Path.GetInvalidFileNameChars()) + new string(System.IO.Path.GetInvalidPathChars());
            Regex r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
            probableFileName = r.Replace(probableFileName, "");
            probableFileName = r.Replace(probableFileName, ".");

            if(probableFileName == "")
            {


            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "PNG file (*png)|*.png";
            saveFileDialog.InitialDirectory = MainWindow.lastDirectory;
            if(saveFileDialog.ShowDialog() == true && croppedOriginal != null)
            {
                croppedOriginal.Save(saveFileDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                NotifySave();
            }

            if(saveFileDialog.FileName != "")
                {

                MainWindow.lastDirectory = System.IO.Path.GetDirectoryName(saveFileDialog.FileName);
                string fileName = System.IO.Path.GetFileName(saveFileDialog.FileName);
                string[] pureName = fileName.Split('.');
                MainWindow.serialIndexLength = pureName[0].Length;
                }

            }
            else
            {
                string desktopPath = MainWindow.lastDirectory;
                croppedOriginal.Save(desktopPath + "\\" + probableFileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                NotifySave();
            }
            MainWindow.LocateIndex();


        }

        private void ImageWnd(object sender, System.Windows.DragEventArgs e)
        {
            if (_parent != null)
                _parent.ImageWnd(sender, e);
        }

        private void LoadHWND(object sender, RoutedEventArgs e)
        {
             hwnd = new WindowInteropHelper(this).Handle;

            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;
            this.Left = (int)point.X - (int)(this.Width / 2);
            this.Top = (int)point.Y - (int)(this.Height / 2);
        }

        private void ChangeOpacity(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ImageContainer.Opacity = TransparencyValue.Value;
            //CroppedImage.Opacity = TransparencyValue.Value;
        }

        private void ActivateAgentMode(object sender, RoutedEventArgs e)
        {
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);

            SmallAgent sa = new SmallAgent(this);
            sa.Show();

            System.Drawing.Point point = System.Windows.Forms.Control.MousePosition;


            sa.Left = point.X - 55;
            sa.Top = point.Y - 35;

            ToolsContainer.Visibility = Visibility.Hidden;
        }

        public void DisableAgentMode()
        {
            int extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle ^WS_EX_TRANSPARENT);

            ToolsContainer.Visibility = Visibility.Visible;
            ImageContainer.Opacity = 1;
            CroppedImage.Opacity = 1;
        }

        public SnippedWindow(double width, double height, ImageSource croppedImage, Bitmap croppedBitmap, MainWindow parent, string headerName )
        {
            InitializeComponent();
            this.Topmost = true;

            w = (int)width + 50;
            h = (int)height + 85;
            CroppedImage.Width = width;
            CroppedImage.Height = height;
            CroppedImage.Source = croppedImage;


                this.Width = w;      
                this.Height = h;
                    

            

            croppedOriginal = croppedBitmap;
            _parent = parent;

            WndName.Text = headerName;
        }

        private void CloseW(object sender, RoutedEventArgs e)
        {
            croppedOriginal.Dispose();
            Close();
        }

        private void ClickDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        private void NotifySave()
        {
            SaveNoterBorder.Opacity = 1;
            SaveNoterBorder2.Opacity = 0.8;
            Storyboard sb = this.FindResource("SaveFade") as Storyboard;
            Storyboard sb2 = FindResource("SaveFade2") as Storyboard;
            Storyboard.SetTarget(sb, SaveNoterBorder);
            Storyboard.SetTarget(sb2, SaveNoterBorder2);
            sb.Begin();
            sb2.Begin();
        }
    }
}
