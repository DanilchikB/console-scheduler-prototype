using System;
using Helpers.HelpWorkWithDB;
using Helpers.HelpWorkSettings;
using Helpers.HelpText;

namespace Modules.DataBase{
    class DataBase{
        private WorkWithDB db;
        public DataBase(WorkSettings ws){
            db = new WorkWithDB(ws.Settings.LocalDB);
        }
        
        //Создание таблицы с записями
        public void CreateRecordsTable(){

            string sqlQuery = @"CREATE TABLE IF NOT EXISTS records(
                id INTEGER PRIMARY KEY,
                record TEXT NOT NULL,
                date TEXT NOT NULL
            );";

            db.ExecuteQueryNoReturn(sqlQuery);
        }

        //Добавление записей в таблицу
        public void AddRecordToTable(){
            Console.Write("Введите запись: ");
            string enteredCommand = Console.ReadLine();
            string date = DateTime.Now.ToString();

            string sqlQuery = $@"INSERT INTO records (record, date)
                        VALUES('{enteredCommand}', '{date}');";

            db.ExecuteQueryNoReturn(sqlQuery);

            Text.WriteGreenText("Запись добавлена.");
        }

        //Показ всех записей
        public void ViewAllNotes(){
            Console.WriteLine("Все записи:");
            db.ViewAllNotes();
        }

        //Редактирование записи
        public void EditNote(){
            Console.Write("Введите id записи, которую хотите отредактировать: ");
            string enterId = Console.ReadLine();
            if(enterId == ""){
                Text.WriteYellowText("Вы ничего не ввели.");
                return;
            }
            if(!db.CheckId(enterId)){
                Text.WriteRedText("Нет такой записи.");
                return;
            }
            Console.Write("Введите отредактированную запись: ");
            string enterNote = Console.ReadLine();
            db.EditNote(enterNote, enterId);

        }
    }
}