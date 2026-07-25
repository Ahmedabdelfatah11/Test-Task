using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FizzBuzz.Models;

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
                    "inputWord length must be between 7 and 100 characters.");

            // TODO: implement fizzbuzz logic
            return new OverlappingResult
            {
                OutputString = inputWord,
                Count = 0
            };
        }
    }
}
