using System.Configuration;
using System.Data.SqlClient;

namespace BilgeAdam.SQLServer.WinFormApp.Helpers
{
    public class ConnectionHelper
    {
        public static SqlConnection CreateConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NrthCnnStr"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
