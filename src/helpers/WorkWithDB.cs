/***
    Класс для работы с sql запросами для базы данных SQLite
***/

using System;
using System.Data.SQLite;
using Helpers.HelpText;

namespace Helpers.HelpWorkWithDB{
    class WorkWithDB{

        public WorkWithDB(string locationDB){
            if(locationDB != ""){
                this.locationDB = "Data Source="+locationDB+"; Version=3;";
            }else{
                this.locationDB = "Data Source=./test.db; Version=3;";
            }
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
                string[] descriptionColumn = new string[3] {"Id","Запись","Дата создания"};

                Console.WriteLine();
                Console.Write(Text.LimitAndIndentation(descriptionColumn[0], 7));
                Console.Write("   ");
                Console.Write(Text.LimitAndIndentation(descriptionColumn[1], 15));
                Console.Write("   ");
                Console.Write(descriptionColumn[2]);
                Console.WriteLine();
                Console.WriteLine();

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

