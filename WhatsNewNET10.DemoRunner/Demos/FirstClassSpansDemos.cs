using System.Linq.Expressions;

namespace WhatsNewNET10.DemoRunner.Demos;

public class FirstClassSpansDemos
{
    public static void Do()
    {
        Expression<Func<int[], bool>> expr = a => a.Contains(1);

        new MyVisitor().Visit(expr);
        Environment.Exit(0);
    }

    class MyVisitor : ExpressionVisitor
    {
        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            Console.WriteLine($"Type: {node.Method.DeclaringType} Method: {node.Method.Name}");
            return base.VisitMethodCall(node);
        }
    }
}