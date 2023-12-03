using System.Runtime.CompilerServices;

namespace AoC_2023;

public class Day3
{
    public static void Part1(List<string> input)
    {
        string[] map = input.ToArray();

        int resultSum = 0;

        for (int y = 0; y < map.Length; y++)
        {
            string currentLine = map[y];

            string currentNumberString = "";

            for (int x = 0; x < map[y].Length; x++)
            {
                if (Char.IsDigit(currentLine[x])) currentNumberString += currentLine[x];

                if ((!Char.IsDigit(currentLine[x]) && currentNumberString != "") || (x == currentLine.Length - 1 && Char.IsDigit(currentLine[x])))
                {
                    int currentNumber = int.Parse(currentNumberString);

                    Console.WriteLine("Checking number " + currentNumber.ToString());

                    bool addToResult = false;

                    for (int checkY = Math.Min(Math.Max(y - 1, 0), input.Count - 1); checkY <= y + 1 && checkY <= map.Length - 1; checkY++)
                    {
                        int endOfRowModifier = Char.IsDigit(currentLine[x]) ? 0 : 1;
                        for (int checkX = Math.Min(Math.Max(x - currentNumberString.Length - endOfRowModifier, 0), currentLine.Length - 1); checkX < x + 1 && checkX <= currentLine.Length - 1; checkX++)
                        {
                            if (checkY == y && checkX >= x - currentNumberString.Length + (Char.IsDigit(currentLine[x]) ? 1 : 0) && checkX < x + (Char.IsDigit(currentLine[x]) ? 1 : 0)) continue;
                            Console.WriteLine("check x = " + checkX + ", checkY = " + checkY);

                            Char FieldToCheck = input[checkY][checkX];

                            if (FieldToCheck != '.')
                            {
                                
                                addToResult = true;
                            }
                        }
                    }

                    if (addToResult)
                    {
                        resultSum += currentNumber;
                    }

                    currentNumberString = "";
                }
                
            }
        }

        Console.WriteLine(resultSum);

    }

    public static void Part2(List<string> input)
    {
        int numberCounter = 0;
        number[,] map = new number[input.Count, input[0].Length];

        for (int y = 0; y < input.Count; y++)
        {
            string currentNumberString = "";

            for (int x = 0; x < input[0].Length; x++) 
            { 
                if (Char.IsDigit(input[y][x])) currentNumberString += input[y][x];

                if (currentNumberString != "" && (x == input[0].Length - 1 || !Char.IsDigit(input[y][x])))
                {
                    int currentNumber = int.Parse(currentNumberString);

                    if (!Char.IsDigit(input[y][x]))
                    {
                        for (int i = x - currentNumberString.Length; i < x; i++)
                        {
                            map[i, y] = new number
                            {
                                value = currentNumber,
                                id = numberCounter,
                            };
                        }
                    }
                    else
                    {
                        for (int i = x - currentNumberString.Length + 1; i <= x; i++)
                        {
                            map[i, y] = new number
                            {
                                value = currentNumber,
                                id = numberCounter,
                            };
                        }
                    }

                    numberCounter++;
                    currentNumberString = "";
                }
            }
        }

        int result = 0;

        for (int y = 0;  y < input.Count; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                if (input[y][x] == '*')
                {
                    List<int> usedIds = new List<int>();

                    int numberFactor = 1;

                    //Console.WriteLine("found gear at x = " + x + ", y = " + y);

                    for (int dx = -1; dx <= 1; dx++)
                    {
                        for (int dy = -1; dy <= 1; dy++)
                        {
                            if (x + dx >= 0 && x + dx < input[y].Length && y + dy >= 0 && y + dy < input.Count)
                            {
                                //Console.WriteLine("x = " + (x + dx) + ", y = " + (y + dy));
                                if (map[x + dx, y + dy] != null)
                                {
                                    number current = map[x + dx, y + dy];

                                    if (!usedIds.Contains(current.id))
                                    {
                                        usedIds.Add(current.id);
                                        numberFactor = numberFactor * current.value;
                                    }
                                }
                            }
                        }
                    }

                    if (usedIds.Count == 2)
                    {
                        result += numberFactor;
                    }
                }
            }
        }

        Console.WriteLine(result);
    }

    public class number
    {
        public int value;
        public int id;
    }
}