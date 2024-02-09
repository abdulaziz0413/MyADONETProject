using Npgsql;

namespace MyADONETProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string CONNECTIONSTRING= "Server=localhost;Port=5432;Database=vs;User Id=postgres;Password=oktava;";
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            connection.Open();
            string query = "select * from skypedars";
            
            NpgsqlCommand command = new NpgsqlCommand(query, connection);
            NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("{0},{1},{")
            }
            //logic
            Console.WriteLine("Database da table yaratildi");

            connection.Close();
        }
    }   
}
