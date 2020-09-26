using System;
using System.Numerics;
using System.Text;

namespace конь
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = Console.ReadLine();
            int x1 = Convert.ToInt32(s1[0]);
            int y1 = Convert.ToInt32(s1[1]);
          
            string s2 = Console.ReadLine();
            int x2 = Convert.ToInt32(s2[0]);
            int y2 = Convert.ToInt32(s2[1]);

            Console.WriteLine("Если фигура - конь, введите 1, если ладья - 2, слон - 3, ферзь - 4");
            int num =Convert.ToInt32(Console.ReadLine());
           
            if ((64 < x1) && (x1 < 73) && (64 < x2) && (x2 < 73) && (y1 > 48) && (y1 < 57) && (y2 > 48) && (y2 < 57))
            {
                switch (num)
                {
                    case 1:
                        Knight(ref x1,x2,y1,y2);
                        break;
                    case 2:
                        Rook(ref x1, x2, y1, y2);
                        break;
                    case 3:
                        Bishop(ref x1, x2, y1, y2);
                        break;
                    case 4:
                        Queen(ref x1, x2, y1, y2);
                        break;
                }
            }
            else
                Console.WriteLine("категорически неверно");

        }

        static void Knight (ref int x1, int x2, int y1, int y2)
        {
            if ((Math.Abs(x1 - x2) + Math.Abs(y1 - y2)) == 3 && x1 != x2 && y1 != y2)
                Console.WriteLine("верно");
            else
                Console.WriteLine("неверно");
        }

        static void Queen (ref int x1, int x2, int y1, int y2)
        {
            if ((x1==x2 && y1!=y2) || (x1!=x2 && y1==y2) || (x1+y1==x2+y2) || (Math.Abs(x1-x2+y1-y2) % 2==0))
                Console.WriteLine("верно");
            else
                Console.WriteLine("неверно");
        }

        static void Rook(ref int x1, int x2, int y1, int y2)
        {
            if ((x1 + y1 == x2 + y2) || (Math.Abs(x1 - x2 + y1 - y2) % 2==0))
                Console.WriteLine("верно");
            else
                Console.WriteLine("неверно");
        }

        static void Bishop(ref int x1, int x2, int y1, int y2)
        {
            if ((x1 == x2 && y1 != y2) || (x1 != x2 && y1 == y2))
                Console.WriteLine("верно");
            else
                Console.WriteLine("неверно");
        }

        static void Pawn (ref int x1, int x2, int y1, int y2)
        {
            if (y1-y2 !=0 && x1==x2)
                Console.WriteLine("верно");
            else
                Console.WriteLine("неверно");
        }

        static void King (ref int x1, int x2, int y1, int y2)
        {
            if (Math.Abs(x1-x2)==1 || Math.Abs(y1-y2)==1)
                Console.WriteLine("верно");
            else
                Console.WriteLine("неверно");
        }
    }
}
