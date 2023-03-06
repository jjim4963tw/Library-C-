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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RoundButton_Click(object sender, RoutedEventArgs e)
        {
            s_RoundButtonView.Show();
        }
    }
}
