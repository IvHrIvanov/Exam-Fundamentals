using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Text;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string pattern = @"((::)|(\*\*))[A-Z][a-z]{2,}\1";
            Regex regex = new Regex(pattern);
            string input = Console.ReadLine();
            BigInteger sumTextDigits = 1;
            foreach (var item in input)
            {

                if (Char.IsDigit(item))
                {
                    sumTextDigits *= BigInteger.Parse(item.ToString());
                }

            }

            sb.AppendLine($"Cool threshold: {sumTextDigits}");

            MatchCollection emojiColection = regex.Matches(input);
            sb.AppendLine($"{emojiColection.Count} emojis found in the text. The cool ones are:");

            foreach (Match item in emojiColection)
            {
                BigInteger sumCoolEmojiDigits = 0;

                foreach (var currentNumber in item.ToString())
                {
                    if (Char.IsLetter(currentNumber))
                    {
                        sumCoolEmojiDigits += (BigInteger)currentNumber;
                    }
                }
                if (sumCoolEmojiDigits >= sumTextDigits)
                {
                    sb.AppendLine(item.ToString().TrimEnd());
                }
            }
            Console.WriteLine(sb);
        }
    }
}
