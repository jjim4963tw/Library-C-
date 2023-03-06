using LibraryWPF.ViewModel;
using System.Windows;

namespace LibraryWPF.View
{
    /// <summary>
    /// RoundButtonView.xaml 的互動邏輯
    /// </summary>
    public partial class RoundButtonView : Window
    {
        private RoundButtonViewModel _viewModel = new RoundButtonViewModel();

        public RoundButtonView()
        {
            InitializeComponent();
        }
    }
}
