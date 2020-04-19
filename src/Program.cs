using System;
using Helpers.DB.WorkWithDB;
using Modules.DataBase;
using System.Data.SQLite;

namespace console_scheduler_prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание таблицы с записями, если она не существует
            DataBase.CreateRecordsTable();


            Console.WriteLine("Начало программы");
            Console.WriteLine();
            Console.Write("Введите запись: ");
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

            db.ViewAllNotes();
            
            

            


        }
    }
}
