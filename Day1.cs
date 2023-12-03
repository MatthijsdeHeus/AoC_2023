namespace AoC_2023;

public class Day1
{
    public static void Part1(List<string> input)
    {
        int endresult = 0;

        foreach (string s in input)
        {
            string result = "";
            foreach (char c in s)
            {

                if (char.IsDigit(c))
                {
                    result += int.Parse(c.ToString());
                    break;
                }
            }

            char[] temp = s.ToCharArray();
            Array.Reverse(temp);
            string temp2 = new(temp);

            foreach (char c in temp2)
            {

                if (char.IsDigit(c))
                {
                    result += int.Parse(c.ToString());
                    break;
                }
            }

            endresult += int.Parse(result);

        }

        Console.WriteLine(endresult);
    }

    public static void Part2(List<string> input)
    {
        int endresult = 0;

        foreach (string s in input)
        {
            string result = "";

            string searchSpace = "";

            for (int i = 0; i < s.Length; i++)
            {
                searchSpace += s[i].ToString();

                if (char.IsDigit(s[i]))
                {
                    result += s[i].ToString();
                    break;
                }

                if (searchSpace.Contains("one"))
                {
                    result += "1";
                    break;
                }

                if (searchSpace.Contains("two"))
                {
                    result += "2";
                    break;
                }

                if (searchSpace.Contains("three"))
                {
                    result += "3";
                    break;
                }

                if (searchSpace.Contains("four"))
                {
                    result += "4";
                    break;
                }

                if (searchSpace.Contains("five"))
                {
                    result += "5";
                    break;
                }

                if (searchSpace.Contains("six"))
                {
                    result += "6";
                    break;
                }

                if (searchSpace.Contains("seven"))
                {
                    result += "7";
                    break;
                }

                if (searchSpace.Contains("eight"))
                {
                    result += "8";
                    break;
                }

                if (searchSpace.Contains("nine"))
                {
                    result += "9";
                    break;
                }
            }

            char[] temp = s.ToCharArray();

            searchSpace = "";

            for (int i = temp.Length - 1; i >= 0; i--)
            {

                searchSpace = temp[i].ToString() + searchSpace;

                if (char.IsDigit(s[i]))
                {
                    result += s[i].ToString();
                    break;
                }

                if (searchSpace.Contains("one"))
                {
                    result += "1";
                    break;
                }

                if (searchSpace.Contains("two"))
                {
                    result += "2";
                    break;
                }

                if (searchSpace.Contains("three"))
                {
                    result += "3";
                    break;
                }

                if (searchSpace.Contains("four"))
                {
                    result += "4";
                    break;
                }

                if (searchSpace.Contains("five"))
                {
                    result += "5";
                    break;
                }

                if (searchSpace.Contains("six"))
                {
                    result += "6";
                    break;
                }

                if (searchSpace.Contains("seven"))
                {
                    result += "7";
                    break;
                }

                if (searchSpace.Contains("eight"))
                {
                    result += "8";
                    break;
                }

                if (searchSpace.Contains("nine"))
                {
                    result += "9";
                    break;
                }
            }

            endresult += int.Parse(result);
        }

        Console.WriteLine(endresult);
    }
}