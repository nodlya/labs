using System;
using System.Threading;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите число, чтобы получить его факториал");
            int x = int.Parse(Console.ReadLine());
            Console.Clear();
            //print(Factorial(x));
            flashlights(x);
        }

        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }

        static void print(int x)
        {
            Console.Write("╔");
            for (int i = 2; i <= (Convert.ToString(x).Length + 3); i++)
                Console.Write("═");
            Console.Write("╗");
            Console.WriteLine();
            Console.Write("║ " + x + " ║");
            Console.WriteLine();
            Console.Write("╚");
            for (int i = 2; i <= (Convert.ToString(x).Length + 3); i++)
                Console.Write("═");
            Console.Write("╝");
        }

        static void flashlights(int x)
        {
            
            for (int i=0; i<10000; i++)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                print(Factorial(x));
                Thread.Sleep(100);
                Console.Clear();
                Console.ResetColor();
                print(Factorial(x));
                Thread.Sleep(100);

                /* if (Console.ReadKey().Key == ConsoleKey.Enter)
                    break; */
            }
                       
           
        }
    }
}

      
