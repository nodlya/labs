using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace hangman_x3
{
    public enum Status
    {
        Playing,
        Win,
        Lose
    };
    public static class Info
    {
        public static int triesLeft = 5;
        public readonly static string wordToGuess = WordWork.GetRandomWord();
        public static List<char> lettersTried = new List<char>();
        public static Status status = Status.Playing; 
    }

    public static class WordWork
    {
        public static string GetRandomWord()
        {
            string[] readText = File.ReadAllLines("..\\..\\..\\original.txt");
            Random rnd = new Random();
            return readText[rnd.Next(readText.Length)];
        }
    }

    public static class ScreenGame
    {
        static public void DrawWord()
        {
            Console.Clear();
            for (int i=0; i<Info.wordToGuess.Length; i++)
            {
                bool flag = true;
                foreach (char b in Info.lettersTried)
                {
                    if (b == Info.wordToGuess[i])
                    {
                        Console.Write(b);
                        flag = false;
                    }
                }

                if (flag)
                    Console.Write("_");
            }
        }

        static public void StatusUpdate()
        {
            if (Info.status == Status.Playing)
                if (Info.wordToGuess.Contains
                    (Info.lettersTried[Info.lettersTried.Capacity - 1]))
                    Console.WriteLine("Да, эта буква есть в слове, осталось " +
                        Info.triesLeft + " попыток");
                else
                    Console.WriteLine("Нет, этой буквы в слове нет, осталось " +
                         Info.triesLeft + " попыток");
            else if (Info.status == Status.Lose) Console.WriteLine("Вы проиграли, " +
                "слово было " + Info.wordToGuess);
            else Console.WriteLine("Вы победили!!!");
        }
    }
}
