using System;
using System.Threading.Tasks;

namespace MinionNames
{
    

    class Program
    {
        static async Task Main()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";

            await using SqlConnection sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
        }
    }
}
