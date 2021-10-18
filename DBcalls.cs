using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SQLChores
{
    class DBcalls
    {
        private string connectionString;
        private string sql;
        public DBcalls(string connection)
        {
            connectionString = connection;
        }
        public void CreateDB()
        {
            Console.WriteLine("Refreshing Chore DataBase...");
            string sql = "DROP DATABASE IF EXISTS [ChoresDB]; CREATE DATABASE [ChoresDB]";
            RunQuery(sql);
        }
        //public void CreateTB()
        //{
        //    Console.WriteLine("Creating Chores Table...");
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("USE ChoresDB; ");
        //    sb.Append("CREATE TABLE Chores ( ");
        //    sb.Append("ChoreID INT INDENTITY(1,1) NOT NULL PRIMARY KEY, ");
        //    sb.Append("ChoreName NVARCHAR(50),");
        //    sb.Append("ChoreAssignment NVCHAR(50)); ");
        //    sql = sb.ToString();
        //    RunQuery(sql);
        //}
        //public void AddCh()
        //{
        //    Console.WriteLine("Adding Chore...");
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("INSERT INTO Chores (ChoreName, ChoreAssignment) VALUES");
        //    sb.Append("(N'Sweep', N'Sweep Room'),");
        //    sb.Append("(N'Mop', N'Mop Room'),");
        //    sql = sb.ToString();
        //    RunQuery(sql);
        //}
        //public void UpdateCh()
        //{
        //    Console.WriteLine("Updating Chore...");
            
        //    RunQuery(sql);
        //}
        //public void DeleteCh()
        //{
        //    Console.WriteLine("Deleting Chore...");
        //    RunQuery(sql);
        //}
        //public void GetCh()
        //{
        //    Console.WriteLine("Listing Chores...");
        //    RunQuery(sql);
        //}
        public void RunQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done");
                }
            }

        }
    }
}
