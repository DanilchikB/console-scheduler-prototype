using Helpers.DB.WorkWithDB;

namespace Modules.DataBase{
    static class DataBase{
        public static void CreateRecordsTable(){

            string sqlQuery = @"CREATE TABLE IF NOT EXISTS records(
                id INTEGER PRIMARY KEY,
                record TEXT NOT NULL,
                date TEXT NOT NULL
            );";

            WorkWithDB db = new WorkWithDB("Data Source=./test.db; Version=3;");
            db.ExecuteQueryNoReturn(sqlQuery);
        }
    }
}