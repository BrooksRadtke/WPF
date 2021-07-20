using System;
using System.Windows.Input;

namespace MVVMDemo
{
    public class MyICommand : ICommand
    {
        Action TargetExecuteMethod;
        Func<bool> TargetCanExecuteMethod;

        public MyICommand(Action executeMethod)
        {
            TargetExecuteMethod = executeMethod;
        }

        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            TargetExecuteMethod = executeMethod;
            TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            if(TargetCanExecuteMethod != null)
            {
                return true;
            }

            if(TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if(TargetExecuteMethod != null)
            {
                TargetExecuteMethod();
            }
        }
    }
}
