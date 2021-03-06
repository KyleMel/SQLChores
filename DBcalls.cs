using System;
using System.Text;
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
            Console.Write("Press Enter to Continue:");
            Console.ReadKey();
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
            Console.WriteLine("Press Enter to Continue:");
            Console.ReadKey();
            Console.WriteLine("Adding Chore...");
            StringBuilder sb = new StringBuilder();
            sb.Append("USE ChoresDB; ");
            sb.Append("INSERT INTO Chores (ChoreName, ChoreAssignment) VALUES ");
            sb.Append("('Dust','Kyle'), ");
            sb.Append("('Sweep','Bob'), ");
            sb.Append("('Mop','Tom'); ");
            sql = sb.ToString();
            RunQuery(sql);
        }
        public void UpdateChore()
        {
            Console.WriteLine("Press Enter to Continue:");
            Console.ReadKey();
            Console.WriteLine("Updating Chore...");
            StringBuilder sb = new StringBuilder();
            sb.Append("USE ChoresDB; ");
            sb.Append("UPDATE Chores SET ChoreAssignment = 'Adam' ");
            sb.Append("WHERE ChoreName = 'Mop'; ");
            sql = sb.ToString();
            RunQuery(sql);
        }
        public void DeleteChore()
        {
            Console.WriteLine("Press Enter to Continue:");
            Console.ReadKey();
            Console.WriteLine("Deleting Chore...");
            sql = "USE ChoresDB DELETE FROM Chores WHERE ChoreName = 'Sweep';";
            RunQuery(sql);
        }
        public void GetChore()
        {
            Console.WriteLine("Press Enter to Continue:");
            Console.ReadKey();
            Console.WriteLine("Listing Chores...");
            sql = "USE ChoresDB SELECT * FROM Chores;";
            ListQuery(sql);
        }
        public void RunQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Done\n");
                }
            }
        }
        public void ListQuery(string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("|{0}|{1}|{2}", reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                        }
                    }
                }
            }
        }
    }
}
