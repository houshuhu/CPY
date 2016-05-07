using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CPy.Linq.Extensions
{
    /// <summary>
    /// 参考链接:http://blog.csdn.net/leewhoee/article/details/8968023
    /// </summary>
    public static class DynamicLinqExtensions  
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,Expression<Func<T, bool>> expr2)
        {
            return expr1.Compose(expr2, Expression.Or);
        }
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return expr1.Compose(expr2, Expression.And);
        }
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)  
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first  
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression   
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        } 
    }

    internal class ParameterRebinder : ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> map;

        internal ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {
            this.map = (map ?? new Dictionary<ParameterExpression, ParameterExpression>());
        }

        internal static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {
            return new ParameterRebinder(map).Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression p)
        {
            ParameterExpression parameterExpression;
            if (this.map.TryGetValue(p, out parameterExpression))
            {
                p = parameterExpression;
            }
            return base.VisitParameter(p);
        }
    } 
}