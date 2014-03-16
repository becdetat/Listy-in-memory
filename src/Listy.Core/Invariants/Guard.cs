using System;
using System.Linq.Expressions;

namespace Listy.Core.Invariants
{
    public static class Guard
    {
        public static void Against(Expression<Func<bool>> expression)
        {
            if (expression.Compile()())
            {
                throw new InvariantException(expression, "guard against");
            }
        }

        public static void For(Expression<Func<bool>> expression)
        {
            if (!expression.Compile()())
            {
                throw new InvariantException(expression, "guard for");
            }
        }
    }

}