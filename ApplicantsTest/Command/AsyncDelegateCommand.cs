using System;
using System.Threading.Tasks;
using System.Windows.Input;
/// <summary>
/// A simple async ICommand implementation, since no external libraries are allowed
/// <remarks>http://blog.mycupof.net/2012/08/23/mvvm-asyncdelegatecommand-what-asyncawait-can-do-for-uidevelopment/ </remarks> 
/// </summary>
public class AsyncDelegateCommand : ICommand
{
    private readonly Predicate<object> _canExecute;
    private readonly Func<object, Task> _asyncExecute;

    public AsyncDelegateCommand(Func<object, Task> execute)
        : this(execute, null)
    {
    }

    public AsyncDelegateCommand(Func<object, Task> asyncExecute,
                   Predicate<object> canExecute)
    {
        _asyncExecute = asyncExecute;
        _canExecute = canExecute;
    }

    public bool CanExecute(object parameter)
    {
        if (_canExecute == null)
        {
            return true;
        }

        return _canExecute(parameter);
    }

    public async void Execute(object parameter)
    {
        await ExecuteAsync(parameter);
    }

    public event EventHandler CanExecuteChanged;

    protected virtual async Task ExecuteAsync(object parameter)
    {
        await _asyncExecute(parameter);
    }
}