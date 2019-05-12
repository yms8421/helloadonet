using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BilgeAdam.SQLServer.WinFormApp.Helpers
{
    public class DataHelper
    {
        public DataTable GetSqlData(string query, SqlConnection connection = null)
        {
            var selfConnection = false;
            if (connection == null)
            {
                connection = ConnectionHelper.CreateConnection();
                selfConnection = true;
            }
            var command = new SqlCommand(query, connection);
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            if (selfConnection)
            {
                //Bağlantıyı kapat
                connection.Close();
                //bağlantı nesnesini RAM'den sil
                connection.Dispose();
            }
            return dt;
        }

        public DataTable GetSqlData(string query, IEnumerable<SqlParameter> parameters, SqlConnection connection = null)
        {
            var selfConnection = false;
            if (connection == null)
            {
                connection = ConnectionHelper.CreateConnection();
                selfConnection = true;
            }
            var command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters.ToArray());
            var reader = command.ExecuteReader();
            var dt = new DataTable();
            dt.Load(reader);
            reader.Close();
            if (selfConnection)
            {
                //Bağlantıyı kapat
                connection.Close();
                //bağlantı nesnesini RAM'den sil
                connection.Dispose();
            }
            return dt;
        }
    }
}
