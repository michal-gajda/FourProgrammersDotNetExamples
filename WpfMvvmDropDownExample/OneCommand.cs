namespace WpfMvvmDropDownExample
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class OneCommand : ICommand
    {
        private readonly ObservableCollection<CompanyItem> items;

        public OneCommand(ObservableCollection<CompanyItem> items)
        {
            this.items = items;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            this.items.Clear();
            this.items.Add(new CompanyItem { Id = 1, Name = "One" });
            this.items.Add(new CompanyItem { Id = 2, Name = "Two" });
            this.items.Add(new CompanyItem { Id = 3, Name = "Three" });
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}