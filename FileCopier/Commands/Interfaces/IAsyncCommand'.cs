using System.Windows.Input;

namespace FileCopier.Commands.Interfaces
{
    public interface IAsyncCommand<TParam> : ICommand
    {
        ICommand CancelCommand { get; }

        AsyncExecutionState State { get; }
    }
}