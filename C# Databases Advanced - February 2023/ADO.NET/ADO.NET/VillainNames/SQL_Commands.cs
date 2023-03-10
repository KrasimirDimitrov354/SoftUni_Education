namespace MinionsExercises
{
    internal static class SQL_Commands
    {
        public static string GetVillainNamesAndNumberOfMinions = @"  SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                                                       FROM Villains AS v 
                                                                       JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                                                   GROUP BY v.Id, v.Name 
                                                                     HAVING COUNT(mv.VillainId) > 3 
                                                                   ORDER BY COUNT(mv.VillainId)";

        public static string GetVillainNameById = @"SELECT Name FROM Villains WHERE Id = @Id";

        public static string GetAllMinionsByVillainId = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                                                 m.Name, 
                                                                 m.Age
                                                            FROM MinionsVillains AS mv
                                                            JOIN Minions As m ON mv.MinionId = m.Id
                                                           WHERE mv.VillainId = @Id
                                                        ORDER BY m.Name";


    }
}
