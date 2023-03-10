using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MinionsExercises
{
    class Program
    {
        static async Task Main()
        {
            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=MinionsDB;Trusted_Connection=True;";

            await using SqlConnection minionsConnection = new SqlConnection(connectionString);
            await minionsConnection.OpenAsync();

            //string result = await GetVillainNamesAndNumberOfMinions(minionsConnection);

            int villainId = int.Parse(Console.ReadLine());
            string result = await GetAllMinionsPerVillainId(minionsConnection, villainId);

            Console.WriteLine(result);
        }

        private static async Task<string> GetVillainNamesAndNumberOfMinions(SqlConnection minionsConnection)
        {
            //Villain Names
            //Write a program that prints on the console all villains' names where they have more than three minions.
            //Write the number of minions where they have. Order the results descendingly by the number of minions.
            //
            //Example output:
            //Jilly – 4

            StringBuilder output = new StringBuilder();

            SqlCommand getVillain = new SqlCommand(SQL_Commands.GetVillainNamesAndNumberOfMinions, minionsConnection);
            SqlDataReader villainReader = await getVillain.ExecuteReaderAsync();

            while (villainReader.Read())
            {
                string villain = (string)villainReader["Name"];
                int minions = (int)villainReader["MinionsCount"];

                output.AppendLine($"{villain} – {minions}");
            }

            return output.ToString().TrimEnd();
        }

        private static async Task<string> GetAllMinionsPerVillainId(SqlConnection minionsConnection, int villainId)
        {
            //Minion Names
            //Write a program that prints on the console all minion names and ages for a given villain id, ordered by name alphabetically.
            //If there is no villain with the given ID print "No villain with ID <VillainId> exists in the database.".
            //If the selected villain has no minions print "(no minions)" on the second row.
            //
            //Example
            //Input     Output          Input   Output              Input   Output
            //1         Villain: Gru    2       Villain: Victor     6       Villain: Dimityr
            //          1. Becky 125            1. Bob 42                   (no minions)
            //          2. Bob 42               2. Simon 45
            //          3. Kevin 1
            //
            //Input     Output
            //8         No villain with ID 8 exists in the database.

            SqlCommand getVillainName = new SqlCommand(SQL_Commands.GetVillainNameById, minionsConnection);
            getVillainName.Parameters.AddWithValue("Id", villainId);

            object villainObj = await getVillainName.ExecuteScalarAsync();

            if (villainObj == null)
            {
                return $"No villain with ID {villainId} exists in the database.";
            }
            else
            {
                string villainName = (string)villainObj;

                var getAllMinions = new SqlCommand(SQL_Commands.GetAllMinionsByVillainId, minionsConnection);
                getAllMinions.Parameters.AddWithValue("Id", villainId);

                var minionsReader = await getAllMinions.ExecuteReaderAsync();       

                string output = GetMinions(villainName, minionsReader);
                return output;
            }  
        }

        private static string GetMinions(string villainName, SqlDataReader minionsReader)
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"Villain: {villainName}");

            if (!minionsReader.HasRows)
            {
                output.AppendLine("(no minions)");
            }
            else
            {
                while (minionsReader.Read())
                {
                    long row = (long)minionsReader["RowNum"];
                    string name = (string)minionsReader["Name"];
                    int age = (int)minionsReader["Age"];

                    output.AppendLine($"{row}. {name} {age}");
                }
            }

            return output.ToString().TrimEnd();
        }


    }
}
