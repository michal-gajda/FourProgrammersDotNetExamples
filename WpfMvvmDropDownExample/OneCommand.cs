namespace WpfMvvmDropDownExample
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    public class OneCommand : ICommand
    {
        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            var items = parameter as ObservableCollection<CompanyItem>;

            if (items == null)
            {
                return;
            }

            items.Clear();
            items.Add(new CompanyItem { Id = 1, Name = "One" });
            items.Add(new CompanyItem { Id = 2, Name = "Two" });
            items.Add(new CompanyItem { Id = 3, Name = "Three" });
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}