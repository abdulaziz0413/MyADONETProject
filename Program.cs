using System;
using System.Collections.Generic;
using Npgsql;

class Program
{
    static string connString = "Server=localhost;Port=5432;Database=vs;User Id=postgres;Password=oktava;";

    static void Main()
    {
        CreateTable();
        InsertData();
        InsertMultipleData();
        GetAllData();
        GetById(1);
        DeleteById(1);
        UpdateById(2);
        UpdateColumnById(3);
        SearchData("searchtext");
        AddNewColumn("newcolumn");
        AddNewColumnWithDefault("newcolumnwithdefault", "defaultvalue");
        UpdateColumnName("oldcolumnname", "newcolumnname");
        UpdateTableName("newtablename");
    }

    static void CreateTable()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("CREATE TABLE IF NOT EXISTS mytable (id SERIAL PRIMARY KEY, name TEXT)", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void InsertData()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO mytable (name) VALUES ('data1')", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void InsertMultipleData()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO mytable (name) VALUES ('data2'), ('data3')", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void GetAllData()
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM mytable", conn))
            {
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0)); 
                        Console.WriteLine(reader.GetString(1)); 
                    }
                }
            }
        }
    }

    static void GetById(int id)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM mytable WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0)); 
                        Console.WriteLine(reader.GetString(1)); // Assuming the second column is name
                    }
                }
            }
        }
    }

    static void DeleteById(int id)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM mytable WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void UpdateById(int id)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE mytable SET name = 'updateddata' WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void UpdateColumnById(int id)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("UPDATE mytable SET name = 'updateddata' WHERE id = @id", conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void SearchData(string searchText)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM mytable WHERE name LIKE @searchText", conn))
            {
                cmd.Parameters.AddWithValue("searchText", "%" + searchText + "%");
                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetString(0)); // Assuming the first column is id
                        Console.WriteLine(reader.GetString(1)); // Assuming the second column is name
                    }
                }
            }
        }
    }

    static void AddNewColumn(string columnName)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand($"ALTER TABLE mytable ADD COLUMN {columnName} TEXT", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void AddNewColumnWithDefault(string columnName, string defaultValue)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand($"ALTER TABLE mytable ADD COLUMN {columnName} TEXT DEFAULT '{defaultValue}'", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void UpdateColumnName(string oldColumnName, string newColumnName)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand($"ALTER TABLE mytable RENAME COLUMN {oldColumnName} TO {newColumnName}", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }

    static void UpdateTableName(string newTableName)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connString))
        {
            conn.Open();
            using (NpgsqlCommand cmd = new NpgsqlCommand($"ALTER TABLE mytable RENAME TO {newTableName}", conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}   
