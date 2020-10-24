using System;
using System.Globalization;
using System.Runtime.Serialization.Formatters;

namespace lab6
{
    class Program
    {
        //[1, 2, 3], [3, 4, 5], [7, 8, 9] ] и [ [3, 4, 5], [7, 8, 9]
        static void Main(string[] args)
        {
            int[,] mas1 = { { 1, 2, 3 } , { 3, 4, 5 }};
            int[,] mas2 = { { 1, 2, 3 }, { 3, 4, 5 }, { 7, 8, 9 } };

            /* if (mas1.Rank == 1 && mas2.Rank == 1)
             Console.WriteLine(SeekStandart(mas1, mas2));
*/
           /* if (mas1.Rank == 2 && mas2.Rank == 1)
                 Console.WriteLine(SeekDiff(mas1,mas2));

                for (int i = 0; i < mas1.GetLength(1); i++)
                {
                    for (int j = 0; j < mas2.GetLength(0); j++)
                        Console.Write(mas1[i, j]);
                    Console.WriteLine();
                } */

                        if (mas1.Rank == 2 && mas2.Rank == 2)
                Console.WriteLine(SeekSame(mas1,mas2));

            if (mas1.Rank == 1 && mas2.Rank == 2)
                Console.WriteLine("false");
        }

        static bool SeekStandart(int[] mas1, int[] mas2)
        {
            for (int i = 0; i < mas1.GetLength(1) - mas2.GetLength(1) + 1; i++)
                if (mas1[i] == mas2[0] && Check(mas1, mas2, i)==true) 
                    return Check(mas1, mas2, i);
            return false;
        }

        static bool Check(int[] mas1, int[] mas2, int i)
        {
            for (int j = 0; j < mas2.GetLength(0); j++)
                if (i+j<mas2.GetLength(0) && mas1[i + j] != mas2[j])
                    return false;
            return true;
        }

       static bool SeekDiff(int [,] mas1, int[] mas2)
        {
            bool temp = false;
            for (int i = 0; i < mas1.GetLength(1); i++)
                for (int j = 0; j < mas2.GetLength(0); j++)
                    if (mas1[i, j] == mas2[0] && Check(Cut(mas1, i), mas2, j) == true)
                        return true;
           
            return temp;
        }

        static bool SeekSame(int [,]mas1,int[,]mas2)
        {
            bool temp = false;
            if (SeekDiff(mas1,Cut(mas2,0))==true && mas1.GetLength(1)>=mas2.GetLength(1))
            {
                int i = 1;
                while (i < mas2.GetLength(0))
                {
                    i++;
                    if (SeekDiff(mas1, Cut(mas2, i)) == false)
                    {
                        temp = false;
                        break;
                    }
                    temp=true;
                }
                  
            }
            return temp;
        }

        static int[] Cut(int[,] mas, int i)
        {
            int[] temp = new int [mas.GetLength(1)];
            for (int j = 0; j < mas.GetLength(1); j++)
                temp[j] = mas[i, j];
            return temp;
        }

    }
}
