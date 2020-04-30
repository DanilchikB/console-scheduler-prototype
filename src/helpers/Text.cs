/***
    Статический класс с методами для работы с текстом в консоли. 
    Базовые цвета: зеленый, желтый и красный
***/

using System;

namespace Helpers.HelpText
{
    static class Text{

        public static string LimitAndIndentation(string text, int limitLength){
            if(text.Length > limitLength){
                text = text.Substring(0, limitLength-3) + "...";
            }else{
                text = text.PadRight(limitLength);
            }
            return text;
        }


        public static void WriteLineGreenText(string text){
            WriteLineColorText(text, ConsoleColor.Green);
        }

        public static void WriteLineYellowText(string text){
            WriteLineColorText(text, ConsoleColor.Yellow);
        }

        public static void WriteLineRedText(string text){
            WriteLineColorText(text, ConsoleColor.Red);
        }

        public static void WriteGreenText(string text){
            WriteColorText(text, ConsoleColor.Green);
        }

        public static void WriteYellowText(string text){
            WriteColorText(text, ConsoleColor.Yellow);
        }

        public static void WriteRedText(string text){
            WriteColorText(text, ConsoleColor.Red);
        }


        public static void WriteLineColorText(string text, ConsoleColor color){
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void WriteColorText(string text, ConsoleColor color){
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}