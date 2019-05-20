namespace WpfMvvmBackgroundWorker
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Input;

    internal sealed class ShellViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker { WorkerReportsProgress = true, };

        private ICommand runWorkerCommand;

        private int progressPercentage;

        private string userState = "Ready";

        public int ProgressPercentage
        {
            get => this.progressPercentage;
            set
            {
                this.progressPercentage = value;
                this.NotifyPropertyChanged();
            }
        }

        public string UserState
        {
            get => this.userState;
            set
            {
                this.userState = value;
                this.NotifyPropertyChanged();
            }
        }

        public ICommand RunWorkerCommand => this.runWorkerCommand ??
                                            (this.runWorkerCommand = new RunWorkerCommand(this.backgroundWorker));

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ShellViewModel()
        {
            this.backgroundWorker.DoWork += (sender, e) =>
            {
                var worker = sender as BackgroundWorker;
                for (var i = 0; i < 100; i++)
                {
                    Thread.Sleep(60);
                    worker?.ReportProgress(i, $"{i}%");
                }
            };
            this.backgroundWorker.ProgressChanged += (sender, e) =>
            {
                this.ProgressPercentage = e.ProgressPercentage;
                this.UserState = (string)e.UserState;
            };
            this.backgroundWorker.RunWorkerCompleted += (sender, e) =>
            {
                this.UserState = "Done";
                CommandManager.InvalidateRequerySuggested();
            };
        }
    }
}
