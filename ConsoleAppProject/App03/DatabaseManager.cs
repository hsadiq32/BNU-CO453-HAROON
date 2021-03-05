using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace ConsoleAppProject.App03
{
    class DatabaseManager
    {
        public void ExecuteNonQuery(string queryString)
        {
            using (var connection = new SQLiteConnection("Data Source=" + DirectoryFinder() + ";Version=3;"))
            {
                using (var command = new SQLiteCommand(queryString, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public SQLiteConnection connection;
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        public string DirectoryFinder()
        {
            string parentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"App03\Database\MyDatabase.sqlite";
            parentDir = parentDir.Remove(parentDir.Length - 24, 24);
            return parentDir + relativePath;
        }
        public void ConnectDB()
        {
            connection = new SQLiteConnection("Data Source=" + DirectoryFinder() + ";Version=3;");
            connection.Open();
        }
        public void CloseDB()
        {
            connection.Close();
        }
        public void InitialiseTable()
        {
            ConnectDB();
            SQLiteCommand command = new SQLiteCommand("CREATE TABLE IF NOT EXISTS Students (ID INTEGER PRIMARY KEY, name STRING, mark INTEGER)", connection);
            command.ExecuteNonQuery();
            CloseDB();
        }
        public void InsertDB(string table, string columns, string columnData)
        {
            ConnectDB();
            SQLiteCommand command = new SQLiteCommand("INSERT INTO " + table + " (" + columns + ") VALUES (" + columnData + ")", connection);
            command.ExecuteNonQuery();
            CloseDB();
        }
        public void ReadAllDB(string table)
        {
            ConnectDB();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM " + table, connection);
            SQLiteDataReader rdr = command.ExecuteReader();
            try
            {
                while (rdr.Read())
                {
                    Console.WriteLine(syntaxGen.SyntaxFiller1($"{rdr.GetInt32(0)} {rdr.GetString(1)} {rdr.GetInt32(2)}"));
                }
            }
            catch (InvalidCastException)
            {

            }
            CloseDB();
        }
        public string ReadDB(string table, string targetColumn, string where)
        {
            string data = null;
            ConnectDB();
            SQLiteCommand command = new SQLiteCommand("SELECT " + targetColumn + " FROM " + table + " WHERE " + where, connection);
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                data = reader[targetColumn].ToString();
                Console.WriteLine(syntaxGen.SyntaxFiller1(data));
            }
            CloseDB();
            return data;
        }
        public void UpdateDB(string table, string targetColumn, string where)
        {
            ConnectDB();
            SQLiteCommand command = new SQLiteCommand("UPDATE " + table + " SET " + targetColumn + " WHERE " + where, connection);
            command.ExecuteNonQuery();
            CloseDB();
        }
        public void DeleteRowDB(string table, string where)
        {
            ConnectDB();
            SQLiteCommand command = new SQLiteCommand("DELETE FROM " + table + " WHERE " + where, connection);
            command.ExecuteNonQuery();
            CloseDB();
        }
    }
}
