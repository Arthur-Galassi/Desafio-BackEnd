using Dapper;
using Vehicle.Management.Infra.Data.Context;
using Vehicle.Management.Infra.Data.Context.Abstractions;
using Vehicle.Menagement.Domain.Repositories.Abstractions;

namespace Vehicle.Management.Infra.Data.Repositories
{
    public class VehicleRepository(IPostgreSqlConnection connection) : PostgreSqlContext(connection), IVehicleRepository
    {
        public async Task InsertVehicleRecord()
        => await Connection.QueryFirstAsync(Query.InsertVehicleRecord.Value);
    }
}
