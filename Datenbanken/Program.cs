using System;
using System.Data.Entity.ModelConfiguration.Configuration;
using MySql.Data.MySqlClient;

// Skript um eine Verbindung zur Fahrrad Datenbank herzustellen
// Author: Florian Manhartseder

namespace DatabaseOperations
{
    public class Database
    {
        private MySqlConnection _connection;
        private MySqlDataReader? _reader = null;
        private string database;
        private string user;
        private string password;
        private string port;
        private string server;

        public Database(string database, string user="root", string server="localhost", string port="3306", string password="") 
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
                Console.WriteLine("Connection is being established...");
                _connection.Open();
                Console.WriteLine("Sucessfuly connected.\n");
            }
            // Fehler beim Verbindungsaufbau abfangen
            catch (Exception ex)
            {
                Console.WriteLine("Exception while connecting to DB ocurred: " + ex.Message);
                System.Environment.Exit(1);
            }
        }

        public MySqlDataReader runSelectQuery(string table, string columns="*", string where="")
        {
            columns = columns == "" ? "*" : columns;
            string query = $"SELECT {columns} FROM {table}";
            query = where == "" ? query : query + " WHERE " + where;

            Console.WriteLine($"Running select: SELECT {columns} FROM {database}...");

            MySqlCommand cmd = new MySqlCommand(query, _connection);

            // Query ausführen
            DateTime startDateTime = DateTime.Now;
            _reader = cmd.ExecuteReader();
            DateTime endDateTime = DateTime.Now;

            // Ausführungsdauer berechnen
            TimeSpan deltaT = endDateTime - startDateTime;

            Console.WriteLine($"Select finished in {deltaT.Milliseconds}ms!\n");

            return _reader;
        }

        public void prettyPrintResponse()
        {
            // Cursor auf Inhalt prüfen
            if (_reader == null || !_reader.HasRows)
            {
                Console.WriteLine("No data found!");
                return;
            }

            // Spaltennamen dynamisch ausgeben
            for (int i = 0; i < _reader.FieldCount; i++)
            {
                Console.Write($"{_reader.GetName(i)}\t\t");
            }
            Console.WriteLine();

            // Daten ausgeben
            while (_reader.Read())
            {
                for (int i = 0; i < _reader.FieldCount; i++)
                {
                    Console.Write($"{_reader.GetValue(i)}\t\t");
                }
                Console.WriteLine();
            }

            // Cursor schließen
            _reader.Close();
        }

        public void insertData(string table, string[] columns, object[] data)
        {
            // Check if number of columns matches data length
            if (columns.Length != data.Length)
            {
                throw new Exception("Number of data fields does not equal number of columns!");
            }

            Console.WriteLine($"Inserting data into {table}");

            string joinedCols = string.Join(", ", columns);
            string joinedParams = "@" + string.Join(", @", data);
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
                    int affectedRows = cmd.ExecuteNonQuery();

                    DateTime endDateTime = DateTime.Now;
                    TimeSpan deltaT = endDateTime - startDateTime;
                    Console.WriteLine($"Insert sucessfuly finished in {deltaT.Milliseconds}ms!\n");
                    Console.WriteLine($"{affectedRows} Rows affected!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during inserting data in table {table}: {ex.Message}");
            }
        }

        public void updateData(string table, string[] column, string where, object[] data)
        {
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
                Console.WriteLine($"Error during update of table {table}: {ex.Message}");
            }
        }


        ~Database()
        {
            // Datenbankverbindung schließen
            Console.WriteLine("Connection is being closed...");
            _connection.Close();
        }
    }


    class Prog
    {
        public static void Main()
        {
            Database database = new Database("fahrrad");

            database.runSelectQuery("fahrrad", "*");
            database.prettyPrintResponse();

            // Create or use log database
            // write all database operations in log database


        }
    }
}
