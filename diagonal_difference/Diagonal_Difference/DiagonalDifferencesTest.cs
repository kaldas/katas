using NUnit.Framework;

namespace Diagonal_Difference
{
    [TestFixture]
    public class DiagonalDifferencesTest
    {
        [Test]
        public void Should_get_diagonal_differences()
        {
            var matrix = new[,] { { 11, 2, 4 }, { 4, 5, 6 }, { 10, 8, -12 } };

            var calculator = new DiagonalDifferenceCalculator();
            var actualDifference = calculator.GetDifference(matrix, 3);

            Assert.AreEqual(15, actualDifference);
        }
    }

    public class DiagonalDifferenceCalculator
    {
        public int GetDifference(int[,] matrix, int size)
        {
            var primaryDiagonal = 0;
            var secondaryDiagonal = 0;

            for (int i = 0; i < size; i++)
            {
                primaryDiagonal += matrix[i,i];
                secondaryDiagonal += matrix[i, size - 1 - i];
            }

            var result = primaryDiagonal - secondaryDiagonal;
            if (result < 0)
            {
                result *= -1;
            }

            return result;
        }
    }
}
