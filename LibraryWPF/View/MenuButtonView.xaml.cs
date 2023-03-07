using System.Windows;

namespace LibraryWPF.View
{
    /// <summary>
    /// MenuButtonView.xaml 的互動邏輯
    /// </summary>
    public partial class MenuButtonView : Window
    {
        public MenuButtonView()
        {
            InitializeComponent();
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
    }
}
