using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Fibonacci_Recursive
{
    [TestFixture]
    public class FibonacciRecursiveTest
    {
        [Test]
        public void Should_get_fibonacci_by_size_of_desired_sequence()
        {
            Assert.AreEqual(34, Fibonacci_A(7));
        }

        [Test]
        public void Should_get_fibonacci_sequence_option_b()
        {
            Assert.AreEqual(5702887, Fibonacci_B(34));
        }

        private int Fibonacci_A(int size, int x = 0, int y = 1)
        {
            if (size == 0)
                return x + y;

            return Fibonacci_A(--size, y, x + y);
        }

        private int Fibonacci_B(int number)
        {
            if (number <= 1)
            {
                return number;
            }

            return Fibonacci_B(number - 1) + Fibonacci_B(number - 2);
        }
    }
}
