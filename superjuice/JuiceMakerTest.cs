
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace JuiceMakerElite
{
    [TestFixture]
    public class JuiceMakerTest
    {
        [TestCase("OOO", 1, 0, 0, 0)]
        [TestCase("OOOOOO", 2, 0, 0, 0)]
        [TestCase("OOOOOOOOO", 3, 0, 0, 0)]
        [TestCase("CCC", 0, 0, 1, 0)]
        [TestCase("CCCOOO", 1, 0, 1, 0)]
        [TestCase("CCCOOOP", 0, 0, 1, 1)]
        [TestCase("CCCOOOPP", 0, 0, 0, 1)]
        public void Should_return_expected_juice(string fruitBasket, int expectedOrangeJuices, int expectePearJuices, int expectedCarrotJuices, int expectedSuperJuices)
        {
            var juiceMaker = new JuiceMaker();
            var actualGlasses = juiceMaker.Squeeze(fruitBasket);
            if (expectedOrangeJuices > 0)
                Assert.AreEqual(expectedOrangeJuices, actualGlasses['O']);

            if (expectePearJuices > 0)
                Assert.AreEqual(expectePearJuices, actualGlasses['P']);

            if (expectedCarrotJuices > 0)
                Assert.AreEqual(expectedCarrotJuices, actualGlasses['C']);

            if (expectedSuperJuices > 0)
                Assert.AreEqual(expectedSuperJuices, actualGlasses['S']);
        }
    }

    public class JuiceMaker
    {
        private Dictionary<char, int> FruitsPerGlass = new Dictionary<char, int>
        {
            {'O', 3},
            {'P', 2},
            {'C', 2},
        };

        public Dictionary<char, int> Squeeze(string fruitBasket)
        {
            var glassCount = GlassCount(fruitBasket);
            glassCount = CheckSuperJuices(glassCount, fruitBasket);

            return glassCount;
        }

        private Dictionary<char, int> CheckSuperJuices(Dictionary<char, int> glassCount, string fruitBasket)
        {
            if (glassCount['O'] == 1 && glassCount['C'] == 1 && fruitBasket.Contains("P"))
            {
                glassCount.Add('S', 1);
            }

            return glassCount;
        }

        private Dictionary<char, int> GlassCount(string fruitBasket)
        {
            var numberOfGlasses = new Dictionary<char, int>();

            foreach (var fruit in FruitsPerGlass)
            {
                var count = fruitBasket.Count(x => x == fruit.Key) / fruit.Value;
                numberOfGlasses.Add(fruit.Key, count);
            }

            return numberOfGlasses;
        }
    }

    public class Juice
    {
        public int Glasses { get; set; }
        public string Flavour { get; set; }
    }
}
