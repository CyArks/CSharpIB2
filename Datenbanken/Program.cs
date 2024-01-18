using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Web;
using MySql.Data.MySqlClient;


// Skript um eine Verbindung zur Fahrrad Datenbank herzustellen
// Author: Florian Manhartseder

namespace DatabaseOperations
{
    public class Logger
    {
        public static readonly Logger Instance = new Logger();
    }

    public class Database
    {
        private MySqlConnection _connection;
        private MySqlDataReader? _reader = null;
        private string database;
        private string user;
        private string password;
        private string port;
        private string server;

        public Database(string database, string user = "root", string server = "localhost", string port = "3306", string password = "")
        {
            this.database = database;
            this.user = user;
            this.server = server;
            this.port = port;
            this.password = password;

            string connectionString = $"server={server};user={user};database={database};port={port};";
            _connection = new MySqlConnection(connectionString);

            // Verbindung herstellen
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Connection is being established...");
                _connection.Open();
                Console.WriteLine("Sucessfuly connected.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Fehler beim Verbindungsaufbau abfangen
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception while connecting to DB ocurred: " + ex.Message);
                System.Environment.Exit(1);
            }
        }

        public async Task<MySqlDataReader> runSelectQueryAsync(string table, string columns = "*", string where = "")
        {
            columns = columns == "" ? "*" : columns;
            string query = $"SELECT {columns} FROM {table}";
            query = where == "" ? query : query + " WHERE " + where;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Running select: SELECT {columns} FROM {database}...");

            MySqlCommand cmd = new MySqlCommand(query, _connection);

            try
            {
                // Query ausführen
                DateTime startDateTime = DateTime.Now;
                MySqlDataReader reader = (MySqlDataReader) await cmd.ExecuteReaderAsync();
                DateTime endDateTime = DateTime.Now;

                // Ausführungsdauer berechnen
                TimeSpan deltaT = endDateTime - startDateTime;

                Console.WriteLine($"Select finished in {deltaT.Milliseconds}ms!\n");
                Console.ForegroundColor = ConsoleColor.White;

                return reader;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception while executing select query: " + ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                throw;
            }   
        }

        public void prettyPrintResponse(MySqlDataReader reader)
        {
            List<string> columnNames = new List<string>();
            List<int> colWidths = new List<int>();
            List<List<object>> rows = new List<List<object>>();
            int spacing = 2; // Defines the spacing between the columns

            // Cursor auf Inhalt prüfen
            if (reader == null || !reader.HasRows)
            {
                Console.WriteLine("No data found!");
                return;
            }

            // Spaltennamen lesen
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string colName = reader.GetName(i);
                columnNames.Add(colName);
                colWidths.Add(colName.Length);
            }

            // Values speichern
            while (reader.Read())
            {
                List<object> row = new List<object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    object value = reader.GetValue(i);
                    int valueLength = value.ToString().Length;
                    row.Add(value);

                    if (colWidths[i] < valueLength)
                    {
                        colWidths[i] = valueLength;
                    }
                }
                rows.Add(row);
            }

            /*
            foreach (var start in colWidths.Zip(dataStart, (a, b) => new { A = a, B = b}))
            {
                int biggest = (int)start.A;
                if (start.A < start.B)
                {
                    biggest = (int)start.B;
                }
                starts.Add(biggest);
            }
            
            
            // Craft a list with the linestarts
            int linestart = 0;
            finalLineStarts.Add(0);
            foreach (int linenumber in starts)
            {
                linestart += linenumber;
                finalLineStarts.Add(linestart);
            }
            */

            // print columns
            for (int i = 0; i < columnNames.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(columnNames[i].PadRight(colWidths[i] + spacing) + "|  ");
            }
            Console.WriteLine();
            Console.WriteLine(new String('-', colWidths.Sum() + 2 * spacing * colWidths.Count + 2 * spacing) + '|');

            Console.ForegroundColor = ConsoleColor.White;

            int y = 0;
            // print rows
            foreach (var row in rows)
            {
                if (y % 2 == 0) Console.ForegroundColor = ConsoleColor.Gray;
                else Console.ForegroundColor = ConsoleColor.DarkGray;

                for (int i = 0; i < row.Count; i++)
                {
                    Console.Write(row[i].ToString().PadRight(colWidths[i] + spacing) + "|  ");
                }
                Console.WriteLine();
                y++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String('-', colWidths.Sum() + 2 * spacing * colWidths.Count + 2 * spacing) + '|');

            // Cursor schließen
            reader.Close();
        }

        public async Task insertDataAsync(string table, string[] columns, object[] data)
        {
            // Check if number of columns matches data length
            if (columns.Length != data.Length)
            {
                throw new Exception("Number of data fields does not equal number of columns!");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Inserting data into {table}");

            string joinedCols = string.Join(", ", columns);
            string[] paramPlaceholders = new string[columns.Length];

            for (int i = 0; i < columns.Length; i++)
            {
                paramPlaceholders[i] = '@' + columns[i];
            }

            string joinedParams = string.Join(", ", paramPlaceholders);
            string query = $"INSERT INTO {table} ({joinedCols}) VALUES ({joinedParams})";

            try
            {
                // Query ausführen
                using (var cmd = new MySqlCommand(query, _connection))
                {
                    for (int i = 0; i < columns.Length; i++)
                    {
                        cmd.Parameters.AddWithValue("@" + columns[i], data[i]);
                    }

                    DateTime startDateTime = DateTime.Now;
                    int affectedRows = await cmd.ExecuteNonQueryAsync();

                    DateTime endDateTime = DateTime.Now;
                    TimeSpan deltaT = endDateTime - startDateTime;
                    Console.WriteLine($"Insert sucessfuly finished in {deltaT.Milliseconds}ms!");
                    Console.WriteLine($"{affectedRows} Row(s) affected!\n");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex);
                Console.WriteLine($"Error during inserting data in table {table}: {ex.Message}");
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void updateData(string table, string[] column, string where, object[] data)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Updating column {column} in table {table} where {where} with data: {data}");

            string joinedCols = string.Join(", ", column);
            string joinedParams = "@" + string.Join(", @", data);
            string query = $"UPDATE {table} SET {joinedCols} WHERE {where}";

            try
            {
                using (var cmd = new MySqlCommand(query, _connection))
                {
                    for (int i = 0; i < column.Length; i++)
                    {
                        cmd.Parameters.AddWithValue("@" + column[i], data[i]);
                    }

                    DateTime startDateTime = DateTime.Now;
                    int affectedRows = cmd.ExecuteNonQuery();

                    DateTime endDateTime = DateTime.Now;
                    TimeSpan deltaT = endDateTime - startDateTime;
                    Console.WriteLine($"Updated sucessfuly, finished in {deltaT.Milliseconds}ms!\n");
                    Console.WriteLine($"{affectedRows} Rows affected!");
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error during update of table {table}: {ex.Message}");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void deleteData()
        {
            Console.WriteLine();
        }

        public string[] getColumnsFromTable()
        {
            // ToDo: Implement
            string[] ColumnNames = { "" };
            return ColumnNames;
        }

        ~Database()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Connection is being closed...");
            Console.ForegroundColor = ConsoleColor.White;

            // Datenbankverbindung schließen
            _connection.Close();
        }
    }


    class Prog
    {
        public static async Task Main()
        {
            Database database = new Database("fahrrad");

            var fahrrad = await database.runSelectQueryAsync("fahrrad", "*");
            database.prettyPrintResponse(fahrrad);

            Console.WriteLine("\n\n");
           
            var Herstellernr24 = await database.runSelectQueryAsync("fahrrad", "*", "Herstellernr = 24");
            database.prettyPrintResponse(Herstellernr24);

            Console.WriteLine("\n\n");

            string[] columns = { "Fahrradnr", "Bezeichnung", "Rahmennummer", "Tagesmietpreis", "Wert", "Kaufdatum", "Herstellernr" };
            object[] data = { 425, "Citybike", "IK23HJ4", 14.5, 499.99, DateTime.Now, 24 };

            await database.insertDataAsync("fahrrad", columns, data);

            Console.WriteLine("\n\n");

            object[] data1 = { "MyCityBike" };
            string[] colss = { "Bezeichnung" };

            database.updateData("fahrrad", colss, "Fahrradnr = 420", data1);

            Console.WriteLine("\n\n");

            var fahrradnrGreater400 = await database.runSelectQueryAsync("fahrrad", "*", "Fahrradnr >= 400");
            database.prettyPrintResponse(fahrradnrGreater400);

            Console.WriteLine("\n\n");


            // ToDo:
            // Create log DB
            // Write all database operations in log table
            // Create html page to run and view queries


            Console.ReadLine();
        }
    }
}
