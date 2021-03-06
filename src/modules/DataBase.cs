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
                date TEXT NOT NULL,
                status INTEGER NOT NULL DEFAULT 0
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

            Text.WriteLineGreenText("Запись добавлена.");
        }

        //Показ всех записей
        public void ViewAllNotes(){
            Console.WriteLine("Все записи:");
            db.ViewAllNotes("SELECT * FROM records");
        }

        //Редактирование записи
        public void EditNote(){
            Console.Write("Введите id записи, которую хотите отредактировать: ");
            string enterId = Console.ReadLine();
            if(!CheckCorrectInput(enterId)){
                return;
            }
            Console.Write("Введите отредактированную запись: ");
            string enterNote = Console.ReadLine();
            db.EditNote(enterNote, enterId);

        }
        public void DeleteNote(){
            Console.Write("Введите id записи, которую хотите удалить: ");
            string enterId = Console.ReadLine();
            if(!CheckCorrectInput(enterId)){
                return;
            }
            db.DeleteNote(enterId);
        }

        public void ChangeStatusOnDone(){
            Console.Write("Введите id записи, которую хотите завершить: ");
            ChangeStatus(1);
        }

        public void ChangeStatusOnNoDone(){
            Console.Write("Введите id записи, которую хотите перевести в статус \"Не завершенно\": ");
            ChangeStatus(0);
        } 

        public void ViewAllCompleted(){
            Console.WriteLine("Все выполненные задачи:");
            db.ViewAllNotes("SELECT * FROM records WHERE status = 1");
        }

        public void ViewAllNoCompleted(){
            Console.WriteLine("Не выполненные задачи:");
            db.ViewAllNotes("SELECT * FROM records WHERE status = 0");
        }
        private void ChangeStatus(int status = 0){
            string enterId = Console.ReadLine();
            if(!CheckCorrectInput(enterId)){
                return;
            }
            string sqlQuery = $@"UPDATE records 
                SET status = {status}
                WHERE id = {enterId}";
            db.ExecuteQueryNoReturn(sqlQuery);
            Text.WriteLineYellowText("Статус изменен.");
        }
        private bool CheckCorrectInput(string input){
            if(input == ""){
                Text.WriteLineYellowText("Вы ничего не ввели.");
                return false;
            }
            if(!db.CheckId(input)){
                Text.WriteLineRedText("Нет такой записи.");
                return false;
            }
            return true;
        }
    }
}