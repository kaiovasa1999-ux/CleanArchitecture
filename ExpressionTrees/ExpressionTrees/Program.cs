using System;
using System.Linq.Expressions;

class Program
{
    static void Main()
    {
        Expression<Func<object>> constant = () => 42;
        ParseExpression(constant, string.Empty);
    }

    static void ParseExpression(Expression expr, string prefix)
    {
        prefix += "-";
        if (expr.NodeType == ExpressionType.Lambda)
        {
            Console.WriteLine($"{prefix} expression: {expr}");
            var lambdaExpression = (LambdaExpression)expr;
            var body = lambdaExpression.Body;
            Console.WriteLine($"{prefix} extracting body");
            ParseExpression(body, prefix);
        }
        else if (expr.NodeType == ExpressionType.Constant)
        {
            Console.WriteLine($"{prefix} Extracting constant");
            var constantExpression = (ConstantExpression)expr;
            var value = constantExpression.Value;
            Console.WriteLine($"{prefix} extracting value: {value}");
        }
        else if (expr.NodeType == ExpressionType.Convert)
        {
            Console.WriteLine($"{prefix} Extracting conversion...");
            var conversionExpression = (UnaryExpression)expr;
        }
    }
}