using System;
using HelpFunctions.colorText;
using System.Data.SQLite;

namespace console_scheduler_prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            using(SQLiteConnection Connection = new SQLiteConnection("Data Source=./test.db; Version=3;")){
                string commandText = @"CREATE TABLE IF NOT EXISTS records(
                        id INTEGER PRIMARY KEY,
                        record TEXT NOT NULL
                    )";
                
                Connection.Open();

                SQLiteCommand Command = new SQLiteCommand(commandText, Connection);
                Command.ExecuteNonQuery();
                string text = "Create variables";
                Command.CommandText = $@"INSERT INTO records (record)
                    VALUES('{text}');";
                Command.ExecuteNonQuery();
                Connection.Close();
            }
        }
    }
}
