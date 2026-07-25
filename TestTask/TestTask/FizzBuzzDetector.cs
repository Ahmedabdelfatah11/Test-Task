using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FizzBuzz.Models;
using System.Text;

namespace FizzBuzz
{
    public class FizzBuzzDetector
    {
        private const int MinLength = 7;
        private const int MaxLength = 100;

        public OverlappingResult GetOverlappings(string inputWord)
        {
            if (inputWord == null)
                throw new ArgumentNullException(nameof(inputWord), "inputWord cannot be null.");

            if (inputWord.Length < MinLength || inputWord.Length > MaxLength)
                throw new ArgumentOutOfRangeException(nameof(inputWord),
                    "Input length must be between 7 and 100 characters.");

            var result = new StringBuilder();
            int wordCount = 0;
            int coincidences = 0;
            int i = 0;

            while (i < inputWord.Length)
            {
                // check if current position starts an alphanumeric word
                if (char.IsLetterOrDigit(inputWord[i]))
                {
                    // collect the full word
                    int start = i;
                    while (i < inputWord.Length && (char.IsLetterOrDigit(inputWord[i]) ||
                          (inputWord[i] == '\'' && i + 1 < inputWord.Length && char.IsLetterOrDigit(inputWord[i + 1]))))
                        i++;

                    string word = inputWord.Substring(start, i - start);
                    wordCount++;

                    // apply fizzbuzz rules
                    if (wordCount % 15 == 0)
                    {
                        result.Append("FizzBuzz");
                        coincidences++;
                    }
                    else if (wordCount % 3 == 0)
                    {
                        result.Append("Fizz");
                        coincidences++;
                    }
                    else if (wordCount % 5 == 0)
                    {
                        result.Append("Buzz");
                        coincidences++;
                    }
                    else
                    {
                        result.Append(word);
                    }
                }
                else
                {
                    // not a word, keep it as is (punctuation, spaces, newlines)
                    result.Append(inputWord[i]);
                    i++;
                }
            }

            return new OverlappingResult
            {
                OutputString = result.ToString(),
                Count = coincidences
            };
        }
    }
}


