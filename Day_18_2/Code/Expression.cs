using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_18_2
{
    public class Expression
    {
        private string token;
        private List<Expression> arguments = new List<Expression>();

        public Expression(string token)
        {
            this.token = token;
        }

        public Expression(string token, Expression ex)
        {
            this.token = token;
            this.arguments.Add(ex);
        }

        public Expression(string token, Expression left, Expression right)
        {
            this.token = token;
            this.arguments.Add(left);
            this.arguments.Add(right);
        }

        public long Value
        {
            get
            {
                if (arguments.Count == 0)
                {
                    return Int64.Parse(token);
                }

                if (arguments.Count == 1)
                {
                    return Int64.Parse(token);
                }
                else
                {
                    var left = this.arguments[0].Value;
                    var right = this.arguments[1].Value;
                    switch (this.token)
                    {
                        case "+":
                            return left + right;
                        case "*":
                            return left * right;
                        default:
                            throw new ApplicationException("Unknown operation");
                    }
                }
            }
        }

        public override string ToString()
        {
            var result = token;

            if (arguments.Any())
            {
                result += "  (" + String.Join(",", arguments) + ")";
            }
            return result;
        }
    }
}