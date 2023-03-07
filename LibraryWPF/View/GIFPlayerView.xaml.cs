using System;
using System.IO;
using System.Windows;

namespace LibraryWPF.View
{
    /// <summary>
    /// GIFPlayerView.xaml 的互動邏輯
    /// </summary>
    public partial class GIFPlayerView : Window
    {
        public GIFPlayerView()
        {
            InitializeComponent();

            this.playerGIF.Source = new Uri(Path.Combine(Environment.CurrentDirectory, "Resources", "cat.gif"));
        }

        private void GIF_MediaEnded(object sender, RoutedEventArgs e)
        {
            // 無限輪播 GIF
            this.playerGIF.Position = new TimeSpan(0, 0, 1);
        }
    }
}
