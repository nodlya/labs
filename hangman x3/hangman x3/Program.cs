using System;

namespace hangman_x3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (Info.status==Status.Playing)
            {
                ScreenGame.DrawWord();
                Info.lettersTried.Add(Convert.ToChar(Console.ReadLine()));
                if (!Info.wordToGuess.Contains
                    (Info.lettersTried[Info.lettersTried.Count - 1]))
                    Info.triesLeft--;
                if (Info.triesLeft == 0)
                    Info.status = Status.Lose;
                int tried = 0;
                for (int i = 0; i < Info.wordToGuess.Length; i++)
                    foreach (char b in Info.lettersTried)
                        if (b == Info.wordToGuess[i])
                            tried++;
                if (tried == Info.wordToGuess.Length)
                    Info.status = Status.Win;

                ScreenGame.StatusUpdate();
            }
        }
    }
}
