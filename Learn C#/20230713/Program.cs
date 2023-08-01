using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(local);Initial Catalog=sampleDB;Integrated Security=true";
        string queryString = "";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Insert処理
            queryString = "INSERT INTO Table_1 (id, Name) VALUES (5, 'Pearch');";
            ExecuteNonQuery(connection, queryString);

            // Select処理
            queryString = "SELECT * FROM Table_1;";
            ExecuteReader(connection, queryString);

            // Update処理
            queryString = "UPDATE Table_1 SET Name = 'Peach' WHERE Name = 'Pearch';";
            ExecuteNonQuery(connection, queryString);

            // Select処理
            queryString = "SELECT * FROM Table_1;";
            ExecuteReader(connection, queryString);

            // Delete処理
            queryString = "DELETE FROM Table_1 WHERE Name = 'Peach';";
            ExecuteNonQuery(connection, queryString);

            // Select処理
            queryString = "SELECT * FROM Table_1;";
            ExecuteReader(connection, queryString);

            connection.Close();
        }

        Console.ReadLine();
    }
    static void ExecuteNonQuery(SqlConnection connection, string queryString)
    {
        SqlCommand command = new SqlCommand(queryString, connection);

        try
        {
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"処理が成功しました。影響を受けた行数: {rowsAffected}");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ExecuteReader(SqlConnection connection, string queryString)
    {
        SqlCommand command = new SqlCommand(queryString, connection);

        try
        {
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write(reader[i] + "\t");
                }
                Console.WriteLine();
            }
            reader.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
