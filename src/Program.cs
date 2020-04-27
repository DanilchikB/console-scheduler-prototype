using System;
using Modules.DataBase;
using Helpers.HelpCommands;
using Helpers.HelpText;
using Helpers.HelpWorkSettings;


namespace console_scheduler_prototype
{
    class Program
    {
        static void Main(string[] args)
        {

            WorkSettings settings = new WorkSettings();
            DataBase dataBase = new DataBase(settings);
            
            dataBase.CreateRecordsTable();
            Commands commands = new Commands();
            Console.WriteLine("Начало программы");
            bool workProgram = true;

            while(workProgram){
                Console.WriteLine();
                bool noCorrectCommandEntry = true;
                string command = null;
                while(noCorrectCommandEntry){
                    Console.Write("Введите команду: ");
                    string enteredCommand = Console.ReadLine();
                    command = commands.takeCommand(enteredCommand, settings);

                    if(command == null){
                        Text.WriteRedText("Ошибка: Такой команды не существует!");
                        commands.ViewAllCommands(settings);
                    }else{
                        noCorrectCommandEntry = false;
                    }
                    
                }
                switch(command){
                    case "AddNote":
                        dataBase.AddRecordToTable();
                        break;
                    case "ViewAll":
                        dataBase.ViewAllNotes();
                        break;
                    case "EditNote":
                        dataBase.EditNote();
                        break;
                    case "DeleteNote":
                        dataBase.DeleteNote();
                        break;
                    case "Exit":
                        Console.WriteLine("Выход.");
                        workProgram = false;
                        break;
                    default:
                        Console.WriteLine("Команда в разработке");
                        break;
                }
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
