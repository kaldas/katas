using NUnit.Framework;

namespace Kadane
{
    [TestFixture]
    public class KadaneTest
    {
        [TestCase(new[] { 1, -3, 2, 1, -2 }, 3)]
        [TestCase(new[] { -5, 1, -1 }, 1)]
        [TestCase(new[] { 7, 5, 6, -3 }, 18)]
        public void Should_get_max_sub_sequence(int [] sequence, int expectedResult)
        {
            var kadane = new Kadane();
            var actualResult = kadane.GetMaxSubSequence(sequence);
            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    public class Kadane
    {
        public int GetMaxSubSequence(int[] sequence)  // O(n)
        {
            var sumOfMaxSequence = 0;

            foreach (var item in sequence)
            {
                if (item >= sumOfMaxSequence)
                {
                    sumOfMaxSequence = item;
                }
                else if (item + sumOfMaxSequence >= sumOfMaxSequence)
                {
                    sumOfMaxSequence = item + sumOfMaxSequence;
                }
            }

            return sumOfMaxSequence;
        }
    }
}
