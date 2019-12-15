﻿using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Days._1
{
    public static class DayOne
    {
        public static int CalculateFuelRequirementForModule(int mass)
        {
            return (mass / 3) - 2;
        }

        public static int RunChallengeOne(IEnumerable<int> massOfModules)
        {
            var fuelConsumption = massOfModules.Select(CalculateFuelRequirementForModule).Sum();

            return fuelConsumption;
        }

        public static int RunChallengeTwo(IEnumerable<int> massOfModules)
        {
            var fuelConsumptions = massOfModules.Select(CalculateFuelRequirementForModule);
            var fuelFuelConsumptions = fuelConsumptions.Select(CalculateFuelMass);

            var fuelMass = fuelConsumptions.Sum() + fuelFuelConsumptions.Sum();

            return fuelMass;
        }

        public static int CalculateFuelMass(int fuelConsumptionforModule)
        {
            var fuelValues = new List<int>();
            var consumption = fuelConsumptionforModule;
            while ((consumption = CalculateFuelRequirementForModule(consumption)) > 0)
            {
                fuelValues.Add(consumption);
            }

            var fuelMass = fuelValues.Sum();
            return fuelMass;
        }

        public static IEnumerable<int> MassOfModules()
        {
            return new int[] { 
            90859,
            127415 ,
            52948 ,
            92106 ,
            106899 ,
            72189 ,
            60084 ,
            79642 ,
            138828 ,
            103609 ,
            149073 ,
            127749 ,
            86976 ,
            104261 ,
            139341 ,
            81414 ,
            102622 ,
            131030 ,
            120878 ,
            96809 ,
            130331 ,
            119212 ,
            52317 ,
            108990 ,
            136871 ,
            67279 ,
            76541 ,
            113254 ,
            77739 ,
            75027 ,
            53863 ,
            97732 ,
            65646 ,
            87851 ,
            63712 ,
            92660 ,
            131821 ,
            127837 ,
            52363 ,
            70349 ,
            66110 ,
            132249 ,
            50319 ,
            125948 ,
            98360 ,
            137675 ,
            61957 ,
            143540 ,
            137402 ,
            135774 ,
            51376 ,
            144833 ,
            118646 ,
            128136 ,
            141140 ,
            82856 ,
            63345 ,
            143617 ,
            79733 ,
            73449 ,
            116126 ,
            73591 ,
            63899 ,
            110409 ,
            79602 ,
            77485 ,
            64050 ,
            131760 ,
            90509 ,
            112728 ,
            55181 ,
            55329 ,
            98597 ,
            126579 ,
            108227 ,
            80707 ,
            92962 ,
            90396 ,
            123775 ,
            125248 ,
            128814 ,
            64593 ,
            63108 ,
            76486 ,
            107135 ,
            111064 ,
            142569 ,
            68579 ,
            149006 ,
            52258 ,
            143477 ,
            131889 ,
            142506 ,
            146732 ,
            58663 ,
            92013 ,
            62410 ,
            71035 ,
            51208 ,
            66372
        };
    }
    }
}