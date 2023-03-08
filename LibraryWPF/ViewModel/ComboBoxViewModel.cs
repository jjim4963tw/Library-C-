using System.Collections.ObjectModel;

namespace LibraryWPF.ViewModel
{
    class ComboBoxViewModel : ViewModelBase
    {
        // 磁碟機代號列表
        private ObservableCollection<string> _diskNumberItems;
        public ObservableCollection<string> DiskNumberItems
        {
            get => _diskNumberItems;
            set
            {
                _diskNumberItems = value;
                OnPropertyChanged(nameof(DiskNumberItems));
            }
        }

        public string SelectedDiskNumber { get; set; }

        public ComboBoxViewModel()
        {
            this._diskNumberItems = new ObservableCollection<string>();
        }
    }
}
