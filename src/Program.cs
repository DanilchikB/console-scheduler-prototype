using System;
using Modules.DataBase;
using Helpers.HelpCommands;
using Helpers.HelpText;


namespace console_scheduler_prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //WorkSettings s = new WorkSettings();
            //Console.WriteLine(s.Settings.LocalDB);
            //Console.WriteLine(s.Settings.Commands["AddNote"]["Description"]);
            //Создание таблицы с записями, если она не существует
            DataBase.CreateRecordsTable();

            Commands commands = new Commands();

            Console.WriteLine("Начало программы");
            Console.WriteLine();

            commands.ViewAllCommands();

            Console.Write("Введите команду: ");
            string command = Console.ReadLine();

            Console.WriteLine(command);
            if(command != "view" && command != "addnote"){
                Text.WriteRedText("Ошибка: Такой команды не существует!");
                commands.ViewAllCommands();
            }
            /*Console.Write("Введите запись: ");
            string record = Console.ReadLine();


            WorkWithDB db = new WorkWithDB();

            //Вставка записей в тиблицу
            if(record != ""){
                string date = DateTime.Now.ToString();
                db.ExecuteQueryNoReturn(
                    $@"INSERT INTO records (record, date)
                        VALUES('{record}', '{date}');");
            }
            Console.WriteLine("Все записи:");
            //Вывод всех записей

            db.ViewAllNotes();*/
            
        }
    }
}
