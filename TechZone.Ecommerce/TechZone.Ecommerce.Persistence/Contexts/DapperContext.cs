using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace TechZone.Ecommerce.Persistence.Contexts
{
    internal sealed class DapperContext(IConfiguration configuration)
    {
        private readonly string _connectionString = configuration.GetConnectionString("DevConnection");
        public string ConnectionString => _connectionString;
        internal IDbConnection? Connection => new MySqlConnection(ConnectionString);
        internal void Dispose()
        {
            if (Connection is not null)
            {
                Connection.Dispose();
            }
        }
    }
}
