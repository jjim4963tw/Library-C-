using LibraryWPF.Component;
using LibraryWPF.View;
using System.Windows;

namespace LibraryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoundButtonView s_RoundButtonView = new RoundButtonView();
        public static GIFPlayerView s_GIFPlayerView = new GIFPlayerView();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RoundButton_Click(object sender, RoutedEventArgs e)
        {
            s_RoundButtonView.Show();
        }

        private void GIFPlayer_Click(object sender, RoutedEventArgs e)
        {
            s_GIFPlayerView.Show();
        }
        
        private void AlertButton_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBox.Show(this, "Test");
        }

        private void LoadinButton_Click(object sender, RoutedEventArgs e)
        {
            LoadingView _ascLoadingView = LoadingView.ShowAlert(this, true);
            _ascLoadingView.CancelEvent += new LoadingView.CancelButtonClickMethod(this.CancelButtonClickMethod);
        }


        #region Loading View Interface
        public void CancelButtonClickMethod()
        {
        }
        #endregion
    }
}
