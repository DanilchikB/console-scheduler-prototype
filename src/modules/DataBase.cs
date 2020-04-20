using Helpers.HelpWorkWithDB;
using Helpers.HelpWorkSettings;

namespace Modules.DataBase{
    static class DataBase{
        public static void CreateRecordsTable(){

            string sqlQuery = @"CREATE TABLE IF NOT EXISTS records(
                id INTEGER PRIMARY KEY,
                record TEXT NOT NULL,
                date TEXT NOT NULL
            );";

            WorkSettings ws = new WorkSettings();

            WorkWithDB db = new WorkWithDB(ws.Settings.LocalDB);
            db.ExecuteQueryNoReturn(sqlQuery);

            
        }
    }
}