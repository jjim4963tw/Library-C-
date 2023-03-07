using System.Windows;

namespace LibraryWPF.Component
{
    /// <summary>
    /// LoadingView.xaml 的互動邏輯
    /// </summary>
    public partial class LoadingView : Window
    {
        public bool ShowCancelButton
        {
            get => this.btnClose.Visibility == Visibility.Visible;
            set => this.btnClose.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }


        #region Delegate
        public event CancelButtonClickMethod CancelEvent;
        public delegate void CancelButtonClickMethod();
        #endregion


        public LoadingView()
        {
            InitializeComponent();
        }


        #region UI Component
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.CancelEvent();
            this.Close();
        }
        #endregion


        #region Static Function
        public static LoadingView ShowAlert()
        {
            LoadingView alert = new LoadingView()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowCancelButton = false
            };

            alert.Show();

            return alert;
        }

        public static LoadingView ShowAlert(Window owner)
        {
            LoadingView alert = new LoadingView()
            {
                Owner = owner,
                WindowStartupLocation = (owner != null) ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen,
                ShowCancelButton = false
            };

            alert.Show();

            return alert;
        }

        public static LoadingView ShowAlert(bool showCancelButton)
        {
            LoadingView alert = new LoadingView()
            {
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                ShowCancelButton = showCancelButton
            };

            alert.Show();

            return alert;
        }

        public static LoadingView ShowAlert(Window owner, bool showCancelButton)
        {
            LoadingView alert = new LoadingView()
            {
                Owner = owner,
                WindowStartupLocation = (owner != null) ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen,
                ShowCancelButton = showCancelButton
            };

            alert.Show();

            return alert;
        }
        #endregion
    }
}
