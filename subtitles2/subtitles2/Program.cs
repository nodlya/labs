using System;
using System.Drawing;
using System.Threading;

namespace subtitles2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWork.CheckFile();
            ConsoleDrawer.StartThreads();
        }
    }
}
