using Microsoft.VisualBasic;
using System;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Доброго времени суток!");
            Console.WriteLine("Ввведите своё имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите день вашего рождения");
            int day = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввведите месяц вашего рождения");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ввведите год вашего рождения");
            int year = Convert.ToInt32(Console.ReadLine());
            bool ok = true;

            if (!((year <= 2020) & (year > 0) & (month > 0) & (month < 13) & (day > 0) & (day < 32)))
                ok = false;
            else
                if ((month == 2) & (day > 28))
                if (day > 29)
                    ok = false;
                else
                  if (!(((year % 4 == 0) & (year % 100 != 0)) | (year % 400 == 0)))
                    ok = false;

            int age;

            if (ok == false)
                Console.WriteLine("Некорректная дата");
            else
                if (month < 9)
            {
                age = 2020 - year;
                Console.WriteLine($"Привет, {name}. Ваш возраст равен {age} лет. Приятно познакомиться.");
            }

            else
                   if (month >= 9)
                if (month > 9)
                {
                    age = 2020 - year - 1;
                    Console.WriteLine($"Привет, {name}. Ваш возраст равен {age} лет. Приятно познакомиться.");

                }
                else
              if (day < 19)
                {
                    age = 2020 - year;
                    Console.WriteLine($"Привет, {name}. Ваш возраст равен {age} лет. Приятно познакомиться.");
                }
                else
                {
                    age = 2020 - year - 1;
                    Console.WriteLine($"Привет, {name}. Ваш возраст равен {age} лет. Приятно познакомиться.");
                }

        }
    }
}