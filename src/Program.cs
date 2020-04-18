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

            using SQLiteConnection Connection = new SQLiteConnection("Data Source=./test.db; Version=3;");
            Connection.Open();
            using SQLiteCommand Command = new SQLiteCommand(Connection);
            Command.CommandText = "SELECT * FROM records;";
            using SQLiteDataReader read = Command.ExecuteReader();
            while(read.Read()){
                Console.WriteLine(read["id"] + " " + read["record"] + " " + read["date"]);
            }
            read.Close();
            Connection.Close();
            
            

            


        }
    }
}
