namespace DataLibrary.Data;

public class EmployeeService : IEmployeeService
{
    public EmployeeService(ISqlDataAccess db) => _db = db;

    public async Task<List<Employee>>? ReadAll()
    {
        var result = await _db.LoadData<Employee, dynamic>("spEmployee_ReadAll", new { });
        return result.ToList();
    }

    public async Task<Employee?> ReadById(int id)
    {
        var result = await _db.LoadData<Employee, dynamic>("spEmployee_ReadById", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<int> Create(Employee employee)
    {
        var result = await _db.SaveData("spEmployee_Create",
            new { employee.EmployeeId, employee.FirstName, employee.LastName, employee.EmailAddress });
        return result;
    }

    public async Task<int> Update(Employee employee)
    {
        var result = await _db.SaveData("spEmployee_Update", employee);
        return result;
    }
    public async Task<int> Delete(int id)
    {
        var result = await _db.SaveData("spEmployee_Delete", new { Id = id });
        return result;
    }

    private readonly ISqlDataAccess _db;
}
