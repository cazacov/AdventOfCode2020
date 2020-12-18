using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_18_2
{
    public class Calculator
    {
        private readonly List<string> tokens;

        public Calculator(string str)
        {
            var tok = new List<string>();
            var pos = 0;
            do
            {
                var result = String.Empty;
                while (char.IsWhiteSpace(str[pos]))
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
                tok.Add(result);
            } while (pos < str.Length);

            // Reverse tokens
            this.tokens = new List<string>();
            foreach (var t in tok)
            {
                switch (t)
                {
                    case "(":
                        tokens.Insert(0, ")");
                        break;
                    case ")":
                        tokens.Insert(0, "(");
                        break;
                    default:
                        tokens.Insert(0, t);
                        break;
                }
            }
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

        private Expression ParseSimple()
        {
            var token = NextToken();

            if (char.IsDigit(token[0]))
            {
                return new Expression(token);
            }

            if (token == "(")
            {
                var result = Parse();
                if (NextToken() != ")")
                {
                    throw new ApplicationException("Wrong input, ')' expected");
                }
                return result;
            }

            var arguments = ParseSimple();
            return new Expression(token, arguments);
        }

        private int Priority(string token)
        {
            return token switch
            {
                "+" => 2,
                "*" => 1,
                _ => 0
            };
        }

        private Expression ParseBinary(int minPriority)
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

        private Expression Parse()
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