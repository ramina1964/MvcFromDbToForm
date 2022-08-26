using Dapper;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace DataLibrary.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    public SqlDataAccess(IConfiguration config) => _config = config;

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameter, string connectionId = "Default")
    {
        var cnn = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(cnn);
        return await connection.QueryAsync<T>(sql: storedProcedure, param: parameter);
    }

    public async Task<int> SaveData<T>(string storedProcedure, T parameter, string connectionId = "Default")
    {
        var cnn = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new SqlConnection(cnn);
        return await connection.ExecuteAsync(sql: storedProcedure, param: parameter);
    }

    private readonly IConfiguration _config;
}
