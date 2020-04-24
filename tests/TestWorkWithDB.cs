using System;
using Xunit;
using Helpers.HelpWorkWithDB;

namespace tests
{
    public class TestWorkWithDB
    {
        private readonly WorkWithDB db;

        public TestWorkWithDB()
        {
            db = new WorkWithDB("DataSource=:memory:");
        }

        [Fact]
        public void TestCheckID()
        {
            db.ExecuteQueryNoReturn(@"CREATE TABLE IF NOT EXISTS records(
                id INTEGER PRIMARY KEY,
                record TEXT NOT NULL,
                date TEXT NOT NULL
            );");
            db.ExecuteQueryNoReturn(@"INSERT INTO records (record, date)
                        VALUES('adc', '111');");
            var result = db.CheckId("1");
            db.ExecuteQueryNoReturn("DROP TABLE records;");

            Assert.True(result);

            
        }
    }
}
