using DataLibrary.DataAccess;
using DataLibrary.Model;

namespace DataLibrary.Data;

public class EmployeeService : IEmployeeService
{
    public EmployeeService(ISqlDataAccess db) => _db = db;

    public async Task<List<Employee>?> ReadAll()
    {
        var result = await _db.LoadData<Employee, dynamic>("spEmployee_ReadAll", new { });
        return result?.ToList();
    }

    public async Task<Employee?> ReadById(int id)
    {
        var result = await _db.LoadData<Employee, dynamic>("spEmployee_ReadById", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<int> Create(Employee employee) =>
        await _db.SaveData(
              "spEmployee_Create",
              new { employee.Id, employee.FisrstName, employee.LastName, employee.EmailAddress });

    public async Task<int> Update(Employee employee) =>
        await _db.SaveData("spEmployee_ReadById", employee);

    public async Task<int> Delete(int id) =>
        await _db.SaveData("spEmployee_Update", new { Id = id });


    private readonly ISqlDataAccess _db;
}
