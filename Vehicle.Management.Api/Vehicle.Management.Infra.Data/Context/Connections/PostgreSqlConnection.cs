using Npgsql;

namespace Vehicle.Management.Infra.Data.Context.Connections
{
    public class PostgreSqlConnectionContext
    {
        public NpgsqlConnection Connection { get; }

        public PostgreSqlConnectionContext(string connectionString)
            => (Connection = new NpgsqlConnection(new NpgsqlConnectionStringBuilder(connectionString)
            {           
            }.ConnectionString)).Open();
    }
}
