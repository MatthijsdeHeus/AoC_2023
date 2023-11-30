namespace AoC_2023;

public class Day1
{
    public static void Main()
    {
        List<string> input = Utils.GetInput(1, false);

        Part1(input);
        //Part2(input);

        _ = Console.ReadKey();
    }

    public static void Part1(List<string> input)
    {
        foreach (string s in input)
        {
            Console.WriteLine(s);
        }
    }

    public static void Part2(List<string> input)
    {

    }
}