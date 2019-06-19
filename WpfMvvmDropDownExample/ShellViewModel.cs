namespace WpfMvvmDropDownExample
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    internal sealed class ShellViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<CompanyItem> items = new ObservableCollection<CompanyItem>();
        private CompanyItem selectedItem = null;
        private ICommand oneCommand;

        public ShellViewModel()
        {

        }

        public ICommand OneCommand => this.oneCommand ?? (this.oneCommand = new OneCommand(this.Items));

        public ObservableCollection<CompanyItem> Items
        {
            get => this.items;
            set
            {
                this.items = value;
                this.NotifyPropertyChanged();
            }
        }

        public CompanyItem SelectedItem
        {
            get => this.selectedItem;
            set
            {
                this.selectedItem = value;
                this.NotifyPropertyChanged();
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}