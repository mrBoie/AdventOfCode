using System;
using System.Net.Http;
using System.Threading.Tasks;
using AdventOfCode.Days._1;

namespace AdventOfCode
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("What day:challenge?");
            foreach (var challenge in Enum.GetNames(typeof(Challenges)))
            {
                Console.WriteLine(challenge);
            }
            
            var input = Console.ReadLine();

            switch (Enum.Parse(typeof(Challenges), input))
            {
                case Challenges.FuelMassModule:
                    Console.WriteLine(DayOne.RunChallengeOne(DayOne.MassOfModules()));
                    break;
                case Challenges.FuelMassFuelModule:
                    Console.WriteLine(DayOne.RunChallengeTwo(DayOne.MassOfModules()));
                    break;
            }
        }


        private static string GetInput(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }

    public enum Challenges
    {
        FuelMassModule,
        FuelMassFuelModule,
    }
}
