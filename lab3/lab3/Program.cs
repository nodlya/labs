using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите x0, xn и шаг");
            double x0 = Convert.ToDouble(Console.ReadLine());
            double xn = Convert.ToDouble(Console.ReadLine());
            double j = Convert.ToDouble(Console.ReadLine());
            int n = Convert.ToInt32(Math.Truncate((xn - x0) / j + 1));
            double[] mas = new double[n];
            int length=0;

            //Check(ref x0,xn,j);

            for (int i = 0; i < n; i++)
            {
                double b = x0 + i * j;
                mas[i] = Math.Round(power(b), 4);
                string s = Convert.ToString(mas[i]);
                length = s.Length;
                if (length%2!=0)
                {
                    ++length;
                }
                                
                if (s.Length > length)
                    length = s.Length;
                }

            HeadSpace(length);
            
            for (int i=0; i<n; i++)
              Body(x0+i*j,mas[i],length);
            

        }

        static double power(double k)
        {
            double m = Math.Pow(k,2);
            return m;
        }

        static void HeadSpace(int length)
        {
            int i;
            for (i=0; i< length * 2 + 8; i++)
            Console.Write("_");
            Console.WriteLine();
            
            
            for (i = 1; i < length*2+8; i++)
            {
                if ((i == 1) || (i == length + 4) || (i == 2 * length + 7))
                    Console.Write("|");
                else if (i == 5 +(3*length /2))
                    Console.Write("Y");
                else if (i == 2 + (length / 2))
                    Console.Write("X");
                else
                    Console.Write(" ");
               
            }
            Console.WriteLine();
            for (i = 0; i < length * 2 + 8; i++)
                Console.Write("_");
            Console.WriteLine();
        }
        
        static void Check (ref double x0, double xn, double j)
        {
            string s;
            s = Convert.ToString(xn);
            s = s.Replace(".", ",");
            xn = Convert.ToDouble(s);

            s = Convert.ToString(xn);
            s = s.Replace(".", ",");
            xn = Convert.ToDouble(s);

            s = Convert.ToString(j);
            s = s.Replace(".", ",");
            j = Convert.ToDouble(s);
        }

        static void Body (double x, double y, int length)
        {
            string s1 = Convert.ToString(y);
            int i;
            for (i = 1; i < length * 2 + 8; i++)
            {
                if ((i == 1) || (i == length + 4) || (i == 2 * length + 7))
                    Console.Write("|");
                else if (i == 5 + 2 * length - s1.Length / 2) 
                    Console.Write(y);
                else if (i == 2 + (length / 2))
                    Console.Write(x);
                else
                    Console.Write(" ");
                
            }
            Console.WriteLine();
            for (i = 0; i < length * 2 + 8; i++)
                Console.Write("_");
            Console.WriteLine();

        }
    }
            
    
}
