namespace ChatTool.Frontend.Wpf.Models
{
    using System;
    using System.Windows.Input;

    class ParametrizedCommand<T> : ICommand
    {
        private readonly Action<T> execute;

        private readonly Func<T, bool>? canExecute;

        public ParametrizedCommand(Action<T> execute, Func<T, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return this.canExecute?.Invoke((T)parameter!) ?? true;
        }

        public void Execute(object? parameter)
        {
            this.execute((T)parameter!);
        }
    }
}
