using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace expressionTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");
            ConstantExpression five = Expression.Constant(5, typeof(int));
            BinaryExpression numLessThanFive = Expression.LessThan(numParam, five);
            Expression<Func<int, bool>> lambda1 =
                Expression.Lambda<Func<int, bool>>(
                    numLessThanFive,
                    new ParameterExpression[] { numParam });
            Console.WriteLine(lambda1.Compile()(5).ToString());
            Console.ReadKey();

            Func<int, bool> func = i => i < 5;
            Console.WriteLine(func(5).ToString());

            Console.ReadKey();
        }
    }
}
