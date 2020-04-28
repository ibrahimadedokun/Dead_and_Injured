
using System;

namespace Refactored
{
    //For functions that return void
    static class Tools
    {        
        public static void ColorfulWriteLine(string content, ConsoleColor color = ConsoleColor.Red )
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }

        public static void ColorfulWrite(string content, ConsoleColor color = ConsoleColor.Red)
        {
            Console.ForegroundColor = color;
            Console.Write(content);
            Console.ResetColor();
        }
    }
}
