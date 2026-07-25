using FizzBuzz;
using System.Text;
using FizzBuzz;

namespace TestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your text (enter an empty line when done):");

            string input = "";
            string line;

            while ((line = Console.ReadLine()) != "")
            {
                if (input != "")
                    input += "\n";
                input += line;
            }

            var detector = new FizzBuzzDetector();
            var result = detector.GetOverlappings(input);

            Console.WriteLine("\nOutput:");
            Console.WriteLine(result.OutputString);
            Console.WriteLine("\nCount: " + result.Count);

        }
    }
}
