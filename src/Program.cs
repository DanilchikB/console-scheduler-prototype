using System;
using Helpers.DB.WorkWithDB;
using Modules.DataBase;

namespace console_scheduler_prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создание таблицы с записями, если она не существует
            DataBase.CreateRecordsTable();

            //Вставка записей в тиблицу
            string date = DateTime.Now.ToString();
            WorkWithDB db = new WorkWithDB();
            db.ExecuteQueryNoReturn(
                $@"INSERT INTO records (record, date)
                    VALUES('VALUE', '{date}');");
        }
    }
}
