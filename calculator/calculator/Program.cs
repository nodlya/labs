using System;
using System.IO;
using System.Text;

namespace calculator
{
    class Program
    {       
        static string path = @"../../../input.txt";
        static string OutputPath = @"../../../output.txt";
        static void Main(string[] args)
        {
            
            if (!File.Exists(path))
            {
                Console.WriteLine("пример недоступен");
                return;
            }

            string problem = File.ReadAllText(path);
            Console.WriteLine(problem);

            FirstCheck(problem);

            string num1 = GetNumber(ref problem);
            string num2 = GetNumber(ref problem);
            char operation = GetOperation(ref problem) ;

            if (Check(num1, num2, operation,problem) == false)
                BlueScreenOfDeath();
            Calculation(Convert.ToInt32(num1),Convert.ToInt32(num2),operation);
        }

        static void BlueScreenOfDeath()
        {
            Console.WriteLine("Некорректный ввод, попробуйте отредактировать файл");
            Console.ReadLine();
            Environment.Exit(0);
        }

        static void FirstCheck(string problem)
        {
            int Ocount = 0;
            int pos1=-1;
            int pos2 = -1;
            for (int i=0; i<problem.Length; i++)
            {
                if (!(char.IsWhiteSpace(problem[i]) || char.IsLetterOrDigit(problem[i])))
                { Ocount++;
                    if (pos1 == -1)
                        pos1 = i;
                }
                if (char.IsLetter(problem[i]))
                {
                    Console.WriteLine("В записи есть буквы");
                    BlueScreenOfDeath();
                }

                if (pos2 == -1 && char.IsDigit(problem[i]))
                    pos2 = i;
            }

            if (Ocount!=1)
            {
                Console.WriteLine("Неправильное количество операций");
                BlueScreenOfDeath();
            }

            if (pos2>pos1)
            {
                Console.WriteLine("Неправильно расположен знак операции");
                BlueScreenOfDeath();
            }
        }
        
        static string GetNumber(ref string problem)
        {
            string temp = string.Empty;
            bool num = false;
            for (int i = 0; i<problem.Length; i++)
            {
                if (char.IsDigit(problem[i]))
                {
                    temp += problem[i];
                    problem = problem.Remove(i, 1);
                    num = true;
                }
                else if (char.IsWhiteSpace(problem[i]) && num)
                    break;
                    
            }
            return temp;
        }

        static char GetOperation(ref string problem)
        {
            char temp= '!';
            for (int i = 0; i < problem.Length; i++)
            {
                if (!(char.IsWhiteSpace(problem[i]) || char.IsLetterOrDigit(problem[i])))
                {
                    temp = problem[i];
                    problem = problem.Remove(i, 1);
                    break;
                }
            }
            return temp;
        }

        static bool Check(string num1, string num2, char operation, string problem)
        {
            bool temp = true;
            if (num1 == null || num2 == null)
            { Console.WriteLine("В задании не хватает чисел"); temp = false; }
            if (operation == '!')
            { Console.WriteLine("Некорректный ввод знака"); temp = false; }
            if (operation == '/' && num2 == "0")
            { Console.WriteLine("Упс, деление на ноль"); temp = false; }

            for (int a=0; a<problem.Length; a++)
            {
                if (char.IsWhiteSpace(problem[a]) != false)
                { Console.WriteLine("В задании есть что-то лишнее"); BlueScreenOfDeath(); }
            }

            return temp;
        }

        static void Calculation(int num1,int num2, char operation)
        {
            string result = string.Empty;

            switch (operation)
            {
                case '+':
                    result = Convert.ToString(num1 + num2);
                    break;
                case '-':
                    result = Convert.ToString(num1 - num2);
                    break;
                case '*':
                    result = Convert.ToString(num1 * num2);
                    break;
                case '/':
                    result = Convert.ToString(Math.Round(Convert.ToDouble(num1)/Convert.ToDouble(num2),2));
                    break;
                default:
                    break;                
            }

            CreateOutput(result);
        }

        static void CreateOutput (string result)
        {
            using (FileStream fs = File.Create(OutputPath))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(result);
                fs.Write(info, 0, info.Length);
            }

            using (FileStream fstream = File.OpenRead(OutputPath))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = Encoding.Default.GetString(array);
                Console.WriteLine(textFromFile);
            }
        }
    }

}
