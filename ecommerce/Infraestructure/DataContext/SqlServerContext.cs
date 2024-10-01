using ecommerce.StartupInfra;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace ecommerce.Infraestructure.DataContext
{
    public class SqlServerContext
    {
        private readonly string _connectionString;
        private readonly Settings _settings;

        public SqlServerContext(IOptions<Settings> settings)
        {
            _settings = settings.Value;
            _connectionString = _settings.sqlServerSettings.connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
