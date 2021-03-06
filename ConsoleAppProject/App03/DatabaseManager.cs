using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace ConsoleAppProject.App03
{
    class DatabaseManager
    {
        SyntaxGenerator syntaxGen = new SyntaxGenerator();
        public string DirectoryFinder(string filename)
        {
            string parentDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = @"App03\Database\" + filename;
            parentDir = parentDir.Remove(parentDir.Length - 24, 24);
            return parentDir + relativePath;
        }
        public void ExecuteNonQuery(string queryString, string filename)
        {
            using (var connection = new SQLiteConnection("Data Source=" + DirectoryFinder(filename) + ";Version=3;"))
            {
                using (var command = new SQLiteCommand(queryString, connection))
                {
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public string ExecuteQuery(string queryString, string filename)
        {
            string data = null;
            using (var connection = new SQLiteConnection("Data Source=" + DirectoryFinder(filename) + ";Version=3;"))
            {
                using (var command = new SQLiteCommand(queryString, connection))
                {
                    command.Connection.Open();
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (queryString.Contains("WHERE") || queryString.Contains("max") || queryString.Contains("min") || queryString.Contains("count") || queryString.Contains("avg"))
                        {
                            while (reader.Read())
                            {
                                try
                                {
                                    data = reader[0].ToString();
                                }
                                catch (InvalidOperationException)
                                {

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(syntaxGen.SyntaxFiller1(" ┌────┬──────────────────────────────┬─────┬─────┐"));
                            Console.WriteLine(syntaxGen.SyntaxFiller1(" │" + $@"{reader.GetName(0),-4}│{reader.GetName(1),-30}│{reader.GetName(2),5}│{reader.GetName(3),5}" + "│"));
                            Console.WriteLine(syntaxGen.SyntaxFiller1(" ├────┼──────────────────────────────┼─────┼─────┤"));
                            while (reader.Read())
                            {
                                try
                                {
                                    Console.WriteLine(syntaxGen.SyntaxFiller1(" │" +  $@"{reader[0].ToString(),-4}│{reader[1].ToString(),-30}│{reader[2].ToString(),5}│{reader[3].ToString(),5}" + "│"));
                                }
                                catch (InvalidCastException e)
                                {
                                    Console.WriteLine(e);
                                }
                            }
                            Console.WriteLine(syntaxGen.SyntaxFiller1(" └────┴──────────────────────────────┴─────┴─────┘"));
                        }
                    }
                }
            }
            return data;
        }
        public void InitialiseTable()
        {
            ExecuteNonQuery("CREATE TABLE IF NOT EXISTS Students (ID INTEGER PRIMARY KEY, name STRING, marks INTEGER, grade STRING)", "MyDatabase.sqlite");
        }
        public void InsertDB(string table, string columns, string columnData)
        {
            ExecuteNonQuery("INSERT INTO " + table + " (" + columns + ") VALUES (" + columnData + ")", "MyDatabase.sqlite");
        }
        public void ReadAllDB(string table)
        {
            ExecuteQuery("SELECT * FROM " + table, "MyDatabase.sqlite");
        }
        public string ReadDB(string table, string targetColumn, string where)
        {
            return ExecuteQuery("SELECT " + targetColumn + " FROM " + table + " WHERE " + where, "MyDatabase.sqlite");
        }
        public string ReadMaxValDB(string table, string targetColumn)
        {
            return ExecuteQuery("SELECT max(" + targetColumn + "), * FROM " + table, "MyDatabase.sqlite");
        }
        public string ReadMinValDB(string table, string targetColumn)
        {
            return ExecuteQuery("SELECT min(" + targetColumn + "), * FROM " + table, "MyDatabase.sqlite");
        }
        public string CountColumnDB(string table, string targetColumn, string where)
        {
            return where.Equals("none")
                ? ExecuteQuery("SELECT count(" + targetColumn + "), * FROM " + table + " WHERE ", "MyDatabase.sqlite")
                : ExecuteQuery("SELECT count(" + targetColumn + "), * FROM " + table + " WHERE " + where, "MyDatabase.sqlite");
        }
        public string ColumnAverageDB(string table, string targetColumn, string where)
        {
            return where.Equals("none")
                ? ExecuteQuery("SELECT avg(" + targetColumn + ") FROM " + table, "MyDatabase.sqlite")
                : ExecuteQuery("SELECT avg(" + targetColumn + "), * FROM " + table + " WHERE " + where, "MyDatabase.sqlite");
        }
        public void UpdateDB(string table, string targetColumn, string where)
        {
            ExecuteNonQuery("UPDATE " + table + " SET " + targetColumn + " WHERE " + where, "MyDatabase.sqlite");
        }
        public void DeleteRowDB(string table, string where)
        {
            ExecuteNonQuery("DELETE FROM " + table + " WHERE " + where, "MyDatabase.sqlite");
        }

        public string ReadMaxValGradeDB(string table, string targetColumn, string where)
        {
            return ExecuteQuery("SELECT max(" + targetColumn + "), * FROM " + table + " WHERE " + where, "GradeData.db");
        }
        public string ReadGradeDB(string table, string targetColumn, string where)
        {
            return ExecuteQuery("SELECT " + targetColumn + " FROM " + table + " WHERE " + where, "GradeData.db");
        }
    }
}
