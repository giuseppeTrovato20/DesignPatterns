using System;
namespace DesignPatterns.Behavioural.Interpreter
{
    public interface IBooleanExpression
    {
        bool Evaluate();
    }

    public class And : IBooleanExpression
    {
        private readonly IBooleanExpression leftExpression;
        private readonly IBooleanExpression rightExpression;

        public And(IBooleanExpression left, IBooleanExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public bool Evaluate()
        {
            return leftExpression.Evaluate() && rightExpression.Evaluate();
        }
    }

    public class Or : IBooleanExpression
    {
        private readonly IBooleanExpression leftExpression;
        private readonly IBooleanExpression rightExpression;

        public Or(IBooleanExpression left, IBooleanExpression right)
        {
            leftExpression = left;
            rightExpression = right;
        }

        public bool Evaluate()
        {
            return leftExpression.Evaluate() || rightExpression.Evaluate();
        }
    }

    public class BooleanInterpreter
    {
        public IBooleanExpression ParseExpression(string input, IDictionary<string, bool> variables)
        {
            var tokens = input.Split(' ');
            var stack = new Stack<IBooleanExpression>();

            foreach (var token in tokens)
            {
                if (bool.TryParse(token, out bool value))
                {
                    stack.Push(new Variable(value));
                }
                else if (variables.ContainsKey(token))
                {
                    stack.Push(new Variable(variables[token]));
                }
                else
                {
                    var rightExpression = stack.Pop();
                    var leftExpression = stack.Pop();

                    if (token == "AND")
                    {
                        stack.Push(new And(leftExpression, rightExpression));
                    }
                    else if (token == "OR")
                    {
                        stack.Push(new Or(leftExpression, rightExpression));
                    }
                }
            }

            return stack.Pop();
        }
    }

    public class Variable : IBooleanExpression
    {
        private readonly bool value;

        public Variable(bool value)
        {
            this.value = value;
        }

        public bool Evaluate()
        {
            return value;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var variables = new Dictionary<string, bool>
        {
            { "A", true },
            { "B", false },
            { "C", true }
        };

            var interpreter = new BooleanInterpreter();
            var expression = interpreter.ParseExpression("A B OR C AND", variables);

            Console.WriteLine($"Risultato: {expression.Evaluate()}");
        }
    }
}

