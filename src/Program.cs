using System;
using HelpFunctions.colorText;
using System.Data.SQLite;
using DB.WorkWithDB;

namespace console_scheduler_prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            

           WorkWithDB db = new WorkWithDB();
            db.ExecuteQueryNoReturn(
                $@"INSERT INTO records (record)
                    VALUES('VALUE');");
        }
    }
}
