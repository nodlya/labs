using System;
using System.Threading;

namespace RunningText
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваш текст");
            string s = Console.ReadLine();
            Print(s);
        }

        static void Print(string s)
        {
            int k = 0;
            for (int i = 0; i < s.Length; i++)
                if (Convert.ToChar(s[i]) == '.')
                    k++;

            for (int j=1; j<=k; j++)
            {
            if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    for (int i = 0; i <= s.IndexOf("."); i++)
                    {
                        Console.Write(s[i]);
                        Thread.Sleep(50);
                    }
                    if (j!=k)
                    s = s.Substring(s.IndexOf(".")+2);

                }
            }
            
        }


    }
}
