
namespace LibraryWPF.ViewModel
{
    class RoundButtonViewModel: ViewModelBase
    {
        // Button 的預設背景色
        private string _buttonBackground;
        public string ButtonBackground
        {
            get => _buttonBackground;
            set
            {
                _buttonBackground = value;

                OnPropertyChanged(nameof(ButtonBackground));
            }
        }


        // Button 焦點變化的背景色
        private string _buttonHighlightBackground;
        public string ButtonHighlightBackground
        {
            get => _buttonHighlightBackground;
            set
            {
                _buttonHighlightBackground = value;

                OnPropertyChanged(nameof(ButtonHighlightBackground));
            }
        }


        // Button 的文字顏色
        private string _buttonTextColor;
        public string ButtonTextColor
        {
            get => _buttonTextColor;
            set
            {
                _buttonTextColor = value;

                OnPropertyChanged(nameof(ButtonTextColor));
            }
        }


        // Button 的邊框顏色
        private string _buttonBorderBackground;
        public string ButtonBorderBackground
        {
            get => _buttonBorderBackground;
            set
            {
                _buttonBorderBackground = value;

                OnPropertyChanged(nameof(ButtonBorderBackground));
            }
        }


        // Button 的圓角角度
        private int _buttonCornerRadius;
        public int ButtonCornerRadius
        {
            get => _buttonCornerRadius;
            set
            {
                _buttonCornerRadius = value;

                OnPropertyChanged(nameof(ButtonCornerRadius));
            }
        }


        // Button 的邊框寬度
        private int _buttonBorderThickness;
        public int ButtonBorderThickness
        {
            get => _buttonBorderThickness;
            set
            {
                _buttonBorderThickness = value;

                OnPropertyChanged(nameof(ButtonBorderThickness));
            }
        }


        public RoundButtonViewModel()
        {
            this.ButtonBackground = "#234184";
            this.ButtonHighlightBackground = "#0B1D46";
            this.ButtonTextColor = "#FFFFFF";
            this.ButtonBorderBackground = "#000000";
            this.ButtonCornerRadius = 5;
            this.ButtonBorderThickness = 2;
        }
    }
}
