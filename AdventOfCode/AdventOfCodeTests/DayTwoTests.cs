using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Days._2;

namespace AdventOfCodeTests
{
    [TestFixture]
    public class DayTwoTests
    {
        [Test]
        public void RunExampleOne()
        {
            var input = new int[]{ 1, 0, 0, 0, 99 };
            var expectedOutput = new int[]{ 2, 0, 0, 0, 99 };

            Calculate(input, expectedOutput);
        }

        [Test]
        public void RunExampleTwo()
        {
            var input = new int[] { 2, 3, 0, 3, 99 };
            var expectedOutput = new int[] { 2, 3, 0, 6, 99 };

            Calculate(input, expectedOutput);
        }

        [Test]
        public void RunExampleThree()
        {
            var input = new int[] { 2, 4, 4, 5, 99, 0 };
            var expectedOutput = new int[] { 2, 4, 4, 5, 99, 9801 };

            Calculate(input, expectedOutput);
        }

        [Test]
        public void RunExampleFour()
        {
            var input = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            var expectedOutput = new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 };

            Calculate(input, expectedOutput);
        }

        [Test]
        public void RunChallengeOne()
        {
            var input = CreateMemory();

            input[1] = 12;
            input[2] = 2;

            var expectedOutput = new int[]
            {
                4138687, 12, 2, 2, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5, 0, 3, 2, 6, 1, 24, 1, 19, 10, 28, 2, 13, 23, 140, 1, 5,
                27, 141, 2, 6, 31, 282, 1, 6, 35, 284, 2, 39, 9, 852, 1, 5, 43, 853, 1, 13, 47, 858, 1, 10, 51, 862, 2,
                55, 10, 3448, 2, 10, 59, 13792, 1, 9, 63, 13795, 2, 67, 13, 68975, 1, 71, 6, 68977, 2, 6, 75, 137954, 1,
                5, 79, 137955, 2, 83, 9, 413865, 1, 6, 87, 413867, 2, 91, 6, 827734, 1, 95, 6, 827736, 2, 99, 13,
                4138680, 1, 6, 103, 4138682, 1, 2, 107, 4138684, 1, 111, 9, 0, 99, 2, 14, 0, 0
            };

            Calculate(input, expectedOutput);

        }

        [Test]
        public void RunChallengeTwo()
        {
            var runner = new DayTwo();
            int result = 0;
            foreach (var noun in Enumerable.Range(0, 100))
            {
                foreach (var verb in Enumerable.Range(0, 100))
                {
                    var input = CreateMemory();

                    input[1] = noun;
                    input[2] = verb;

                    var output = runner.RunProgram(input)[0];
                    if (output == 19690720)
                    {
                        result = 100 * noun + verb;
                    }
                }
            }

            Assert.AreEqual(6635, result);
        }

        private static int[] CreateMemory()
        {
            return new[]
            {
                1, 0, 0, 3, 
                1, 1, 2, 3, 
                1, 3, 4, 3, 
                1, 5, 0, 3, 
                2, 6, 1, 19, 
                1, 19, 10, 23, 
                2, 13, 23, 27, 
                1, 5, 27, 31,
                2, 6, 31, 35, 
                1, 6, 35, 39, 
                2, 39, 9, 43, 
                1, 5, 43, 47, 
                1, 13, 47, 51, 
                1, 10, 51, 55, 
                2, 55, 10, 59, 
                2, 10, 59, 63, 
                1, 9, 63, 67, 
                2, 67, 13, 71, 
                1, 71, 6, 75, 
                2, 6, 75, 79, 
                1, 5, 79, 83, 
                2, 83, 9, 87, 
                1, 6, 87, 91, 
                2, 91, 6, 95, 
                1, 95, 6, 99, 
                2, 99, 13, 103, 
                1, 6, 103, 107, 
                1, 2, 107, 111, 
                1, 111, 9, 0, 
                99, 2, 14, 0, 
                0
            };
        }

        private void Calculate(int[] input, int[] expectedOutput)
        {
            var runner = new DayTwo();
            var output = runner.RunProgram(input);
            CollectionAssert.AreEqual(expectedOutput, output);
        } 
    }
}
