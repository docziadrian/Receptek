using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Adatbazis
    {
        private static string connectionString = "Server=localhost;Database=receptek_12a;User id=root;password=;";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void KapcsolodasAdatbazishoz()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Kapcsolat sikeresen megnyitva.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a kapcsolat megnyitásakor: " + ex.Message);
            }
        }

        public static List<Dictionary<string, object>> TableSelect(string tableName)
        {
            var results = new List<Dictionary<string, object>>();
            var osszesRecept = new List<string>();

            try
            {
                using (MySqlCommand selectCommand = new MySqlCommand($"SELECT * FROM {tableName};", connection))
                {
                    using (MySqlDataReader dataReader = selectCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            var row = new Dictionary<string, object>();
                            for (int i = 0; i < dataReader.FieldCount; i++)
                            {
                                string columnName = dataReader.GetName(i);
                                object columnValue = dataReader.IsDBNull(i) ? null : dataReader.GetValue(i);
                                row[columnName] = columnValue;

                                if (columnValue != null)
                                {
                                    osszesRecept.Add(columnValue.ToString());
                                }
                            }
                            results.Add(row);
                        }
                    }
                }

                int szamlalo = 0;
                string sor = "";
                foreach (string recept in osszesRecept)
                {
                    szamlalo++;
                    sor += recept + ";";
                    if (szamlalo == 9)
                    {
                        Receptek.ReceptBeolvasas(sor);
                        sor = "";
                        szamlalo = 0;
                    }
                }

                
            }
            catch (Exception error)
            {
                Console.WriteLine("Hiba a kapcsolódás vagy a lekérdezés során: " + error.Message);
            }
            finally
            {
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Kapcsolat sikeresen lezárva.");
                }
            }
            return results;
        }
    }
}
