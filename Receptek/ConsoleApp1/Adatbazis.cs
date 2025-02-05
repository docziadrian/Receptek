using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a kapcsolat megnyitásakor: " + ex.Message);
            }
        }

        public static List<string> TableSelect(string tableName)
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
                   
                }
            }
            return osszesRecept;
        }

        public static void TableInsertForrasokba()
        {

            Console.WriteLine("Add meg az új forrás nevét: ");
            string ujForras = Console.ReadLine();

            try
            {
                connection.Open();
                using (MySqlCommand commandInsert = new MySqlCommand($"insert into forrasok (forras_nev) values (@forras_nev)", connection))
                {
                    //Paraméterként adjuk meg az utasítás értékeit.
                    commandInsert.Parameters.AddWithValue("@forras_nev", ujForras);
                    //parancs végrehajtása:
                    commandInsert.ExecuteNonQuery();

                    Console.WriteLine("Sikeres INSERT!");

                    //Lista újratöltés...
                    TableSelect("forrasok");
                    
                }
            }
            catch (MySqlException mySqlError)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(mySqlError);
            }
            catch (Exception error)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(error);
            }
        }
        public static void TableInsertReceptek()
        {

            Console.WriteLine("Add meg az új recept nevét: ");
            string ujRecept = Console.ReadLine();
            Console.WriteLine("Add meg az új hozzávalókat vesszővel elválasztva: ");
            string ujHozzavalo = Console.ReadLine();
            Console.WriteLine("Add meg az új leirást: ");
            string ujLeiras = Console.ReadLine();
            Console.WriteLine("Add meg az új elkészítési időt: ");
            int ujElkeszitesiIdo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add meg az új főzési időt: ");
            int ujFozesiIdo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add meg az új készítő IDjét: ");
            int ujKeszitoID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add meg az új forrás IDjét: ");
            int ujForrasID = Convert.ToInt32(Console.ReadLine());
            int ujOsszesIdo = ujFozesiIdo + ujElkeszitesiIdo;

            try
            {
                connection.Open();
                using (MySqlCommand commandInsert = new MySqlCommand($"insert into receptek (receptNev, hozzavalok, leiras, elokeszitesiIdo, fozesiIdo, osszesIdo, keszito_id, forras_id) values (@receptNev, @hozzavalok, @leiras, @elokeszitesiIdo, @fozesiIdo, @osszesIdo, @keszito_id, @forras_id)", connection))
                {
                    //Paraméterként adjuk meg az utasítás értékeit.
                    commandInsert.Parameters.AddWithValue("@receptNev", ujRecept);
                    commandInsert.Parameters.AddWithValue("@hozzavalok", ujHozzavalo);
                    commandInsert.Parameters.AddWithValue("@leiras", ujLeiras);
                    commandInsert.Parameters.AddWithValue("@elokeszitesiIdo", ujElkeszitesiIdo);
                    commandInsert.Parameters.AddWithValue("@fozesiIdo", ujFozesiIdo);
                    commandInsert.Parameters.AddWithValue("@osszesIdo", ujOsszesIdo);
                    commandInsert.Parameters.AddWithValue("@keszito_id", ujKeszitoID);
                    commandInsert.Parameters.AddWithValue("@forras_id", ujForrasID);
                    //parancs végrehajtása:
                    commandInsert.ExecuteNonQuery();

                    Console.WriteLine("Sikeres INSERT!");

                    //Lista újratöltés...
                    TableSelect("receptek");

                }
            }
            catch (MySqlException mySqlError)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(mySqlError);
            }
            catch (Exception error)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(error);
            }
        }
        public static void TableInsertKeszitok()
        {

            Console.WriteLine("Add meg az új készítő nevét: ");
            string ujKeszito = Console.ReadLine();
            Console.WriteLine("Add meg az új címét nevét: ");
            string ujCim = Console.ReadLine();
            Console.WriteLine("Add meg az új életkor nevét: ");
            int ujEletkor = Convert.ToInt32(Console.ReadLine());


            try
            {
                connection.Open();
                using (MySqlCommand commandInsert = new MySqlCommand($"insert into keszitok (nev, cim, eletkor) values (@nev, @cim, @eletkor)", connection))
                {
                    //Paraméterként adjuk meg az utasítás értékeit.
                    commandInsert.Parameters.AddWithValue("@nev", ujKeszito);
                    commandInsert.Parameters.AddWithValue("@cim", ujCim);
                    commandInsert.Parameters.AddWithValue("@eletkor", ujEletkor);
                    //parancs végrehajtása:
                    commandInsert.ExecuteNonQuery();

                    Console.WriteLine("Sikeres INSERT!");

                    //Lista újratöltés...
                    TableSelect("keszitok");

                }
            }
            catch (MySqlException mySqlError)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(mySqlError);
            }
            catch (Exception error)
            {
                Console.WriteLine("Sikertelen INSERT");
                Console.WriteLine(error);
            }
        }
    }
    
}
