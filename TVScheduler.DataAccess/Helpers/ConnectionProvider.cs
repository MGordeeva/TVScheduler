using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace TVScheduler.DataAccess.Helpers
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("Database"));
        }
    }
}
