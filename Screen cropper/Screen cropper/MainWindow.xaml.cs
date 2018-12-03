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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Windows.Interop;

namespace Screen_cropper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bitmap bmp;
        Bitmap croppedBitmap;

        public static string lastDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static int lastIndex;

        public static int serialIndexLength = 2;
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
            LocateIndex();
        }


        private void ClickDragMove(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseW(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private BitmapSource CopyScreen()
        {

            System.Drawing.Rectangle rect = Screen.PrimaryScreen.Bounds;
            bmp = new Bitmap(rect.Width, rect.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(rect.Left, rect.Top, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);

            return CreateBrushFromBitmap(bmp);
        }

        public static BitmapSource CreateBrushFromBitmap(Bitmap bmp)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(bmp.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        private void ScreenSnip(object sender, RoutedEventArgs e)
        {

            Hide();
            Screen_snip_window ssw = new Screen_snip_window(CopyScreen());
            ssw.ShowDialog();
            if(ssw.positiveSnip)
            {

             croppedBitmap = CropImage(bmp, new System.Drawing.Rectangle((int)ssw.left-6, (int)ssw.top-6, (int)(ssw.right - ssw.left) +2, (int)(ssw.bottom - ssw.top)+2) );

             BitmapSource output = CreateBrushFromBitmap(croppedBitmap);

                string croppedWndName = "";
             if(Serialing.IsChecked == true)
                {
                    // Get a good name...
                    croppedWndName = lastIndex.ToString("D" + serialIndexLength);
                }
                       

             SnippedWindow ssnw = new SnippedWindow(ssw.right - ssw.left +2, ssw.bottom - ssw.top +2, output, croppedBitmap, this, croppedWndName);
             ssnw.Show();

            }
            Show();
        }


        public Bitmap CropImage(Bitmap source, System.Drawing.Rectangle section)
        {
            // An empty bitmap which will hold the cropped image
            Bitmap bmp = new Bitmap(section.Width, section.Height);

            Graphics g = Graphics.FromImage(bmp);

            // Draw the given area (section) of the source image
            // at location 0,0 on the empty bitmap (bmp)
            g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);

            return bmp;
        }

        private void Keydown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
                CloseW(sender, null);
            if (e.Key == Key.Enter)
                ScreenSnip(sender, null);
        }

        public void ImageWnd(object sender, System.Windows.DragEventArgs e)
        {
            if(e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
            {
               

                string[] files = (string[])e.Data.GetData(System.Windows.DataFormats.FileDrop);

                foreach(string filePath in files)
                {
                    string[] splits = filePath.Split('.');
                    if (splits.Length < 2) continue;

                    string[] fileName = splits[splits.Length - 2].Split('\\');

                    // string extension;

                    if  (splits[splits.Length - 1].Equals("jpg", StringComparison.InvariantCultureIgnoreCase)||
                         splits[splits.Length - 1].Equals("jpeg", StringComparison.InvariantCultureIgnoreCase)||
                         splits[splits.Length - 1].Equals("png", StringComparison.InvariantCultureIgnoreCase)||
                         splits[splits.Length - 1].Equals("bmp", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Bitmap image = new Bitmap(filePath);
                        BitmapSource output = CreateBrushFromBitmap(image);
                        SnippedWindow ssnw = new SnippedWindow(image.Width, image.Height, output, image, this, fileName[fileName.Length-1]);
                        ssnw.Show();
                    }
                    else continue;
                }

            }
        }

        public static void LocateIndex()
        {
            lastIndex = 1;

            while (System.IO.File.Exists(lastDirectory + "\\" + lastIndex.ToString("D" + serialIndexLength) + ".png"))
                lastIndex++;

            // This ensures the name does not exists...
        }
    }
}
