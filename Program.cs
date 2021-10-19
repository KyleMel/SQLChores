using System;
using System.Text;


namespace SQLChores
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = "Data Source=localhost;Initial Catalog=master;User ID=Kyle;Password=Temp123!";
            var calls = new DBcalls(connection);
            calls.CreateDB();
            calls.CreateTable();
            calls.AddChore();
            //calls.UpdateChore();
            //calls.DeleteChore();
            //calls.GetChore();
        }
    }
}
