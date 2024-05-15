using System;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Labs
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) yield return (T)Enumerable.Empty<T>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject ithChild = VisualTreeHelper.GetChild(depObj, i);
                if (ithChild == null) continue;
                if (ithChild is T t) yield return t;
                foreach (T childOfChild in FindVisualChildren<T>(ithChild)) yield return childOfChild;
            }
        }
    }

    public class ActionCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private Action<object?> _action;

        public ActionCommand (Action<object?> action)
        {
            _action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _action?.Invoke(parameter);
        }
    }

}
