using System;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        string[] phrases = new[]
        {
            "Love you. Love you. Love you. Love you. Love you. ", // Angel 💓💓💓
            "Love me. Love me. Love me. Love me. Love me. ", // Imagine someone reading this code💀💀💀
            "Why not me?", // Mitski core
            "Love me, please...", // corny sad depressed teenager ahh phrase💀💀💀
        };
        ConsoleColor[] colors = Enum.GetValues(typeof(ConsoleColor))
                                    .Cast<ConsoleColor>()
                                    .Where(c => c != ConsoleColor.Black)
                                    .ToArray();

        Random rand = new Random();
        Console.CursorVisible = false;
        Console.Clear();

        while (true)
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            for (int i = 0; i < windowHeight; i++)
            {
                string phrase = phrases[rand.Next(phrases.Length)];
                int dramaLevel = rand.Next(3);

                switch (dramaLevel)
                {
                    case 0:
                        phrase = phrase.ToLower();
                        break;
                    case 1:
                        break;
                    case 2:
                        phrase = string.Concat(phrase.ToUpper().Select(c => c + " "));
                        break;
                }

                string line = new string(phrase.ToCharArray().Select(c => c).ToArray());
                int maxStart = Math.Max(0, windowWidth - line.Length);
                int startPosition = rand.Next(Math.Max(1, maxStart));
                Console.ForegroundColor = colors[rand.Next(colors.Length)];
                Console.SetCursorPosition(startPosition, i);
                Console.Write(line);
            }

            Thread.Sleep(rand.Next(300, 800));

            if (rand.Next(100) > 90)
            {
                string chaosLine = phrases[rand.Next(phrases.Length)].ToUpper();
                Console.SetCursorPosition(rand.Next(Console.WindowWidth - chaosLine.Length), rand.Next(Console.WindowHeight));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(chaosLine);
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}