/***
    Статический класс с методами для вывода цветного текста в консоли. 
    Базовые цвета: зеленый, желтый и красный
***/

using System;

namespace Helpers.HelpFunctions.colorText
{
    static class ColorText{
        public static void WriteGreenText(string text){
            WriteColorText(text, ConsoleColor.Green);
        }

        public static void WriteYellowText(string text){
            WriteColorText(text, ConsoleColor.Yellow);
        }

        public static void WriteRedText(string text){
            WriteColorText(text, ConsoleColor.Red);
        }

        public static void WriteColorText(string text, ConsoleColor color){
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}