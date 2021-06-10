using System;
using System.IO;
using Npgsql;

namespace NinjaPlus.Lib
{
    public static class Database
    {

        private static NpgsqlConnection Connection()
        {
            var connectionString = "Host=pgdb;Username=postgres;Password=qaninja;Database=ninjaplus";

            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            return connection;
        }

        public static void InsertMovies()
        {
            var dataSQL = Environment.CurrentDirectory + "\\Data\\data.sql";
            var query = File.ReadAllText(dataSQL);

            var command = new NpgsqlCommand(query, Connection());
            command.ExecuteReader();

            Connection().Close();
        }

        public static void RemoveByTitle(string title)
        {
            var query = $"DELETE FROM public.movies WHERE title = '{title}';";

            var command = new NpgsqlCommand(query, Connection());
            command.ExecuteReader();

            Connection().Close();
        }
    }
}