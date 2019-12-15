using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Days._2
{
    public class DayTwo
    {
        public int[] RunProgram(int[] input)
        {

            return DoStuff(input);
        }

        private int[] DoStuff(int[] input)
        {
            var code = input.ToArray();
            int index = 0;
            while (ExecutableCode(index, code, out var currentInstruction))
            {
                int result;
                switch (currentInstruction.opCode)
                {
                    case 1:
                        code[currentInstruction.targetLocation] = code[currentInstruction.input1Position] + code[currentInstruction.input2Position];
                        break;
                    case 2:
                        code[currentInstruction.targetLocation] = code[currentInstruction.input1Position] * code[currentInstruction.input2Position];
                        break;
                    default:
                        throw new Exception($"{currentInstruction.opCode} is not a valid code, only 99, 1,2 are");
                }
                index = index + 4;
            }
            return code;
        }

        private bool ExecutableCode(int index, int[] code, out (int opCode, int input1Position, int input2Position, int targetLocation) output)
        {
            output = (99, 0, 0, 0);
            if (code[index] == 99)
            {
                return false;
            }

            output = (code[index], code[index + 1], code[index + 2], code[index + 3]);
            return true;
        }
    }
}
