namespace DataLibrary.DataAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameter, string connectionId = "Default");
    
    Task<int> SaveData<T>(string storedProcedure, T parameter, string connectionId = "Default");
}