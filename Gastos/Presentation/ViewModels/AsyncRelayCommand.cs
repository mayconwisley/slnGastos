using System.Windows.Input;

namespace Gastos.Presentation.ViewModels;

public sealed class AsyncRelayCommand(Func<Task> execute, Func<bool>? canExecute = null) : ObservableObject, ICommand
{
    private bool isExecuting;

    public event EventHandler? CanExecuteChanged;

    public bool IsExecuting
    {
        get => isExecuting;
        private set
        {
            if (SetProperty(ref isExecuting, value))
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public bool CanExecute(object? parameter) => !IsExecuting && (canExecute?.Invoke() ?? true);

    public async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
        {
            return;
        }

        IsExecuting = true;
        try
        {
            await execute();
        }
        finally
        {
            IsExecuting = false;
        }
    }
}
