using System.Transactions;

namespace AoC_2023;

public class Day2
{
    public static void Part1(List<string> input)
    {
        int result = 0;

        foreach (string line in input)
        {
            string[] splitString = line.Split(" ");

            int gameId = int.Parse(splitString[1].Remove(splitString[1].Length - 1, 1));

            Char[] charsToSplitOn = { ':', ';' };
            string[] splitLine = line.Split(charsToSplitOn);

            bool gamePossible = true;

            for (int i = 1; i < splitLine.Length; i++)
            {
                string[] cubes = splitLine[i].Split(',');

                foreach (string cube in cubes)
                {
                    int amountOfCubes = int.Parse(cube.Trim().Split(' ')[0]);
                    string colorOfCube = cube.Trim().Split(' ')[1];



                    if (colorOfCube == "red" && amountOfCubes > 12)
                    {
                        gamePossible = false;
                    }

                    if (colorOfCube == "green" && amountOfCubes > 13)
                    {
                        gamePossible = false;
                    }

                    if (colorOfCube == "blue" && amountOfCubes > 14)
                    {
                        gamePossible = false;
                    }

                }
            }

            if (gamePossible == true)
            {
                result += gameId;
            }
        }

        Console.WriteLine(result);
    }

    public static void Part2(List<string> input)
    {
        int result = 0;

        foreach (string line in input)
        {
            string[] splitString = line.Split(" ");

            int gameId = int.Parse(splitString[1].Remove(splitString[1].Length - 1, 1));

            Char[] charsToSplitOn = { ':', ';' };
            string[] splitLine = line.Split(charsToSplitOn);

            bool gamePossible = true;

            int minAmountOfGreen = 0;
            int minAmountOfRed = 0;
            int minAmountOfBlue = 0;

            for (int i = 1; i < splitLine.Length; i++)
            {
                string[] cubes = splitLine[i].Split(',');

                foreach (string cube in cubes)
                {
                    int amountOfCubes = int.Parse(cube.Trim().Split(' ')[0]);
                    string colorOfCube = cube.Trim().Split(' ')[1];

                    if (colorOfCube == "red" && amountOfCubes > minAmountOfRed)
                    {
                        minAmountOfRed = amountOfCubes;
                    }

                    if (colorOfCube == "green" && amountOfCubes > minAmountOfGreen)
                    {
                        minAmountOfGreen = amountOfCubes;
                    }

                    if (colorOfCube == "blue" && amountOfCubes > minAmountOfBlue)
                    {
                        minAmountOfBlue = amountOfCubes;
                    }

                }
            }

            result += minAmountOfRed * minAmountOfGreen * minAmountOfBlue;
        }

        Console.WriteLine(result);
    }
}