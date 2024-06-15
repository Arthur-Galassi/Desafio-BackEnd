using Npgsql;

namespace Vehicle.Management.Infra.Data.Context.Abstractions
{
    public interface IPostgreSqlConnection
    {
        public NpgsqlConnection Connection { get; }
    }
}
