using System;
using System.ComponentModel;

namespace AoC_2023;

public class Day5
{
    public static void Part1(List<string> input)
    {
        (List<long> seeds, Dictionary<(string, long, long), Func<long, long>> map) = ParseInput(input);

        long lowestLocation = long.MaxValue;

        foreach (long seed in seeds)
        {
            long soil = convertType(map, "seed-to-soil", seed);
            long fertilizer = convertType(map, "soil-to-fertilizer", soil);
            long water = convertType(map, "fertilizer-to-water", fertilizer);
            long light = convertType(map, "water-to-light", water);
            long temperature = convertType(map, "light-to-temperature", light);
            long humidity = convertType(map, "temperature-to-humidity", temperature);
            long location = convertType(map, "humidity-to-location", humidity);

            if (location < lowestLocation)
            {
                lowestLocation = location;
            }
        }

        Console.WriteLine(lowestLocation);
    }

    public static void Part2(List<string> input)
    {
        (List<long> seeds, Dictionary<(string, long, long), Func<long, long>> map) = ParseInput2(input);

        seeds.Sort();

        long lowestLocation = long.MaxValue;

        for (int i = 0; i < seeds.Count; i++)
        {
            if(i % 1000000 == 0) Console.WriteLine("Currently at " + i + "/" + seeds.Count);


            long soil = convertType(map, "seed-to-soil", seeds[i]);
            long fertilizer = convertType(map, "soil-to-fertilizer", soil);
            long water = convertType(map, "fertilizer-to-water", fertilizer);
            long light = convertType(map, "water-to-light", water);
            long temperature = convertType(map, "light-to-temperature", light);
            long humidity = convertType(map, "temperature-to-humidity", temperature);
            long location = convertType(map, "humidity-to-location", humidity);

            if (location < lowestLocation)
            {
                lowestLocation = location;
            }
        }

        Console.WriteLine(lowestLocation);
    }

    public static (List<long>, Dictionary<(string, long, long), Func<long, long>>) ParseInput(List<string> input)
    {
        List<long> seeds = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..^0].Select(s => long.Parse(s)).ToList();

        Dictionary<(string, long, long), Func<long, long>> map = new Dictionary<(string, long, long), Func<long, long>>();

        for (int i = 2; i < input.Count; i++)
        {
            string mapType = input[i].Split(' ')[0];

            i++;

            while (i < input.Count && input[i] != "")
            {
                string[] lineSplit = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                long sourceStart = long.Parse(lineSplit[1]);
                long range = long.Parse(lineSplit[2]);
                long destinationStart = long.Parse(lineSplit[0]);

                map[(mapType, sourceStart, range)] = x => x + destinationStart - sourceStart;

                i++;
            }
        }

        return (seeds, map);
    }

    public static (List<long>, Dictionary<(string, long, long), Func<long, long>>) ParseInput2(List<string> input)
    {
        List<long> seeds = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries)[1..^0].Select(s => long.Parse(s)).ToList();

        List<long> allSeeds = new List<long>();

        for (int j = 0; j < seeds.Count; j += 2)
        {
            for(long index = seeds[j]; index < seeds[j] + seeds[j + 1]; index++)
            {
                allSeeds.Add(index);
            }
        }

        Dictionary<(string, long, long), Func<long, long>> map = new Dictionary<(string, long, long), Func<long, long>>();

        for (int i = 2; i < input.Count; i++)
        {
            string mapType = input[i].Split(' ')[0];

            i++;

            while (i < input.Count && input[i] != "")
            {
                string[] lineSplit = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                long sourceStart = long.Parse(lineSplit[1]);
                long range = long.Parse(lineSplit[2]);
                long destinationStart = long.Parse(lineSplit[0]);

                map[(mapType, sourceStart, range)] = x => x + destinationStart - sourceStart;

                i++;
            }
        }

        return (allSeeds, map);
    }

    public static long convertType(Dictionary<(string, long, long), Func<long, long>> map, string mapType, long input)
    {
        foreach ((string maptype, long start, long range) in map.Keys)
        {
            if (maptype == mapType && start <= input && input < start + range)
            {
                return map[(maptype, start, range)](input);
            }
        }

        return input;
    }
}
