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
    /// Interaction logic for VideoFrame.xaml
    /// </summary>
    public partial class VideoFrame : Window
    {


        public VideoFrame()
        {
            InitializeComponent();
        }

        private void CloseW(object sender, RoutedEventArgs e)
        {
            // TODO :::
            // Stop recording, delete the record and close the window...
        }

        private void StartRecording(object sender, RoutedEventArgs e)
        {
            // Start recording, start getting window coordinate positions for later proceeding
        }

        private void ClickDragMove(object sender, MouseButtonEventArgs e)
        {

        }

        private void ImageWnd(object sender, DragEventArgs e)
        {

        }

        private void StopRecording(object sender, RoutedEventArgs e)
        {

        }
    }
}
