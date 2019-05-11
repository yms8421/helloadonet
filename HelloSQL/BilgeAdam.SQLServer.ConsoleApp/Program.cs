using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilgeAdam.SQLServer.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //EN KEKO YÖNTEM
            var connectionString = "Server=.;Database=Northwind;Trusted_Connection=True;";
            //var connectionString = "Server=10.11.22.206;Database=Northwind;User Id=student;Password=ba123;";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var query = "SELECT FirstName, LastName, BirthDate FROM Employees";
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("{0,15}{1,20}{2,25}", reader["FirstName"], reader["LastName"], reader["BirthDate"]);
            }

            Console.ReadKey();
        }
    }
}
