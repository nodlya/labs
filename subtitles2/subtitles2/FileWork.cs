using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace subtitles2
{
    public enum Place
    {
        Top,
        Bottom,
        Left,
        Right
    }

    public enum Color
    {
        Red,
        White,
        Yellow,
        Blue,
        Green
    }
    public static class FileWork
    {
        private static string path = @"..\\..\\..\\scenario.txt";

        public static void CheckFile()
        {
                if (!File.Exists(path))
                {
                    Console.Write("File doesn't exist");
                    Environment.Exit(0);
                }
        }

        private static int RowsInFile()
        {
            int k = 0;
            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    k++;
                }
            }
            return k;
        }

        public static List<ScenarioLine> InterpreteStrings()
        {
            int iterator = RowsInFile();
            List<ScenarioLine> temp = new List<ScenarioLine>();
            using StreamReader sr = new StreamReader(path);
            for (int i = 1; i <= iterator; i++)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
                temp.Add(BlocksInfo(line));
            }

            return temp;
        }

         private static ScenarioLine BlocksInfo(string sr)
         {
             string timeStart = sr.Substring(0,5);
             string timeStop = sr.Substring(8,5);
             int num1 = int.Parse(timeStart.Substring(3, 2));
             int num2 = int.Parse(timeStop.Substring(3, 2));
             int duration = num2 - num1;

             if (sr.Contains("["))
             {
                 string place = sr.Substring(sr.IndexOf("[") + 1,
                                sr.IndexOf(",") - sr.IndexOf("[") - 1);
                 string color = sr.Substring(sr.IndexOf(",") + 2,
                                             sr.IndexOf("]") - sr.IndexOf(",") - 2);
                 string text = sr.Substring(sr.IndexOf("]") + 2,
                                            sr.Length - sr.IndexOf("]") - 2);
                 return new ScenarioLine(timeStart, timeStop, duration, text,
                                          place, color);
             }
             else
             {
                 string text = sr.Substring(13,sr.Length-13);
                 text = text.Trim();
                 return new ScenarioLine(timeStart,timeStop,duration,text);
             }
         }
     
    }

    public class ScenarioLine
    {
        public readonly string timeStart;
        public readonly int secondsStart;
        public readonly string timeEnd;

        public readonly int duration;
        public readonly Place placeOnScreen;

        public readonly Color colorOfText;

        public readonly string text;

        static readonly Dictionary<string, Place> StringToPlace =
                new Dictionary<string, Place>();
        static readonly Dictionary<string, Color> StringToColor =
                new Dictionary<string, Color>();



        public ScenarioLine(string timeStart, string timeEnd, 
                            int duration, string text,
                            string placeOnScreen = "Bottom",
                            string colorOfText = "White")
        {
            AddPlaceDictionary();
            AddColorDictionary();

            this.secondsStart = int.Parse(timeStart.Substring(0, 2)) * 60 +
                                int.Parse(timeStart.Substring(3, 2));
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;
            this.duration = duration;
            this.placeOnScreen = StringToPlace[placeOnScreen];
            this.colorOfText = StringToColor[colorOfText];
            this.text = text;
        }

        private static void AddPlaceDictionary()
        {
            StringToPlace.Add("Bottom", Place.Bottom);
            StringToPlace.Add("Top", Place.Top);
            StringToPlace.Add("Left", Place.Left);
            StringToPlace.Add("Right", Place.Right);
        }

        private static void AddColorDictionary()
        {
            StringToColor.Add("Red", Color.Red);
            StringToColor.Add("Blue", Color.Blue);
            StringToColor.Add("Green", Color.Green);
            StringToColor.Add("White", Color.White);
            StringToColor.Add("Yellow", Color.Yellow);
        }

    }
}
