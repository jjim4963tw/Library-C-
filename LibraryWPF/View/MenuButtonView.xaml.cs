using LibraryWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace LibraryWPF.View
{
    /// <summary>
    /// MenuButtonView.xaml 的互動邏輯
    /// </summary>
    public partial class MenuButtonView : Window
    {
        private ComboBoxViewModel _viewModel = new ComboBoxViewModel();

        public MenuButtonView()
        {
            InitializeComponent();
            InitializeContentView();
        }

        private void InitializeContentView()
        {
            this.cbbDiskNumber.DataContext = this._viewModel;

            List<string> enableDiskLisk = this.GetFreeDiskNumber();

            this._viewModel.DiskNumberItems.Clear();
            this._viewModel.DiskNumberItems = new System.Collections.ObjectModel.ObservableCollection<string>(enableDiskLisk);
            this.cbbDiskNumber.SelectedIndex = 0;
        }

        private void BtnMenu_Click(object sender, RoutedEventArgs e)
        {
            this.btnMenus.ContextMenu.IsOpen = true;
        }

        //
        // 摘要:
        //     選單列中偏好設定選項的點擊事件
        private void MenuPreference_Click(object sender, RoutedEventArgs e)
        {
        }


        #region Private Function
        private List<string> GetFreeDiskNumber()
        {
            List<string> enableDiskLisk = new List<string>();
            for (int i = 0; i < 24; i++)
            {
                enableDiskLisk.Add(string.Format("{0}", Convert.ToChar('C' + i)));
            }

            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                enableDiskLisk.Remove(d.Name.Replace(@":\", ""));
            }

            return enableDiskLisk;
        }
        #endregion
    }
}
