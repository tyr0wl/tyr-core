using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace tyr.Core
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected void OnPropertyChanged(params Expression<Func<object>>[] propertySelectors)
        {
            var propertyNames = propertySelectors.Select(GetPropertyName);
            foreach (var propertyName in propertyNames)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void Set<T>(Expression<Func<object>> propertySelector, ref T property, T value)
        {
            property = value;
            OnPropertyChanged(propertySelector);
        }

        private static string GetPropertyName(Expression<Func<object>> propertySelector)
        {
            var selector = propertySelector.Body;
            if (selector.NodeType == ExpressionType.Convert)
            {
                selector = ((UnaryExpression) selector).Operand;
            }

            var propertyName = ((MemberExpression) selector).Member.Name;
            return propertyName;
        }
    }
}