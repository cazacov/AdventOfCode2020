using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_18_1
{
    public class Calculator
    {
        private List<string> tokens = new List<string>();


        public Calculator(string str)
        {
            var pos = 0;
            do
            {
                var result = String.Empty;
                while (str[pos] == ' ')
                {
                    pos++;
                }

                while (pos < str.Length)
                {
                    result += str[pos];
                    pos++;
                    if ("()+-".Contains(result))
                    {
                        break;
                    }

                    if (pos >= str.Length || " ()+-".Contains(str[pos]))
                    {
                        break;
                    }
                }

                tokens.Add(result);
            } while (pos < str.Length);

            // Reverse tokens
            var rev = new List<string>();
            foreach (var t in tokens)
            {
                var res = t;
                if (res == "(")
                {
                    res = ")";
                } else if (res == ")")
                {
                    res = "(";
                }
                rev.Insert(0, res);
            }
            this.tokens = rev;
        }

        private string NextToken()
        {
            if (this.tokens.Count == 0)
            {
                return string.Empty;
            }
            var result = this.tokens.First();
            this.tokens.RemoveAt(0);
            return result;
        }

        private void UndoToken(string token)
        {
            this.tokens.Insert(0, token);
        }

        public Expression ParseSimple()
        {
            var token = NextToken();

            if (Char.IsDigit(token[0]))
            {
                return new Expression(token);
            }

            if (token == "(")
            {
                var result = Parse();
                if (NextToken() != ")")
                {
                    throw new ApplicationException(") expected");
                }

                return result;
            }

            var arguments = ParseSimple();
            return new Expression(token, arguments);
        }

        private int Priority(string token)
        {
            switch (token)
            {
                case "+":
                    return 1;
                case "*":
                    return 1;
                default: 
                    return 0;
            }
        }

        Expression ParseBinary(int minPriority)
        {
            var left = ParseSimple();

            while (true)
            {
                var operation = NextToken();

                if (operation == String.Empty)
                {
                    return left;
                }

                if (operation == ")")
                {
                    UndoToken(operation);
                    return left;
                }

                var prio = Priority(operation);
                if (prio < minPriority)
                {
                    UndoToken(operation);
                    return left;
                }

                var right = ParseBinary(prio);
                left = new Expression(operation, left, right);
            }
        }



        public Expression Parse()
        {
            return ParseBinary(0);
        }

        public long Evaluate()
        {
            var ex = Parse();
            return ex.Value;
        }
    }
}