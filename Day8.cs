using System;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace AoC_2023;

public class Day8
{
    public static void Part1(List<string> input)
    {
        List<char> instructions = new List<char>();

        for (long i = 0; i < 99999999999; i++)
        {
            char[] chars = input[0].ToCharArray();

            for (int j = 0; j < chars.Length; j++)
            {
                instructions.Add(chars[j]);
            }
        }

        string current = "AAA";

        int stepsTaken = 0;

        Dictionary<(string, char), string> map = new Dictionary<(string, char), string>();

        for (int i = 2; i < input.Count; i++)
        {
            string[] inputSplit = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string from = inputSplit[0];

            string left = inputSplit[2].Remove(0, 1);
            left = left.Remove(left.Length - 1, 1);
            string right = inputSplit[3];
            right = right.Remove(right.Length - 1, 1);

            map[(from, 'L')] = left;
            map[(from, 'R')] = right;
        }

        foreach (char instruction in instructions)
        {
            current = map[(current, instruction)];

            stepsTaken++;

            if (current == "ZZZ")
            {
                break;
            }
        }

        Console.WriteLine(stepsTaken);
    }

    public static void Part2(List<string> input)
    {
        List<char> instructions = new List<char>();

        char[] chars = input[0].ToCharArray();

        for (int j = 0; j < chars.Length; j++)
        {
            instructions.Add(chars[j]);
        }

        List<string> current = new List<string>();

        Dictionary<(string, char), string> map = new Dictionary<(string, char), string>();
        
        for (int i = 2; i < input.Count; i++)
        {
            string[] inputSplit = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string from = inputSplit[0];

            string left = inputSplit[2].Remove(0, 1);
            left = left.Remove(left.Length - 1, 1);
            string right = inputSplit[3];
            right = right.Remove(right.Length - 1, 1);

            map[(from, 'L')] = left;
            map[(from, 'R')] = right;

            if (from[from.Length - 1] == 'A')
            {
                current.Add(from);
            }
        }

        int[] firstZ = new int[current.Count];

        for (int i = 0; i < current.Count; i++)
        {
            int stepsTaken = 0;

            for (int instructionIndex = 0; instructionIndex < instructions.Count; instructionIndex++)
            {
                char currentInstruction = instructions[instructionIndex];

                current[i] = map[(current[i], currentInstruction)];

                stepsTaken++;


                if (current[i][current[i].Length - 1] == 'Z')
                {
                    firstZ[i] = stepsTaken;
                    break;
                }

                if (instructionIndex == instructions.Count - 1)
                {
                    instructionIndex = -1;
                }
            }
        }

        foreach (int i in firstZ)
        {
            Console.WriteLine(i);
        }

        // plug results in least common multiple calculator online
    }
}
