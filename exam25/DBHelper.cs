using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam25
{
    public class DBHelper
    {
        private readonly string _connectionString = "Host=localhost;Port=5432;Database=exam25;Username=postgres;Password=123";
        private readonly NpgsqlConnection _connection;

        public DBHelper()
        {
            _connection = new NpgsqlConnection(_connectionString);
            _connection.Open();
        }

        public NpgsqlConnection GetConnection()
        {
            return _connection;
        }
    }
}
