/***
    Класс для работы с sql запросами для базы данных SQLite
***/

using System;
using System.Data.SQLite;
using Helpers.HelpFunctions.Text;

namespace Helpers.DB.WorkWithDB{
    class WorkWithDB{
        public WorkWithDB(){
            locationDB = "Data Source=./test.db; Version=3;";
        }
        public WorkWithDB(string locationDB){
            this.locationDB = locationDB;
        }

        public string locationDB{private get; set;}

        //Делегат для внедрения функции в метод OpenAndCloseDB()
        public delegate void Query(SQLiteCommand command, string sqlQuery);

        //Запрос без вытаскивания данных
        public void ExecuteQueryNoReturn(string sqlQuery){
            Query query = delegate(SQLiteCommand command, string sqlQuery){
                command.CommandText = sqlQuery;
                command.ExecuteNonQuery();
            };
            OpenAndCloseDB(sqlQuery, locationDB, query);
        }

        //Показ всех записей
        public void ViewAllNotes(){
            Query query = delegate(SQLiteCommand command, string sqlQuery){
                command.CommandText = sqlQuery;
                using SQLiteDataReader read = command.ExecuteReader();
                while(read.Read()){

                    string id = Text.LimitAndIndentation(read["id"].ToString(), 7);
                    string record = Text.LimitAndIndentation(read["record"].ToString(),15);
                    
                    Console.WriteLine(id + "   " + record + "   " + read["date"]);
                }
                read.Close();
            };
            OpenAndCloseDB("SELECT * FROM records;", locationDB, query);
            
        }

        //Метод для открытия и закрытия базы данных
        private void OpenAndCloseDB(string sqlQuery, string locationDB, Query query){
            using SQLiteConnection Connection = new SQLiteConnection(locationDB);
                
            Connection.Open();

            using SQLiteCommand Command = new SQLiteCommand(Connection);
            query.Invoke(Command, sqlQuery);

            Connection.Close();
        }
    } 

}

