namespace AoC_2023
{
    public static class Utils
    {
        public static List<string> GetInput(int day, bool test)
        {
            string[] textFile = test == false ? File.ReadAllLines($"../../../Input/{day}.txt") : File.ReadAllLines($"../../../Input/{day}.txt");
            List<string> input = new(textFile);

            return input;
        }
    }
}
