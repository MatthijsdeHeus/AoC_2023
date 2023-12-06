using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023;

public class Program
{
    public static void Main()
    {
        List<string> input = GetInput(6, false);

        //Day6.Part1(input);
        Day6.Part2(input);

        Console.ReadKey();
    }

    public static List<string> GetInput(int day, bool test)
    {
        string[] textFile = test == false ? File.ReadAllLines($"../../../Input/{day}.txt") : File.ReadAllLines($"../../../Input/{day}_test.txt");
        List<string> input = new(textFile);

        return input;
    }
}
