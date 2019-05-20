namespace WpfMvvmBackgroundWorker
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;

    internal sealed class RunWorkerCommand : ICommand
    {
        private readonly BackgroundWorker backgroundWorker;

        public RunWorkerCommand(BackgroundWorker backgroundWorker)
        {
            this.backgroundWorker = backgroundWorker;
        }

        public bool CanExecute(object parameter) => !this.backgroundWorker.IsBusy;

        public void Execute(object parameter)
        {
            this.backgroundWorker.RunWorkerAsync();
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }
}