namespace MvcApp.IntegrationTests.Setup;

public class SqlDataAccess : ISqlDataAccess
{
    public SqlDataAccess(TestDbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameter, string connectionId = "Default")
    {
        using IDbConnection connection = _dbContext.Database.GetDbConnection();
        return await connection.QueryAsync<T>(
            sql: storedProcedure,
            param: parameter,
            commandType: CommandType.StoredProcedure);
    }

    public async Task<int> SaveData<T>(string storedProcedure, T parameter, string connectionId = "Default")
    {
        using IDbConnection connection = _dbContext.Database.GetDbConnection();
        var result = await connection.ExecuteAsync(
            sql: storedProcedure,
            param: parameter,
            commandType: CommandType.StoredProcedure);

        return result;
    }

    private readonly TestDbContext _dbContext;
}
