using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace classes
{
    public class Person
    {
        public Person[] Parents;
        public Person Spouse;
        public List<Person> Children;
        public string LastName = string.Empty;
        public string FirstName = string.Empty;
        public string Date = string.Empty;
    }

    public class Reader
    {
        //public readonly int k = TextReader();
        public static int TextReader()
        {
            int k = -2;
            using (StreamReader sr = new StreamReader("..\\..\\..\\list.txt", System.Text.Encoding.Default))
            {
                string line;
                
                while ((line = sr.ReadLine()) != string.Empty)
                {
                    k++;
                }
            }
            return k;    
        }

        public static Person[] GetData(Person[] people)
        {
            int k = -2;
            using (StreamReader sr = new StreamReader("..\\..\\..\\list.txt", System.Text.Encoding.Default))
            {
                string line;

                while ((line = sr.ReadLine()) != string.Empty)
                {
                    if (k>=0 && k<TextReader()+2)
                    {
                        string[] lines = line.Split(new char[] { ';' });
                        foreach (string s in lines)
                        {
                            Console.WriteLine(s);
                        }
                        //пиздец
                        people[k].LastName = lines[1];
                        people[k].FirstName = lines[2];
                        people[k].Date = lines[3];
                        Console.WriteLine(people[k].LastName, people[k].FirstName, people[k].Date);
                    }
                    k++;
                }
            }
            return people;
        }
        

    }
}
