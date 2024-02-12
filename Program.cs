using Npgsql;

namespace MyADONETProject
{
    public class insertOneData
    {
        
        public insertOneData()
        {
            SkypeDars table = new SkypeDars();
            Console.WriteLine("mavzuni qo'shing");
            table.mavzu = Console.ReadLine();
            Console.WriteLine("o'quvshilar sonini qo'shing");
            table.students_count = int.Parse(Console.ReadLine());
            table.start_date = DateTime.UtcNow;
            string query = $@"insert into skypedars(mavzu, start_date, students_count) 
                            values ('{table.mavzu}',{table.start_date}, {table.students_count})";

            return query;



        }
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string CONNECTIONSTRING= "Server=localhost;Port=5432;Database=vs;User Id=postgres;Password=oktava;";
            NpgsqlConnection connection = new NpgsqlConnection(CONNECTIONSTRING);
            int son;
            Console.WriteLine("Tegishli sonni tanlang:\n\t1-Bitta ma'lumot qo'shish\n\t2-Ko'p ma'lumot qo'shish");
            son = int.Parse(Console.ReadLine());
            switch (son)
            {
                case 1:
                    {
                      
                        
                        break;
                    }
            connection.Open();


            
            
            NpgsqlCommand command = new NpgsqlCommand(insertOneData., connection);
            NpgsqlDataReader reader = command.ExecuteReader();
             
            //logic
            Console.WriteLine("Database da table yaratildi");

            connection.Close();
        }
    }   
}
