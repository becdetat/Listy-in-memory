using System;
using System.Linq.Expressions;

namespace Listy.Core.Invariants
{
    public class InvariantException : Exception
    {
        private readonly string _guardType;
        private readonly Expression<Func<bool>> _expression;

        public InvariantException(Expression<Func<bool>> expression, string guardType)
        {
            _expression = expression;
            _guardType = guardType;
        }

        private string GetExpressionMessage()
        {
            var message = _expression.Body.ToString();

            if (_expression.Body is BinaryExpression)
            {
                var binaryExpression = _expression.Body as BinaryExpression;
                message = ReplaceMemberExpression(message, binaryExpression.Left);
                //message = ReplaceMemberExpression(message, binaryExpression.Right);
            }
            if (_expression.Body is MethodCallExpression)
            {
                var methodCallExpression = _expression.Body as MethodCallExpression;
                message = ReplaceMemberExpression(message, methodCallExpression.Object);
            }

            return message;
        }

        private static string ReplaceMemberExpression(string message, Expression expr)
        {
            return !(expr is MemberExpression)
                ? message 
                : message.Replace(expr.ToString(), ((MemberExpression) expr).Member.Name);
        }

        public override string Message
        {
            get { return string.Format("Invariant failed - {0}: {1}", _guardType, GetExpressionMessage()); }
        }
    }
}