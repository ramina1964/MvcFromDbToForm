using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    public SqlDataAccess(IConfiguration config) => _config = config;

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameter, string connectionId = "Default")
    {
        var cnnString = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(cnnString);
        return await connection.QueryAsync<T>(
            sql: storedProcedure,
            param: parameter,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<int> SaveData<T>(string storedProcedure, T parameter, string connectionId = "Default")
    {
        var cnnString = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(cnnString);
        var result = await connection.ExecuteAsync(
            sql: storedProcedure,
            param: parameter,
            commandType: CommandType.StoredProcedure);
        return result;
    }

    private readonly IConfiguration _config;
}
