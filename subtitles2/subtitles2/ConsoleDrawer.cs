using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace subtitles2
{
    public static class ConsoleDrawer
    {
        public static readonly List<ScenarioLine> Instructions = 
                               FileWork.InterpreteStrings();

        //private static readonly Dictionary<Place, string> enumToPlace =
            //new Dictionary<Place, string>();

        private static readonly Dictionary<Color, ConsoleColor> enumToColor =
            new Dictionary<Color, ConsoleColor>(5);

        private static int iterator = 0;

        public static void StartThreads()
        {
            ConvertToConsole();
            //ConvertToPosition();
            Thread myThread = new Thread(new ThreadStart(OrganiseOutput));
            myThread.Start();
        }

        private static void OrganiseOutput()
        {
            iterator++;
            List<ScenarioLine> temp = new List<ScenarioLine>();
            foreach (ScenarioLine a in Instructions)
            {
                if (a.secondsStart == iterator ||
                    a.secondsStart + a.duration <= iterator)
                    temp.Add(a);
            }
            FinallyGoodFoodToEatorOutput(temp);
            iterator++;
            Thread.Sleep(1000);
        }

        private static void FinallyGoodFoodToEatorOutput(List<ScenarioLine> current)
        {
            ScenarioLine top = null;
            ScenarioLine bottom = null;
            ScenarioLine right = null;
            ScenarioLine left = null;
            foreach (ScenarioLine a in current)
            {
                switch (a.placeOnScreen)
                {
                    case Place.Bottom:
                        bottom = a;
                        break;
                    case Place.Top:
                        top = a;
                        break;
                    case Place.Left:
                        left = a;
                        break;
                    case Place.Right:
                        right = a;
                        break;
                }
            }

            Output(top,bottom,right,left);
        }

        private static void Output (ScenarioLine top, ScenarioLine bottom,
                                    ScenarioLine right, ScenarioLine left)
        {
            Console.Clear();
            if (top != null)
            StringToOutPut(top);
            StringToOutPut(left,right);
            if (bottom != null)
            StringToOutPut(bottom);
        }

        private static void StringToOutPut (ScenarioLine line)
        {
            SetColor(line);
            int centerX = (Console.WindowWidth / 2) - (line.text.Length / 2);
            if (line.placeOnScreen == Place.Top) 
                Console.SetCursorPosition(centerX, 0);
            else
                Console.SetCursorPosition(centerX, Console.WindowHeight - 1);
        }
        private static void StringToOutPut(ScenarioLine line1, 
                                             ScenarioLine line2)
        {
            int setX = Console.WindowHeight / 2;
            int setY1 = 0;
            int setY2 = Console.WindowWidth - line1.text.Length;

            if (line1 != null)
            {
                SetColor(line1);
                Console.SetCursorPosition(setX, setY1);
                Console.Write(line1.text);
            }
            if (line2 != null)
            {
                SetColor(line2);
                Console.SetCursorPosition(setX, setY2);
                Console.Write(line2);
            }

        } 

        private static void SetColor(ScenarioLine line)
        {
            Console.ForegroundColor = enumToColor[line.colorOfText];
        }

        private static void ConvertToConsole()
        {
            enumToColor.Add(Color.Red, ConsoleColor.Red);
            enumToColor.Add(Color.Green, ConsoleColor.Green);
            enumToColor.Add(Color.White, ConsoleColor.White);
            enumToColor.Add(Color.Blue, ConsoleColor.Blue);
            enumToColor.Add(Color.Yellow, ConsoleColor.Yellow);
        }

    }
}
