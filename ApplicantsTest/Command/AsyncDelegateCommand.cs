using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ApplicantsTest.Command
{
    /// <summary>
    /// A simple async ICommand implementation, since no external libraries are allowed
    /// <remarks>http://blog.mycupof.net/2012/08/23/mvvm-asyncdelegatecommand-what-asyncawait-can-do-for-uidevelopment/ </remarks> 
    /// </summary>
    public sealed class AsyncDelegateCommand : ICommand
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
            this._asyncExecute = asyncExecute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this._canExecute == null)
            {
                return true;
            }

            return this._canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public event EventHandler CanExecuteChanged;

        private async Task ExecuteAsync(object parameter)
        {
            await this._asyncExecute(parameter);
        }
    }
}