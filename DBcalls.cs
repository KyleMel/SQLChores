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
        public void CreateTable()
        {
            Console.WriteLine("Creating Chores Table...");
            StringBuilder sb = new StringBuilder();
            sb.Append("USE ChoresDB; ");
            sb.Append("CREATE TABLE Chores ( ");
            sb.Append("ChoreID INT IDENTITY(1,1) NOT NULL PRIMARY KEY, ");
            sb.Append("ChoreName NVARCHAR(50),");
            sb.Append("ChoreAssignment NVARCHAR(50)); ");
            sql = sb.ToString();
            RunQuery(sql);
        }
        
        public void AddChore()
        {
            Console.WriteLine("Adding Chore...");
            StringBuilder sb = new StringBuilder();
            sb.Append("USE ChoresDB; ");
            sb.Append("INSERT INTO Chores (ChoreName, ChoreAssignment) VALUES ");
            sb.Append("('Dust','Dust Room'), ");
            sb.Append("('Sweep','Sweep Room'), ");
            sb.Append("('Mop','Mop Room'); ");
            sql = sb.ToString();
            RunQuery(sql);
        }
        //public void UpdateChore()
        //{
        //    Console.WriteLine("Updating Chore...");
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("USE ChoresDB; ");
        //    sb.Append("UPDATE Chores SET ChoreAssignment = 'Sweep Kitchen' ");
        //    sb.Append("WHERE ChoreName = 'Sweep' ");
        //    sql = sb.ToString();
        //    RunQuery(sql);
        //}
        //public void DeleteChore()
        //{
        //    Console.WriteLine("Deleting Chore...");
        //    RunQuery(sql);
        //}
        //public void GetChore()
        //{
        //    Console.WriteLine("Listing Chores...");
        //    RunQuery(sql);
        //}
        //public void AddCh(string choreName, string choreAssignment)
        //{
        //    //generalize AddCh() to add data to table w/ input parameters.
        //    //INSERT INTO TABLE_NAME VALUES (value1,value2,value3,...valueN);
        //    Console.WriteLine("Adding Chore...");
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("USE ChoresDB; ");
        //    sb.Append("INSERT INTO Chores (ChoreName, ChoreAssignment) VALUES");
        //    sb.Append($"('{choreName}', '{choreAssignment}');");
        //    sql = sb.ToString();
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
