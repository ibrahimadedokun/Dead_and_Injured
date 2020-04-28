
using System;

namespace Refactored
{
    //For functions that return void
    static class Tools
    {
        public static void ColorfulWriteLine(string content, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(content);
            Console.ResetColor();
        }        
    }
}
