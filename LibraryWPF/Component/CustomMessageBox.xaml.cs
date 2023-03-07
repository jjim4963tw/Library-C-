using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LibraryWPF.Component
{
    /// <summary>
    /// CustomMessageBox.xaml 的互動邏輯
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        #region Variable
        public string TitleString
        {
            get => this.tbTitle.Text;
            set => this.tbTitle.Text = value;
        }

        public string Message
        {
            get => this.tbContent.Text;
            set => this.tbContent.Text = value;
        }

        public string IconResource
        {
            set => this.imgIcon.Source = new BitmapImage(new Uri(value));
        }

        public string CancelButtonText
        {
            get => this.btnCancel.Content.ToString();
            set => this.btnCancel.Content = value;
        }

        public string ConfirmButtonText
        {
            get => this.btnConfirm.Content.ToString();
            set => this.btnConfirm.Content = value;
        }

        public bool ShowCancelButton
        {
            get => this.btnCancel.Visibility == Visibility.Visible;
            set => this.btnCancel.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }
        #endregion


        #region Initialization 
        public CustomMessageBox()
        {
            InitializeComponent();
        }
        #endregion


        #region UI Component
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }
        #endregion


        #region Static Function
        public static bool? Show(string title, string message, string confirmButtonText, string cancelButtonText)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                TitleString = title,
                Message = message,
                ConfirmButtonText = confirmButtonText,
                CancelButtonText = cancelButtonText,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            return alert.ShowDialog();
        }


        public static bool? Show(string message)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            return alert.ShowDialog();
        }

        public static bool? Show(Window owner, string message)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                Owner = owner,
                WindowStartupLocation = (owner != null) ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen
            };

            return alert.ShowDialog();
        }

        public static bool? Show(string message, bool showCancelButton)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                ShowCancelButton = showCancelButton,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            return alert.ShowDialog();
        }

        public static bool? Show(Window owner, string message, bool showCancelButton)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                ShowCancelButton = showCancelButton,
                Owner = owner,
                WindowStartupLocation = (owner != null) ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen
            };

            return alert.ShowDialog();
        }

        public static bool? Show(string message, string confirmButtonText, string cancelButtonText)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                ConfirmButtonText = confirmButtonText,
                CancelButtonText = cancelButtonText,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            return alert.ShowDialog();
        }

        public static bool? Show(Window owner, string message, string confirmButtonText, string cancelButtonText)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                ConfirmButtonText = confirmButtonText,
                CancelButtonText = cancelButtonText,
                Owner = owner,
                WindowStartupLocation = (owner != null) ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen
            };
            return alert.ShowDialog();
        }


        public static bool? Show(string message, string confirmButtonText, string cancelButtonText, bool showCancelButton)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                ConfirmButtonText = confirmButtonText,
                CancelButtonText = cancelButtonText,
                ShowCancelButton = showCancelButton,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };
            return alert.ShowDialog();
        }

        public static bool? Show(Window owner, string message, string confirmButtonText, string cancelButtonText, bool showCancelButton)
        {
            CustomMessageBox alert = new CustomMessageBox()
            {
                Message = message,
                ConfirmButtonText = confirmButtonText,
                CancelButtonText = cancelButtonText,
                ShowCancelButton = showCancelButton,
                Owner = owner,
                WindowStartupLocation = (owner != null) ? WindowStartupLocation.CenterOwner : WindowStartupLocation.CenterScreen
            };
            return alert.ShowDialog();
        }
        #endregion
    }
}
