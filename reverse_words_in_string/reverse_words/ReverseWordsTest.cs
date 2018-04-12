using NUnit.Framework;

namespace reverse_words
{
    [TestFixture]
    public class ReverseWordsTest
    {
        [TestCase("foo", "oof")]
        [TestCase("foo bar cake", "oof rab ekac")]
        public void Should_reverse_words_in_string(string sentence, string expected)
        {
            var wordProcessor = new WordProcessor();
            var actual = wordProcessor.Reverse(sentence);
            Assert.AreEqual(expected, actual);
        }
    }

    public class WordProcessor
    {
        public string Reverse(string sentence) // O(n)
        {
            var delimiter = ' ';
            var reversedSetence = string.Empty;
            var reversedWord = string.Empty;

            for (var i = sentence.Length -1; i > -1;i--)
            {
                if (sentence[i] == delimiter)
                {
                    reversedSetence = delimiter + reversedWord + reversedSetence;
                    reversedWord = string.Empty;
                    continue;
                }

                reversedWord += sentence[i];

                if (i == 0)
                {
                    reversedSetence = reversedWord + reversedSetence;
                }
            }

            return reversedSetence;
        }
    }
}
