using Npgsql;
using Vehicle.Management.Infra.Data.Context.Abstractions;

namespace Vehicle.Management.Infra.Data.Context
{
    public class PostgreSqlContext
    {
        public readonly NpgsqlConnection Connection;
        internal PostgreSqlContext(IPostgreSqlConnection connection) => Connection = connection.Connection;
    }
}
