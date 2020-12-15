using System;

namespace ImportExcel.ConsoleTest.Util
{
    public static class ConsoleUtil
    {
        public static void WriteColor(string text, ConsoleColor foreColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black, bool isFullLine = true)
        {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
            if (isFullLine) Console.WriteLine(text); else Console.Write(text);
            Console.ResetColor();
        }
    }
}
