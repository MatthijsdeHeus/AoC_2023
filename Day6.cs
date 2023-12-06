using System;
using System.ComponentModel;

namespace AoC_2023;

public class Day6
{
    public static void Part1(List<string> input)
    {
        int[] times = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..^0].Select(int.Parse).ToArray();
        int[] distance = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..^0].Select(int.Parse).ToArray();

        int result = 1;

        for (int i = 0; i < times.Length; i++)
        {
            int temp = 0;

            for (int timeHeldDown = 0; timeHeldDown <= times[i]; timeHeldDown++)
            {
                int newDist = (times[i] - timeHeldDown) * timeHeldDown;
                
                if (newDist > distance[i])
                {
                    temp++;
                }
            }

            result *= temp;
        }

        Console.WriteLine(result);
    }

    public static void Part2(List<string> input)
    {
        long[] times = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..^0].Select(long.Parse).ToArray();
        long[] distance = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..^0].Select(long.Parse).ToArray();

        int result = 1;

        for (int i = 0; i < times.Length; i++)
        {
            int temp = 0;

            for (int timeHeldDown = 0; timeHeldDown <= times[i]; timeHeldDown++)
            {
                long newDist = (times[i] - timeHeldDown) * timeHeldDown;

                if (newDist > distance[i])
                {
                    temp++;
                }
            }

            result *= temp;
        }

        Console.WriteLine(result);
    }
}
