using System;
using AdventOfCode.Days._1;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class DayOneTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(12,2)]
        [TestCase(14,2)]
        [TestCase(1969,654)]
        [TestCase(100756,33583)]
        public void Module_Consumption(int mass, int expectedResult)
        {
            var result = AdventOfCode.Days._1.DayOne.CalculateFuelRequirementForModule(mass);
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        [TestCase(2,0)]
        [TestCase(654,312)]
        [TestCase(33583, 16763)]
        public void Module_Fuel_Consumption(int mass, int expectedFuel)
        {
            var result = AdventOfCode.Days._1.DayOne.CalculateFuelMass(mass);
            Assert.AreEqual(expectedFuel, result);
        }

        [Test]
        [TestCase(14, 2)]
        [TestCase(1969, 966)]
        [TestCase(100756, 50346)]
        public void DayOneChallenge2(int mass, int expectedFuel)
        {
            var result = AdventOfCode.Days._1.DayOne.RunChallengeTwo(new int[]{mass});
            Assert.AreEqual(expectedFuel, result);
        }

        [Test]
        public void DayOneChallenge2_Run()
        {
            var result = AdventOfCode.Days._1.DayOne.RunChallengeTwo(AdventOfCode.Days._1.DayOne.MassOfModules());
            Assert.AreEqual(4891620, result);
        }
    }
}