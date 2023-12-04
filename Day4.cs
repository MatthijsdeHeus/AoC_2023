namespace AoC_2023;

public class Day4
{
    public static void Part1(List<string> input)
    {
        int result = 0;

        for (int i = 0; i < input.Count; i++)
        {
            string line = input[i];

            string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string[] winningNumbers = { words[2], words[3], words[4], words[5], words[6], words[7], words[8], words[9], words[10], words[11] };
            string[] ticketNumbers = { words[13], words[14], words[15], words[16], words[17], words[18], words[19], words[20], words[21], words[22], words[23], words[24], words[25], words[26], words[27], words[28], words[29], words[30], words[31], words[32], words[33], words[34], words[35], words[36], words[37] };

            bool wonOnce = false;

            int currentWinnings = 0;

            foreach (string ticketNumber in ticketNumbers)
            {
                if (winningNumbers.Contains(ticketNumber))
                {
                    if (!wonOnce)
                    {
                        wonOnce = true;
                        currentWinnings = 1;
                    }
                    else
                    {
                        currentWinnings = currentWinnings * 2;
                    }
                }
            }

            result += currentWinnings;
        }

        Console.WriteLine(result);
    }

    public static void Part2(List<string> input)
    {
        Dictionary<int, int> ticketAmountDictionary = new Dictionary<int, int>();

        ticketAmountDictionary[0] = 1;

        for (int i = 0; i < input.Count; i++)
        {
            Console.WriteLine("Currently at ticket " + (i+1).ToString() + "/" + input.Count);

            if (!ticketAmountDictionary.ContainsKey(i)) ticketAmountDictionary[i] = 1;

            for(int j = 0; j < ticketAmountDictionary[i]; j++)
            {
                string line = input[i];

                string[] words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string[] winningNumbers = { words[2], words[3], words[4], words[5], words[6], words[7], words[8], words[9], words[10], words[11] };
                string[] ticketNumbers = { words[13], words[14], words[15], words[16], words[17], words[18], words[19], words[20], words[21], words[22], words[23], words[24], words[25], words[26], words[27], words[28], words[29], words[30], words[31], words[32], words[33], words[34], words[35], words[36], words[37] };

                int amountOfMatches = 0;

                foreach (string ticketNumber in ticketNumbers)
                {
                    if (winningNumbers.Contains(ticketNumber))
                    {
                        amountOfMatches++;
                    }
                }

                for (int k = 0; k < amountOfMatches; k++) 
                {
                    if (ticketAmountDictionary.ContainsKey(i + k + 1))
                    {
                        ticketAmountDictionary[i + k + 1]++;
                    } else
                    {
                        ticketAmountDictionary[i + k + 1] = 2;
                    }
                    
                }
            }
        }

        int totalTicketAmount = 0;

        foreach(int index in ticketAmountDictionary.Keys)
        {
            totalTicketAmount += ticketAmountDictionary[index];
        }

        Console.WriteLine(totalTicketAmount);
    }
}