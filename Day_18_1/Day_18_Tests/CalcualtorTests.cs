using NUnit.Framework;
using Day_18_1;

namespace Day_18_Tests
{
    public class CalcualtorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleNumber()
        {
            var expression = "123";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(123));
        }

        [Test]
        public void Addition()
        {
            var expression = "1 + 3";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(4));
        }

        [Test]
        public void Multiplication()
        {
            var expression = "1 * 3";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        public void Parentheses()
        {
            var expression = "(2 + 3)";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Many()
        {
            var expression = "2 + 3 * 5";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(25));
        }

        [Test]
        public void Prio()
        {
            var expression = "2 + (3 * 5)";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(17));
        }

        [Test]
        public void Example1()
        {
            var expression = "2 * 3 + (4 * 5)";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(26));
        }

        [Test]
        public void Example2()
        {
            var expression = "5 + (8 * 3 + 9 + 3 * 4 * 3)";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(437));
        }

        [Test]
        public void Example3()
        {
            var expression = "5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(12240));
        }

        [Test]
        public void Example4()
        {
            var expression = "((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2";

            var calc = new Calculator(expression);
            var result = calc.Evaluate();
            Assert.That(result, Is.EqualTo(13632));
        }
    }
}